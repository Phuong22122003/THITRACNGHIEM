using DevExpress.XtraPrinting.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace THITRACNGHIEM
{
    public partial class formBoDe : Form
    {
        private int index;
        private int vitri;
        private bool HasChange;
        private ActionState currentAction;
        private DataRow currentDataRow;
        Object[] previousData;
        private MyStack UndoStack;
        private MyStack RedoStack;
        private String mamh;
        private Action action;
        private Dictionary<String, MyStack> listOfUndoStack;
        private Dictionary<String, MyStack> listOfRedoStack;
        private Dictionary<String, int> listOfIndex;
        public formBoDe()
        {
            InitializeComponent();

        }

        private void formBoDe_Load(object sender, EventArgs e)
        {
            ///Tải môn học thất bại thì thông báo vào cho người dùng reload hoặc thoát. 
            ///      + Cho người dùng reload thành công môn học mới cho reload tới câu hỏi
            /// Tải môn học cho combobox nếu tải thành công thì sẽ cho thực hiện chức năng thêm xóa sửa hiệu chỉnh ghi ...
            /// Gắn các sự kiện cho undo và redo để thực hiện quản lý nút phục hồi hoặc redo và nút ghi
            /// 
            try
            {
            this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.MONHOCTableAdapter.Fill(this.DS_BODE.MONHOC);
            this.DS_BODE.EnforceConstraints = false;
            }
            catch
            {
                MessageBox.Show("Không thể tải dữ liệu");
                btnThem.Enabled = btnXoa.Enabled= 
                    btnHieuChinh.Enabled=btnPhucHoi.Enabled = 
                    btnRedo.Enabled=btnGhi.Enabled= false;
                return;
            }
            //stack
            listOfUndoStack = new Dictionary<String, MyStack>();
            listOfRedoStack = new Dictionary<String, MyStack>();
            listOfIndex = new Dictionary<string, int>();
            //listOfIndex.Add(cmbMonHoc.SelectedValue.ToString(), 0);
            //this.UndoStack = new MyStack();
            //listOfUndoStack.Add(cmbMonHoc.SelectedValue.ToString(),UndoStack);
            //this.UndoStack.StackChange += UndoStackChange;
            //this.UndoStack.TriggerEvent();

            //this.RedoStack = new MyStack();
            //listOfRedoStack.Add(cmbMonHoc.SelectedValue.ToString(), RedoStack);
            //this.RedoStack.StackChange += RedoStackChange;
            //this.RedoStack.TriggerEvent();

            ///Ta ẩn panel-control của form nhập câu hỏi
            /// Gọi cmbMonHoc_SelectedIndexChanged để load câu hỏi
            /// Đặt giá trị cho combobox trình độ trong form nhập câu hỏi
            /// ///
            this.HidePanelEdit(true);
            this.cmbMonHoc_SelectedIndexChanged(null, null);
            this.SetComboboxValue();


            ///Nếu load mà môn đó không có câu nào thì sẽ không cho hiệu chỉnh và xóa.
            ///Nếu có câu hỏi phải kiểm tra câu đó có phải của giáo viên đó không và câu đó đã được thi hay chưa. 
            ///Nếu là của giáo viên đó và chưa được thi thì cho hiệu chỉnh với xóa.
            if (bdsBoDe.Count == 0)
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            else   if (((DataRowView)bdsBoDe.Current).Row["ISUSED"].ToString().Equals("True")
                            || !((DataRowView)bdsBoDe.Current).Row["MAGV"].ToString().Trim().Equals(Data.username))
            {
                btnHieuChinh.Enabled = false;
                btnXoa.Enabled = false;
            }
            else btnHieuChinh.Enabled = btnXoa.Enabled = true;

            bdsBoDe.PositionChanged += PositionChange;
        }
        //Hàm bổ trợ

        /// Khi ta chọn các dòng khác nhau trên gridcontrol thì sẽ phải kiểm tra để cho phép người đó có được xóa sửa hay không
        private void PositionChange(object sender, EventArgs e)
        {
            if (bdsBoDe.Position < 0) return;
            if (((DataRowView)bdsBoDe.Current).Row["ISUSED"].ToString().Equals("True")
                || !((DataRowView)bdsBoDe.Current).Row["MAGV"].ToString().Trim().Equals(Data.username))
            {
                btnHieuChinh.Enabled = false;
                btnXoa.Enabled = false;
            }
            else btnHieuChinh.Enabled = btnXoa.Enabled = true;

        }
        private void ValueChanged(object sender, EventArgs e)
        {
            HasChange = true;
        }
        //Set các giá trị cho combobox đáp án và combobox trình độ
        private void SetComboboxValue()
        {
            //cmbTrinhdo
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MATRINHDO");
            dataTable.Columns.Add("TENTRINHDO");
            dataTable.Rows.Add( "A", "Đại học,  chuyên ngành");
            dataTable.Rows.Add("B", "Đại học, không chuyên ngành");
            dataTable.Rows.Add("C", "Cao đẳng");
            cmbTrinhDo.DataSource = dataTable;
            cmbTrinhDo.DisplayMember = "TENTRINHDO";
            cmbTrinhDo.ValueMember = "MATRINHDO";
            cmbDapAn.Items.Add("A");
            cmbDapAn.Items.Add("B");
            cmbDapAn.Items.Add("C");
            cmbDapAn.Items.Add("D");
            cmbDapAn.SelectedIndex = 0;
        }

         ///<summary>
        /// Khi mà undostack có thay đổi ta sẽ kiểm tra:
        ///     Nếu mà trong stack còn thì vẫn cho phục hồi
        ///     Nếu mà chưa lưu thì không cho reload cũng như thoát dựa vào index trong stack
        ///     Nếu chưa lưu thì không cho chuyển qua môn khác
        ///     Cho phép ghi khi có thay đổi dựa vào index
        /// </summary>
        private void UndoStackChange()
        {
           btnPhucHoi.Enabled = (UndoStack.getSize() > 0);
            
            btnReload.Enabled = btnThoat.Enabled = (UndoStack.getSize() ==index);
            
            cmbMonHoc.Enabled = (UndoStack.getSize() == index);

            btnGhi.Enabled = (UndoStack.getSize() != index);
        }

        private void RedoStackChange()
        {
            if (RedoStack.getSize() == 0) btnRedo.Enabled = false;
            else btnRedo.Enabled = true;
        }

        /// <summary>
        /// Ẩn hoặc hiện giao diện thêm câu hỏi
        /// </summary>
        /// <param name="allow"></param>
        private void HidePanelEdit(bool allow)
        {
            if (allow)
                this.panelEditCauHoi.Dock = DockStyle.None;
            else this.panelEditCauHoi.Dock = DockStyle.Bottom;

            panelEditCauHoi.Visible = !allow;
            gcBode.Enabled = allow;
        }
        //Hàm cho các sự kiện
        /// <summary>
        /// Khi thêm ta sẽ phải hiện panel control cho người dùng nhập liệu
        /// Thêm một dòng mới
        /// Gán mã môn cho dòng đó -> không cần nhập liệu mà dựa vào combobox hoặc bds
        /// Gán mã giáo viên cho câu hỏi đó -> dựa vào username đã lưu ở đầu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            currentAction = ActionState.ADDED;
            //Lưu lại vị trí
            this.vitri = bdsBoDe.Position;
            //Hiện ra panel để edit
            this.HidePanelEdit(false);
            //Thêm dòng
            this.bdsBoDe.AddNew();
            //gán mã môn cho dòng
            ((DataRowView)(bdsBoDe.Current))["MAMH"] = cmbMonHoc.SelectedValue.ToString();

            ((DataRowView)(bdsBoDe.Current))["MAGV"] = Data.username;
            //Lúc thêm thì không cho các hành động khác trừ nút xong và hủy
            this.btnThem.Enabled = btnXoa.Enabled =btnGhi.Enabled= 
                btnHieuChinh.Enabled=btnReload.Enabled = btnThoat.Enabled = btnPhucHoi.Enabled=false;
            this.cmbMonHoc.Enabled = false;
              
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút xong trong phần panel-control của câu hỏi.
        /// Kiểm tra xem người dùng có nhập trống hay không.
        /// Kiểm tra các đáp án A,B,C,D có cái nào trùng nhau hay không.
        /// Sau khi kiểm tra nhập liệu nếu người dùng trước đó nhấn nút thêm thì sẽ lưu vào stack với trang thái thêm mới, nếu sửa thì thêm vào trạng thái là sửa nếu không sửa gì thì sẽ bỏ qua.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXong_Click(object sender, EventArgs e)
        {
            
            //Kiểm tra lỗi nhập liệu
            Dictionary<char,String> dict = new Dictionary<char, String>();
            dict['N'] = txtNoiDung.Text.Trim();
            dict['A'] = txtA.Text.Trim();
            dict['B'] = txtB.Text.Trim();
            dict['C'] = txtC.Text.Trim();
            dict['D'] = txtD.Text.Trim();
            //Check lỗi điền trống
            foreach (var pair in dict)
            {
                   if (pair.Value.Equals(""))
                    {
                        if(pair.Key.Equals('N'))
                            MessageBox.Show("Nội dung không được trống");
                        else 
                            MessageBox.Show("Đáp án "+pair.Key+" không được trống");
                        return;
                    }
            }
            if(cmbTrinhDo.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trình độ");
                return;
            }
            if(cmbDapAn.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đáp án");
                return;
            }            
            //check lỗi giống nội dung đáp án
            dict.Remove('N');
            Dictionary<String, List<char>> dup = new Dictionary<string,List<char>>();
            foreach (var pair in dict)
            {
                if (dup.ContainsKey(pair.Value))
                {
                    dup[pair.Value].Add(pair.Key);
                }
                else
                {
                    dup[pair.Value] = new List<char>();
                    dup[pair.Value].Add(pair.Key);
                }
            }
            String message="";
            foreach (var group in dup)
            {
                if (group.Value.Count > 1)
                {
                    message += String.Join(" và ", group.Value) +";";
                }
            }
            if (!message.Equals(""))
            {
                MessageBox.Show("Tồn tại đáp án trùng nhau:" + message);
                return;
            }
            currentDataRow = ((DataRowView)bdsBoDe.Current).Row;
            
            //thêm filed
            currentDataRow["TRINHDO"] = cmbTrinhDo.SelectedValue.ToString();
            currentDataRow["DAP_AN"] = cmbDapAn.SelectedItem.ToString();
            currentDataRow["ISUSED"] = false;
            try
            {
                //Xác nhận dòng đó đã edit xong
               bdsBoDe.EndEdit();

                HidePanelEdit(true);
                btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = true;
                String[] keyValue = Array.ConvertAll(currentDataRow.ItemArray.Skip(1).ToArray(), x => x.ToString().Trim());
                String key = String.Join(", ", keyValue);
                //1Thêm một dòng mới
                if (currentAction == ActionState.ADDED)
                {
                    UndoStack.Push(ActionState.ADDED, key,currentDataRow.ItemArray);
                }
                //2 sửa
                else if (HasChange)
                {
                    UndoStack.Push(ActionState.MODIFIED, key,previousData);
                }
                else return;//khong sua gi
                RedoStack.Clear();
            }
            catch (Exception ex)
            {
                    MessageBox.Show( ex.Message);
            }
            finally
            {
                currentDataRow = null;
            }
        }
        /// <summary>
        /// Xử lý khi click nút ghi
        /// Cập nhật vị trí index trong stack
        /// Kích hoạt sự kiện để disable nút ghi và enable nút reload, thoát...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.bdsBoDe.EndEdit();
                this.BODETableAdapter.Update(this.DS_BODE.BODE);
                index = this.UndoStack.getSize();
                listOfIndex[mamh] = index;
                this.UndoStack.TriggerEvent();
                //check nếu còn câu hỏi hay ko
                if (bdsBoDe.Count == 0) btnXoa.Enabled = btnHieuChinh.Enabled = false;
                    else btnXoa.Enabled = btnHieuChinh.Enabled = true;
                btnThem.Enabled  = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ghi câu hỏi thất bại\n" + ex.Message);
                bdsBoDe.Position = vitri;
            }
        }
        /// <summary>
        /// Xử lý khi người dùng muốn hiệu chỉnh.
        /// Kiểm tra câu hỏi đó mới nhập liệu hay không. Nếu không thì kiểm tra về csdl để xem câu đó đã thi hay chưa.
        /// Trường hợp người dùng có sửa đổi hay không hay chỉ mở lên rồi đóng thì ta sẽ dùng haschange để kiểm tra. Biến này sẽ thành true khi người dùng nhập liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             btnXong.Enabled = true;
            
            //Nếu câu hỏi mới thêm thì không kiểm tra nó đã  thi hay chưa ngược lại thì kiểm tra.
            if (!((DataRowView)bdsBoDe.Current)["CAUHOI"].ToString().Equals(""))
            {
                int check = Data.ExecuteScalar("SELECT dbo.UDF_KIEMTRA_CH_DATHI (" + ((DataRowView)bdsBoDe.Current)["CAUHOI"].ToString() + ")", Data.ServerConnection);
                if (check == 1) btnXong.Enabled = false;
            }
            
            currentAction = ActionState.MODIFIED;
            HasChange = false;
            vitri = bdsBoDe.Position;
            previousData = ((DataRowView)bdsBoDe.Current).Row.ItemArray;
            //gán giá trị lại cho combobox
            cmbDapAn.SelectedItem = (String)((DataRowView)bdsBoDe.Current)["DAP_AN"];
            cmbTrinhDo.SelectedValue = ((String)((DataRowView)bdsBoDe.Current)["TRINHDO"]);
            
            HidePanelEdit(false);
            this.btnThem.Enabled = this.btnXoa.Enabled =  this.btnHieuChinh.Enabled =
                 this.btnPhucHoi.Enabled = this.btnReload.Enabled = btnGhi.Enabled=this.btnThoat.Enabled = false;
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng thay đổi combobox môn học để xem câu hỏi của môn đó.
        /// Mỗi khi tải câu hỏi của môn đó thì ta sẽ kiểm tra liệu môn đó có câu hỏi nào không.
        ///         Nếu có sẽ kiểm tra vị trí hiện tại của câu hỏi có phải của giáo viên đó không mới cho hiệu chỉnh hoặc xóa.
        /// Kiểm tra nhóm hiện tại của người dùng là TRUONG hay COSO hay GIAOVIEN. Nếu trường thì không cho thêm xóa sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.SelectedValue == null) return;
            mamh = cmbMonHoc.SelectedValue.ToString();
            try
            {
                this.BODETableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.BODETableAdapter.Fill(this.DS_BODE.BODE, mamh);
                
                if (listOfIndex.TryGetValue(mamh, out int currentIndex))
                {
                    index = currentIndex;
                }
                else 
                {
                    listOfIndex.Add(mamh, 0);
                    index = 0;
                }

                if(listOfUndoStack.TryGetValue(mamh, out  MyStack currentUndoStack))
                {
                    UndoStack = currentUndoStack;
                    this.UndoStack.TriggerEvent();
                }
                else
                {
                    this.UndoStack = new MyStack();
                    listOfUndoStack.Add(mamh, UndoStack);
                    this.UndoStack.StackChange += UndoStackChange;
                    this.UndoStack.TriggerEvent();
                }

               if(listOfRedoStack.TryGetValue(mamh, out  MyStack currentRedoStack))
                {
                    RedoStack = currentRedoStack;
                    this.RedoStack.TriggerEvent();
                }
                else
                {
                    this.RedoStack = new MyStack();
                    listOfRedoStack.Add(mamh, RedoStack);
                    this.RedoStack.StackChange += RedoStackChange;
                    this.RedoStack.TriggerEvent();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi tải câu hỏi\n"+ex.Message);
            }
            finally
            {
                if(bdsBoDe.Count == 0)
                    btnHieuChinh.Enabled = btnXoa.Enabled=false;
                else   if (((DataRowView)bdsBoDe.Current).Row["ISUSED"].ToString().Equals("True")
                    || !((DataRowView)bdsBoDe.Current).Row["MAGV"].ToString().Trim().Equals(Data.username))
                {
                    btnHieuChinh.Enabled = false;
                    btnXoa.Enabled = false;
                }
                else btnHieuChinh.Enabled = btnXoa.Enabled = true;
                if (Data.mGroup.Equals("TRUONG")) btnThem.Enabled = false;
                //UndoStack.Clear();
                //RedoStack.Clear();
            }
        }
        // Khi thoát đóng form
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Tải lại dư liệu mỗi khi reload:
        ///     Kiểm tra xem môn học đã được tải trước đó chưa. Nếu đã được tải thì sẽ reload lại sao cho tải được danh sách môn học.
        ///     Sau khi có danh sách môn mới tải câu hỏi lên.
        ///     Trường hợp reload môn học rồi reload câu hỏi thì sẽ làm thay vị trí hiện tại của combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cmbMonHoc.DataSource == null)
            {
                try
                {
                    this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    this.MONHOCTableAdapter.Fill(this.DS_BODE.MONHOC);
                    this.DS_BODE.EnforceConstraints = false;
                }
                catch
                {
                    MessageBox.Show("Không thể tải dữ liệu");
                    btnThem.Enabled = btnXoa.Enabled =
                        btnHieuChinh.Enabled = btnPhucHoi.Enabled =
                        btnRedo.Enabled = btnGhi.Enabled = false;
                    return;
                }
            }
            cmbMonHoc_SelectedIndexChanged(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.bdsBoDe.CancelEdit();
            HidePanelEdit(true);
            this.bdsBoDe.Position = vitri;
            if (bdsBoDe.Count == 0)
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            else if (((DataRowView)bdsBoDe.Current).Row["ISUSED"].ToString().Equals("True")
                || !((DataRowView)bdsBoDe.Current).Row["MAGV"].ToString().Trim().Equals(Data.username))
            {
                btnHieuChinh.Enabled = false;
                btnXoa.Enabled = false;
            }
            //btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = true;
            //Kiểm tra thử cho reload, ghi, thoát,chuyển môn ko
            //   UndoStackChange();
            btnXong.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Kiểm tra câu hỏi mới thêm hay không.
            if (!((DataRowView)bdsBoDe.Current)["CAUHOI"].ToString().Equals(""))
            {
                    int check = Data.ExecuteScalar("SELECT dbo.UDF_KIEMTRA_SO_CH(" + ((DataRowView)bdsBoDe.Current)["CAUHOI"].ToString() + ")",Data.ServerConnection);
                    if (check == 1)
                    {
                        MessageBox.Show("Câu hỏi đã thi, không thể xóa");
                        return;
                    }
                    if(check == 2)
                    {
                        MessageBox.Show("Không thể xóa vì số câu hỏi không đủ để thi");
                        return;
                    }
            }

            currentDataRow = ((DataRowView)bdsBoDe.Current).Row;

            UndoStack.Push(ActionState.DELETED,currentDataRow.ItemArray);
            RedoStack.Clear();
            bdsBoDe.RemoveCurrent();
            //trường hợp phục hồi dẫn tới không còn dòng nào nữa
            if (bdsBoDe.Count == 0)
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.BODETableAdapter.Fill(this.DS_BODE.BODE, mAMHToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Khi nhấn hủy ta sẽ hủy đi edit nếu đang chỉnh sửa hoặc xóa dòng đó nếu đang thêm mới.
        /// Ẩn panel đi
        /// Kiểm tra sau khi hủy còn câu hỏi nào không. Nếu không thì không cho thêm xóa sửa gì cả. Nếu có kiểm tra vị trí hiện tại có phải câu hỏi của giáo viên đó không.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.bdsBoDe.CancelEdit();///Chú ý
            HidePanelEdit(true);
            this.bdsBoDe.Position = vitri;
            if (bdsBoDe.Count == 0)
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            else if (((DataRowView)bdsBoDe.Current).Row["ISUSED"].ToString().Equals("True")
                || !((DataRowView)bdsBoDe.Current).Row["MAGV"].ToString().Trim().Equals(Data.username))
            {
                btnHieuChinh.Enabled = false;
                btnXoa.Enabled = false;
            }
            else btnXoa.Enabled = btnHieuChinh.Enabled = true;
            if (Data.mGroup.Equals("TRUONG")) btnThem.Enabled = false;
            else btnThem.Enabled = true;
            //Kiểm tra thử cho reload, ghi, thoát,chuyển môn ko
            UndoStackChange();
            //bật lên khi trường hợp người dùng nhấn nút hiệu chỉnh nhưng câu đó đã thi nên không cho hiệu chỉnh-> disable nút xong
            btnXong.Enabled = true;
        }

        private void checkGV_BD_CheckedChanged(object sender, EventArgs e)
        {
            if(checkGV_BD.Checked)
            {
                try
                {
                 bdsBoDe.Filter = "MAGV = '" + Data.username+"'";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                    return;
                }
            }
            else
            {
                bdsBoDe.RemoveFilter();
            }
        }
        private String calKey(Object[] objects)
        {
            String[] keyValue = Array.ConvertAll(objects.ToArray(), x => x.ToString().Trim());
            String keyRow = String.Join(", ", keyValue);
            return keyRow;
        }
        private DataRow findByData(String key)
        {
            foreach ( DataRow item in DS_BODE.BODE.Rows)
            {
                if (item.RowState!=DataRowState.Deleted)
                {
                    String[] keyValue = Array.ConvertAll(item.ItemArray.Skip(1).ToArray(), x => x.ToString().Trim());
                    String keyRow = String.Join(", ", keyValue);
                    Console.WriteLine(keyRow);
                    if(keyRow == key)
                        return item;
                }
            }
            return null;
        }
        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UndoStack.getSize() == 0) return;
            action = UndoStack.Pop();
            DataRow data = findByData(action.key);
            try
            {
                switch (action.action)
                {
                    case ActionState.ADDED:

                        RedoStack.Push(ActionState.DELETED, action.objects);
                        if (data.RowState == DataRowState.Added)
                            data.RejectChanges();
                        else data.Delete();
                        
                        break;
                    case ActionState.MODIFIED:
                        RedoStack.Push(ActionState.MODIFIED, calKey(action.objects.Skip(1).ToArray()),data.ItemArray);
                        data.ItemArray = action.objects.ToArray();
                        break;
                    case ActionState.DELETED:
                        RedoStack.Push(ActionState.ADDED, calKey(action.objects.Skip(1).ToArray()), action.objects);
                        DS_BODE.BODE.Rows.Add(action.objects);
                        break;
                }
                //trường hợp phục hồi dẫn tới không còn dòng nào nữa
                if (bdsBoDe.Count == 0)
                    btnHieuChinh.Enabled = btnXoa.Enabled = false;
                //else btnHieuChinh.Enabled = btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi\n" + ex.Message);
            }
        }
        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (RedoStack.getSize() == 0) return;
            action = RedoStack.Pop();
            DataRow data = findByData(action.key);
            try
            {
                switch (action.action)
                {
                    case ActionState.ADDED:
                        UndoStack.Push(ActionState.DELETED, action.objects);
                        if(data.RowState == DataRowState.Added) {
                            data.RejectChanges();
                        }
                        else 
                            data.Delete();
                        break;
                    case ActionState.MODIFIED:
                        UndoStack.Push(ActionState.MODIFIED, calKey(action.objects.Skip(1).ToArray()), data.ItemArray);
                        data.ItemArray = action.objects.ToArray();
                        break;
                    case ActionState.DELETED:
                        UndoStack.Push(ActionState.ADDED,calKey(action.objects.Skip(1).ToArray()), action.objects);
                        DS_BODE.BODE.Rows.Add(action.objects);
                        break;
                }
                //trường hợp phục hồi dẫn tới không còn dòng nào nữa
                if (bdsBoDe.Count == 0)
                    btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi\n" + ex.Message);
            }
        }
    }
}
