using DevExpress.XtraPrinting.Native;
using System;
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
        private String mamh;
        private int vitri;
        private MyStack myStack;
        private Action action;
        private SqlCommand cmd;
        private SqlParameter parameter;
        private DataRow currentDataRow;
        public formBoDe()
        {
            InitializeComponent();
        }

        private void formBoDe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_BODE.MONHOC' table. You can move, or remove it, as needed.
            this.MONHOCTableAdapter.Fill(this.DS_BODE.MONHOC);
            //THITRACNGHIEM.DS_BODE.EnforceConstraints= false;
            this.hidePanelEdit(true);
            this.cmbMonHoc_SelectedIndexChanged(this, EventArgs.Empty);
            this.SetComboboxValue();
            //kết nối //tạm 
            Program.KetNoi();
            //Khởi tạo 
            cmd = new SqlCommand();
            cmd.Connection = Program.conn;

            //stack
            this.myStack = new MyStack();
            this.myStack.StackChange += StackChange;
            this.myStack.TriggerEvent();
        }
        //Hàm bổ trợ
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
        }
        private void StackChange()
        {
            //stack có thì cho ghi với phục hồi
            btnGhi.Enabled = btnPhucHoi.Enabled = (myStack.getSize() > 0);
            //stack có thì không cho reload với thoát để tránh mất dữ liệu
            btnReload.Enabled = btnThoat.Enabled = !(myStack.getSize() > 0);
            //stack có thì không cho chuyển môn để không mất môn học
            cmbMonHoc.Enabled = !(myStack.getSize() > 0);
        }
        private void hidePanelEdit(bool allow)
        {
            if (allow)
                this.panelEditCauHoi.Dock = DockStyle.None;
            else this.panelEditCauHoi.Dock = DockStyle.Bottom;
            panelEditCauHoi.Visible = !allow;
            gcBode.Enabled = allow;
        }
        //Hàm cho các sự kiện

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Lưu lại vị trí
            this.vitri = bdsBoDe.Position;
            //Hiện ra panel để edit
            this.hidePanelEdit(false);
            //Thêm dòng
            this.bdsBoDe.AddNew();
            //gán mã môn cho dòng
            ((DataRowView)(bdsBoDe.Current))["MAMH"] = cmbMonHoc.SelectedValue.ToString();
            //((DataRowView)(bdsBoDe.Current))["MAGV"] = Program.username;
            ((DataRowView)(bdsBoDe.Current))["MAGV"] = "TH123";//tạm
            //Lúc thêm thì không cho các hành động khác trừ nút xong và hủy
            this.btnThem.Enabled = btnXoa.Enabled =btnGhi.Enabled= btnHieuChinh.Enabled=btnReload.Enabled = btnThoat.Enabled = btnPhucHoi.Enabled=false;
            this.cmbMonHoc.Enabled = false;
            //cho chỉnh sửa phần câu hỏi
            speCauHoi.Enabled = true;
            //đề xuất Câu thứ bao nhiêu tạm
            int addedRowCount = 0;
            foreach (DataRow row in DS_BODE.BODE.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    addedRowCount++;
                }
            }

            try
            {
                cmd.CommandText = "select dbo.UDF_DEXUAT_CAUHOI()";
                cmd.Parameters.Clear();
                speCauHoi.Value =(int)this.cmd.ExecuteScalar()+addedRowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu\n" + ex.Message);
                hidePanelEdit(true);
                bdsBoDe.Position = vitri;
                return;
            }
                    
        }

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
            if(speCauHoi.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập câu hỏi thứ?");
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
            Object[] previousData = currentDataRow.ItemArray;
            //thêm filed
            currentDataRow["TRINHDO"] = cmbTrinhDo.SelectedValue.ToString();
            currentDataRow["DAP_AN"] = cmbDapAn.SelectedItem.ToString();
            currentDataRow["CAUHOI"] = speCauHoi.Value;
            try
            {
                //Xác nhận dòng đó đã edit xong
                currentDataRow.EndEdit();
                //6 trường hợp:
                //0 Không thay đổi gì cả
                // 1. Thêm mới hoàn toàn-> lưu vào stack
                // 2. Hiệu chỉnh trên dòng vừa thêm-> không lưu vào stack
                // 3. Hiệu chỉnh trên dòng củ-> lưu vào stack
                // 4. Xóa trên dòng vừa thêm -> lưu vào stack
                // 5. Xóa trên dòng củ-> lưu vào stack

                // trường hợp không sửa gì
                if (currentDataRow.RowState == DataRowState.Unchanged)
                {
                    hidePanelEdit(true);
                    btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = true;
                    return;
                }
                 //1Thêm một dòng mới
                if (currentDataRow.RowState == DataRowState.Detached)
                {
                    myStack.Push(Action.ADDED, (DataRowView) bdsBoDe.Current);//lưu lại tham chiếu tới dòng đó
                    DS_BODE.BODE.Rows.Add(currentDataRow);//added
                }
                //2sửa trên dòng mới thêm
                else if(currentDataRow.RowState == DataRowState.Added)
                {

                }
                //3 sửa giá trị
                else if(currentDataRow.RowState == DataRowState.Modified)
                {
                    myStack.Push(Action.MODIFIED, (DataRowView)bdsBoDe.Current,previousData);
                }
                hidePanelEdit(true);
                btnHieuChinh.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
            }
            catch (Exception ex)
            {
                    MessageBox.Show( ex.Message);
            }
            finally
            {
                currentDataRow = null;
                StackChange();//Gọi để kiểm tra các nút thoát, reload,thoát,lưu
                //hidePanelEdit(true);
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.bdsBoDe.EndEdit();
                this.BODETableAdapter.Update(this.DS_BODE.BODE);
                this.myStack.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ghi câu hỏi thất bại\n" + ex.Message);
                bdsBoDe.Position = vitri;
            }
            finally
            {
                btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = true;
            }
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBoDe.Position;
            //Nếu sửa câu đã có thì không cho sửa mã câu và kiểm tra câu đó đã thi hay chưa
            if (((DataRowView)bdsBoDe.Current).Row.RowState != DataRowState.Added)
            {
                //kiểm tra xóa dc ko
                try
                {
                    cmd.CommandText = "SELECT dbo.UDF_KIEMTRA_CH_DATHI(@cauhoi)";
                    cmd.Parameters.Clear();
                    parameter = cmd.Parameters.AddWithValue("@cauhoi", (int)speCauHoi.Value);
                    if ((int)this.cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("Câu hỏi đã được thi không thể sửa");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu\n" + ex.Message);
                    return;
                }
                speCauHoi.Enabled = false;//chú ý
            }
            else speCauHoi.Enabled = true;

            //gán giá trị lại cho combobox
            cmbDapAn.SelectedItem = (String)((DataRowView)bdsBoDe.Current)["DAP_AN"];
            cmbTrinhDo.SelectedValue = ((String)((DataRowView)bdsBoDe.Current)["TRINHDO"]);
            
            hidePanelEdit(false);
            this.btnThem.Enabled = this.btnXoa.Enabled =  this.btnHieuChinh.Enabled =
                 this.btnPhucHoi.Enabled = this.btnReload.Enabled = btnGhi.Enabled=this.btnThoat.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (myStack.getSize() == 0) return;
            action = myStack.Pop();
            try
            {
                switch (action.action)
                {
                    case 1://thêm nên giờ xóa
                        //Bỏ đi dòng mới thêm
                        // Added => Detached
                        action.data.Row.RejectChanges();
                        break;
                    case 2://sửa nên giờ phục hồi lại
                        //Phục hồi trên dòng củ modifed=>unchage
                        action.data.Row.RejectChanges();
                        action.data.Row.ItemArray = action.objects.ToArray();
                        action.data.Row.AcceptChanges();
                        break;
                    case 4:
                        //Phục hồi từ delete => unchage
                        //còn trường hợp modified rồi delete => delete=>modify=> unchage
                        action.data.Row.RejectChanges();
                        action.data.Row.AcceptChanges();
                        break;
                    case 5:
                        // Phục hồi khi xóa dòng vừa thêm
                        //khôi phục lại dữ liệu cho dòng bị xóa
                        action.data.Row.ItemArray = action.objects.ToArray();
                        DS_BODE.BODE.Rows.Add(action.data.Row);
                        break;
                    case 6:
                        // Phục hồi từ delete=> modified
                        //phục hồi 
                        action.data.Row.RejectChanges();
                        //đưa dữ liệu trở lại
                        action.data.Row.ItemArray = action.objects.ToArray();
                        break;
                }
                //trường hợp phục hồi dẫn tới không còn dòng nào nữa
                if (bdsBoDe.Count == 0)
                    btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi\n"+ex.Message);
            }
        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.SelectedValue == null) return;
            mamh = cmbMonHoc.SelectedValue.ToString();
            try
            {
                this.BODETableAdapter.Fill(this.DS_BODE.BODE, mamh);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi tải câu hỏi\n"+ex.Message);
            }
            finally
            {
                if(bdsBoDe.Count == 0)
                    btnHieuChinh.Enabled = btnXoa.Enabled=false;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cmbMonHoc_SelectedIndexChanged(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            bdsBoDe.CancelEdit();
            bdsBoDe.Position = vitri;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            currentDataRow = ((DataRowView)bdsBoDe.Current).Row;
            //4 Xóa trên dòng vừa thêm
            if(currentDataRow.RowState == DataRowState.Added)
            {
                //lưu lại dữ liệu và con trỏ chỉ vào dòng đó
                myStack.Push(Action.DELETED_NEW_ROW, ((DataRowView)bdsBoDe.Current), currentDataRow.ItemArray);
                //Xóa câu hỏi vừa thêm vào
                currentDataRow.RejectChanges();
            }
            else
            {
            //kiểm tra xóa dc ko
                try
                {
                    cmd.CommandText = "SELECT dbo.UDF_KIEMTRA_CH_DATHI(@cauhoi)";
                    cmd.Parameters.Clear();
                    parameter = cmd.Parameters.AddWithValue("@cauhoi", (int)speCauHoi.Value);
                    if ((int)this.cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("Câu hỏi đã được thi không thể xóa");
                        return;     
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu\n" + ex.Message);
                    return;
                }
                //sửa rồi xóa trên dòng đã có trước đó nhưng đã sửa đổi
                if (currentDataRow.RowState == DataRowState.Modified)
                        myStack.Push(Action.DELETED_MODIFIED_ROW,(DataRowView)bdsBoDe.Current,currentDataRow.ItemArray);
                //xóa trên  dòng đã có
                else
                    myStack.Push(Action.DELETED,(DataRowView)bdsBoDe.Current);
                
            //set trạng thái đã delete
                bdsBoDe.RemoveCurrent();
            }
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
        
        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.bdsBoDe.CancelEdit();
            hidePanelEdit(true);
            this.bdsBoDe.Position = vitri;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = true;
            //Kiểm tra thử cho reload, ghi, thoát,chuyển môn ko
            StackChange();
        }

        private void checkGV_BD_CheckedChanged(object sender, EventArgs e)
        {
            if(checkGV_BD.Checked)
            {
                bdsBoDe.Filter = "MAGV = " + Program.username;
            }
            else
            {
                bdsBoDe.RemoveFilter();
            }
        }
    }
}
