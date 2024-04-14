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
        private DataRow currentDataRow;
        Object[] previousData;
        private MyStack UndoStack;
        private MyStack RedoStack;
        private String mamh;
        private int index;
        private int vitri;
        private Action action;
        private SqlCommand cmd;
        private SqlParameter parameter;
        public formBoDe()
        {
            InitializeComponent();
        }

        private void formBoDe_Load(object sender, EventArgs e)
        {
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.DS_BODE.MONHOC);
            this.DS_BODE.EnforceConstraints = false;
            this.HidePanelEdit(true);
            this.cmbMonHoc_SelectedIndexChanged(this, EventArgs.Empty);
            this.SetComboboxValue();
            //Khởi tạo 
            cmd = new SqlCommand();
            cmd.Connection = Program.conn;
            //stack
            this.UndoStack = new MyStack();
            this.UndoStack.StackChange += UndoStackChange;
            this.UndoStack.TriggerEvent();

            this.RedoStack = new MyStack();
            this.RedoStack.StackChange += RedoStackChange;
            this.RedoStack.TriggerEvent();
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
            cmbDapAn.SelectedIndex = 0;
        }
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
        private void HidePanelEdit(bool allow)
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
            this.HidePanelEdit(false);
            //Thêm dòng
            this.bdsBoDe.AddNew();
            //gán mã môn cho dòng
            ((DataRowView)(bdsBoDe.Current))["MAMH"] = cmbMonHoc.SelectedValue.ToString();

            ((DataRowView)(bdsBoDe.Current))["MAGV"] = Program.username;
            //Lúc thêm thì không cho các hành động khác trừ nút xong và hủy
            this.btnThem.Enabled = btnXoa.Enabled =btnGhi.Enabled= btnHieuChinh.Enabled=btnReload.Enabled = btnThoat.Enabled = btnPhucHoi.Enabled=false;
            this.cmbMonHoc.Enabled = false;

            speCauHoi.Value = 9999;                    
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
            currentDataRow["CAUHOI"] = speCauHoi.Value;
            try
            {
                //Xác nhận dòng đó đã edit xong
               bdsBoDe.EndEdit();

                // trường hợp không sửa gì
                if (currentDataRow.RowState == DataRowState.Unchanged)
                {
                    HidePanelEdit(true);
                    btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = true;
                    return;
                }
                 //1Thêm một dòng mới
                if (currentDataRow.RowState == DataRowState.Detached|| currentDataRow.RowState == DataRowState.Added)
                {
                    ((DataRowView)bdsBoDe.Current).Row["ISUSED"] = true;
                    UndoStack.Push(ActionState.ADDED, currentDataRow,currentDataRow.ItemArray);//lưu lại tham chiếu tới dòng đó
                   // DS_BODE.BODE.Rows.Add(currentDataRow);//added
                }
                //2 sửa
                else 
                {
                    UndoStack.Push(ActionState.MODIFIED,  currentDataRow,previousData);
                }
                RedoStack.Clear();
                HidePanelEdit(true);
                btnHieuChinh.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
            }
            catch (Exception ex)
            {
                    MessageBox.Show( ex.Message);
            }
            finally
            {
                currentDataRow = null;
              //  UndoStackChange();//Gọi để kiểm tra các nút thoát, reload,thoát,lưu
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.bdsBoDe.EndEdit();
                this.BODETableAdapter.Update(this.DS_BODE.BODE);
                index = this.UndoStack.getSize();
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

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBoDe.Position;
            previousData = ((DataRowView)bdsBoDe.Current).Row.ItemArray;
            //gán giá trị lại cho combobox
            cmbDapAn.SelectedItem = (String)((DataRowView)bdsBoDe.Current)["DAP_AN"];
            cmbTrinhDo.SelectedValue = ((String)((DataRowView)bdsBoDe.Current)["TRINHDO"]);
            
            HidePanelEdit(false);
            this.btnThem.Enabled = this.btnXoa.Enabled =  this.btnHieuChinh.Enabled =
                 this.btnPhucHoi.Enabled = this.btnReload.Enabled = btnGhi.Enabled=this.btnThoat.Enabled = false;
        }

      

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.SelectedValue == null) return;
            mamh = cmbMonHoc.SelectedValue.ToString();
            try
            {
                this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
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
                else btnHieuChinh.Enabled = btnXoa.Enabled = true;
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

            UndoStack.Push(ActionState.DELETED, currentDataRow, currentDataRow.ItemArray);
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
        
        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.bdsBoDe.CancelEdit();
            HidePanelEdit(true);
            this.bdsBoDe.Position = vitri;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = true;
            //Kiểm tra thử cho reload, ghi, thoát,chuyển môn ko
         //   UndoStackChange();
        }

        private void checkGV_BD_CheckedChanged(object sender, EventArgs e)
        {
            if(checkGV_BD.Checked)
            {
                try
                {
                 bdsBoDe.Filter = "MAGV = '" + Program.username+"'";
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
        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UndoStack.getSize() == 0) return;
            action = UndoStack.Pop();
            try
            {
                switch (action.action)
                {
                    case ActionState.ADDED:
                        RedoStack.Push(ActionState.DELETED, action.data, action.objects);
                        if (action.data.RowState == DataRowState.Added)
                            action.data.RejectChanges();
                        else action.data.Delete();
                        
                        break;
                    case ActionState.MODIFIED:
                        RedoStack.Push(ActionState.MODIFIED, action.data, action.data.ItemArray);
                        action.data.ItemArray = action.objects.ToArray();
                        break;
                    case ActionState.DELETED:
                        RedoStack.Push(ActionState.ADDED, action.data, action.objects);
                        //xóa trên dòng củ
                        if (action.data.RowState == DataRowState.Deleted)
                        {
                            action.data.RejectChanges();
                            action.data.ItemArray = action.objects.ToArray();
                        }
                        else
                        {
                            //xóa trên dòng mới
                            action.data.ItemArray = action.objects.ToArray();
                            DS_BODE.BODE.Rows.Add(action.data);
                        }
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
        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (RedoStack.getSize() == 0) return;
            action = RedoStack.Pop();
            try
            {
                switch (action.action)
                {
                    case ActionState.ADDED:
                        UndoStack.Push(ActionState.DELETED, action.data, action.objects);
                        if(action.data.RowState == DataRowState.Added) {
                            action.data.RejectChanges();
                        }
                        else 
                            action.data.Delete();
                        break;
                    case ActionState.MODIFIED:
                        UndoStack.Push(ActionState.MODIFIED, action.data, action.data.ItemArray);
                        action.data.ItemArray = action.objects.ToArray();
                        break;
                    case ActionState.DELETED:
                        UndoStack.Push(ActionState.ADDED, action.data, action.data.ItemArray);
                        //xóa trên dòng củ
                        if (action.data.RowState == DataRowState.Deleted)
                        {
                            action.data.RejectChanges();
                            action.data.ItemArray = action.objects.ToArray();
                        }
                        else
                        {
                            //xóa trên dòng mới
                            action.data.ItemArray = action.objects.ToArray();
                            DS_BODE.BODE.Rows.Add(action.data);
                        }
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
