using DevExpress.CodeParser;
using DevExpress.Utils.Win.Hook;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using THITRACNGHIEM.DSChuanBiThiTableAdapters;
using WindowsFormsApp1;

namespace THITRACNGHIEM
{
    public partial class formChuanBiThi : Form
    {
        private int vitri;

        // stateGhi = "hieuchinh" thì nút ghi xử lý cho trường hợp hiệu chỉnh
        // stateGhi = "them" thì nút ghi xử lý cho trường hợp thêm
        private String stateGhi;

        // dùng để kiểm tra xem khi hiệu chỉnh có thay đổi trinhdo, monhoc hay socauhoi không, nếu có phải điều
        // chỉnh lại table ct_gv_dk
        private String trinhdo;
        private int socauhoi;
        private String mamh;
        private UndoManagerWithSubBds undoManager;
        private TrangThaiGhi trangThaiGhi;

        //Lưu giá trị cũ trước khi edit để thực hiện việc hồi phục
        private object[] oldRowItemArray;
        private List<object[]> listRowItemArray = new List<object[]>();
        public formChuanBiThi()
        {
            InitializeComponent();
        }

        private void formChuanBiThi_Load(object sender, EventArgs e)
        {
            Data.ExecSqlNonQueryByServerConnection("SET IDENTITY_INSERT GIAOVIEN_DANGKY ON");
            dSChuanBiThi.EnforceConstraints = false;

            this.GIAOVIENTableAdapter1.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIENTableAdapter1.Fill(this.dSChuanBiThi.GIAOVIEN);

            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSChuanBiThi.GIAOVIEN_DANGKY);

            this.CT_GVDKTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.CT_GVDKTableAdapter.Fill(this.dSChuanBiThi.CT_GVDK);


            this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.MONHOCTableAdapter.Fill(this.dSChuanBiThi.MONHOC);

            this.LOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.LOPTableAdapter.Fill(this.dSChuanBiThi.LOP);

            this.cmbCoSo.DataSource = Data.bds_dspm;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            this.cmbCoSo.SelectedIndex = Data.mCoSo;

            if (Data.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
            }
            else
            {
                cmbCoSo.Enabled = false;
            }

            undoManager = new UndoManagerWithSubBds();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stateGhi = "ghi";

            pcGV_DK.Enabled = true;
            bdsGiaoVienDangKy.AddNew();
            vitri = bdsGiaoVienDangKy.Position;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcGV_DK.Enabled = false;
            trangThaiGhi = TrangThaiGhi.them;
        }

        private void gIAOVIEN_DANGKYGridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Data.ExecSqlNonQueryByServerConnection($"EXEC SP_CheckDotThiDaThi @mamh = {cmbMonHoc.SelectedValue}, @malop = {cmbLop.SelectedValue}, @lan = {cmbLanThi.SelectedItem}") != 0)
            {
                return;
            }
            stateGhi = "hieuchinh";
            socauhoi = int.Parse(spinEditSoCauThi.Value.ToString());
            trinhdo = cmbTrinhDo.Text;
            mamh = cmbMonHoc.Text;
            vitri = bdsGiaoVienDangKy.Position;
            pcGV_DK.Enabled = true;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcGV_DK.Enabled = false;
            trangThaiGhi = TrangThaiGhi.hieuchinh;
            DataRowView oldRow = (DataRowView)bdsGiaoVienDangKy.Current;
            oldRowItemArray = oldRow.Row.ItemArray;

            // Duyệt qua từng DataRowView trong bds
            listRowItemArray.Clear();
            foreach (DataRowView rowView in bdsCT_GVDK)
            {
                // Lấy ItemArray của mỗi hàng và thêm vào danh sách
                listRowItemArray.Add(rowView.Row.ItemArray);
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pcGV_DK.Enabled == true)
            {
                try
                {
                    bdsGiaoVienDangKy.CancelEdit();
                    this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSChuanBiThi.GIAOVIEN_DANGKY);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể reload lại dữ liệu \n {ex}", "", MessageBoxButtons.OK);
                }
                bdsGiaoVienDangKy.Position = vitri;
            }
            else
            {
                RowData lastAction = undoManager.GetUndoStack().Pop();
                switch (lastAction.ActionType) {
                    case ActionType.Add:
                        DataRowView addRowView = null;
                        int j = 0;
                        foreach (DataRowView rowView in bdsGiaoVienDangKy)
                        {
                            object[] trimmedRowItemArray = rowView.Row.ItemArray.Take(rowView.Row.ItemArray.Length - 1).Select(item => item.ToString().Trim()).ToArray();
                            object[] trimmedRowArrayItem = lastAction.RowItemArray.Take(rowView.Row.ItemArray.Length - 1).Select(item => item.ToString().Trim()).ToArray();

                            if (Enumerable.SequenceEqual(trimmedRowItemArray, trimmedRowArrayItem))
                            {
                                bdsGiaoVienDangKy.Position = j;
                                addRowView = rowView;
                                break;
                            }
                            j++;
                        }
                        if (addRowView != null)
                        {
                            List<object[]> listRowItemArrayCopy = lastAction.ListRowItemArray.ConvertAll(rowItemArray =>
                            {
                                // Tạo một bản sao của mảng đối tượng hiện tại
                                object[] newRowItemArray = new object[rowItemArray.Length];
                                Array.Copy(rowItemArray, newRowItemArray, rowItemArray.Length);
                                return newRowItemArray;
                            }); 

                            foreach (DataRowView rowview in bdsCT_GVDK)
                            {
                                bdsCT_GVDK.Remove(rowview);
                            }
                            bdsCT_GVDK.EndEdit();
                           
                            bdsGiaoVienDangKy.Remove(addRowView);
                            bdsGiaoVienDangKy.EndEdit();
                            CT_GVDKTableAdapter.Update(dSChuanBiThi.CT_GVDK);
                            GIAOVIEN_DANGKYTableAdapter.Update(dSChuanBiThi.GIAOVIEN_DANGKY);
                          
                        }
                        break;
                    case ActionType.Delete:
                        DataRowView deletedRowView = (DataRowView)bdsGiaoVienDangKy.AddNew();
                        vitri = bdsGiaoVienDangKy.Position;
                        deletedRowView.Row.ItemArray = lastAction.RowItemArray;
                        bdsGiaoVienDangKy.EndEdit();
                        bdsGiaoVienDangKy.ResetCurrentItem();
                        GIAOVIEN_DANGKYTableAdapter.Update(dSChuanBiThi.GIAOVIEN_DANGKY);
                        bdsGiaoVienDangKy.Position = vitri;
                        DataRowView currentRow = (DataRowView)bdsGiaoVienDangKy.Current;
                        int id_ctdk = int.Parse(currentRow["ID_CTDK"].ToString());
                        Console.WriteLine("ctdk: " + id_ctdk);
                        foreach (object[] rowItemArray in lastAction.ListRowItemArray)
                        {
                            DataRowView newRowView = (DataRowView)bdsCT_GVDK.AddNew();
                            newRowView.Row.ItemArray = rowItemArray;
                            newRowView.Row["ID_CTDK"] = id_ctdk;
                            bdsCT_GVDK.EndEdit();
                            bdsCT_GVDK.ResetCurrentItem();
                        }

                        CT_GVDKTableAdapter.Update(dSChuanBiThi.CT_GVDK);

                      
                        break;
                    case ActionType.Edit:
                        DataRowView editedRowView = null;
                        int i = 0;

                        foreach (DataRowView rowView in bdsGiaoVienDangKy)
                        {
                            object[] trimmedRowItemArray = rowView.Row.ItemArray.Take(rowView.Row.ItemArray.Length - 1).Select(item => item.ToString().Trim()).ToArray();
                            object[] trimmedRowArrayItem = lastAction.EditedRowItemArray.Take(rowView.Row.ItemArray.Length - 1).Select(item => item.ToString().Trim()).ToArray();

                            if (Enumerable.SequenceEqual(trimmedRowItemArray, trimmedRowArrayItem))
                            {
                                bdsGiaoVienDangKy.Position = i;
                                editedRowView = rowView;
                                break;
                            }
                            i++;
                        }
                        int idctdk = int.Parse(editedRowView["ID_CTDK"].ToString());
                        if (editedRowView != null)
                        {
                            int k = 0;
                            // gán lại tất cả giá trị cũ trừ cho dòng đã chỉnh sửa trừ cột ID_CTDK
                            foreach (DataColumn column in editedRowView.Row.Table.Columns)
                            {
                                DataRow row = editedRowView.Row;
                                if (column.ColumnName.ToString() != "ID_CTDK")
                                {
                                    row[column] = lastAction.RowItemArray[k];
                                }
                                k++;
                            }
                            bdsGiaoVienDangKy.EndEdit();
                            GIAOVIEN_DANGKYTableAdapter.Update(dSChuanBiThi.GIAOVIEN_DANGKY);

                            //clear ct_gvdk mới
                            foreach (DataRowView rowview in bdsCT_GVDK)
                            {
                                bdsCT_GVDK.Remove(rowview);
                            }

                            // thêm lại ct_gvdk cũ vào
                            foreach (object[] rowItemArray in lastAction.ListRowItemArray)
                            {
                                DataRowView newRowView = (DataRowView)bdsCT_GVDK.AddNew();
                                newRowView.Row.ItemArray = rowItemArray;
                                newRowView.Row["ID_CTDK"] = idctdk;
                            }
                            bdsCT_GVDK.EndEdit();
                            CT_GVDKTableAdapter.Update(dSChuanBiThi.CT_GVDK);
                        }
                        break;
                }
            }
            gcGV_DK.Enabled = true;
            pcGV_DK.Enabled = false;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            if (undoManager.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
            else btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (cmbLop.SelectedIndex < 0)
            {
                MessageBox.Show("Tên lớp không hợp lệ!", "", MessageBoxButtons.OK);
                cmbLop.Focus();
                return;
            }
            if (cmbMonHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Tên môn học không hợp lệ!", "", MessageBoxButtons.OK);
                cmbMonHoc.Focus();
                return;
            }
            if (cmbGiaoVien.SelectedIndex < 0)
            {
                MessageBox.Show("Tên giáo viên không hợp lệ!", "", MessageBoxButtons.OK);
                cmbGiaoVien.Focus();
                return;
            }
            if (dateNgayThi.EditValue.ToString() == "")
            {
                MessageBox.Show("Ngày thi không hợp lệ!", "", MessageBoxButtons.OK);
                dateNgayThi.Focus();
                return;
            }
            if (spinEditThoiGianThi.Value < 2 || spinEditThoiGianThi.Value > 60)
            {
                MessageBox.Show("Thời gian thi không hợp lệ!", "", MessageBoxButtons.OK);
                spinEditThoiGianThi.Focus();
                return;
            }
            if (spinEditSoCauThi.Value < 10 || spinEditSoCauThi.Value > 100)
            {
                MessageBox.Show("Số câu thi không hợp lệ!", "", MessageBoxButtons.OK);
                spinEditThoiGianThi.Focus();
                return;
            }
            if (cmbLanThi.SelectedIndex < 0)
            {
                MessageBox.Show("Lần thi không hợp lệ!", "", MessageBoxButtons.OK);
                spinEditThoiGianThi.Focus();
                return;
            }
            // Nếu lần thi = 2, kiểm tra đã có lần thi = 1 hay chưa
            if (cmbLanThi.SelectedIndex == 1)
            {
                int count = 0;
                for (int i = 0; i < gvGV_DK.RowCount; i++)
                {
                    // Lấy dữ liệu từng hàng
                    var row = gvGV_DK.GetRow(i) as DataRowView;
                    if (i == gvGV_DK.FocusedRowHandle)
                        continue; // Bỏ qua dòng đang được tập trung
                    if (row != null)
                    {
                        if (row["MAMH"].ToString() == cmbMonHoc.SelectedValue.ToString()
                            && row["MALOP"].ToString() == cmbLop.SelectedValue.ToString()
                            && int.Parse(row["LAN"].ToString()) == 1)
                        {
                            count++;
                        }
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("Chưa thi lần 1", "", MessageBoxButtons.OK);
                    return;
                }
            }

            // Kiểm tra monhoc, lanthi, lop đã tồn tại hay chưa
            for (int i = 0; i < gvGV_DK.RowCount; i++)
            {
                // Lấy dữ liệu từng hàng
                var row = gvGV_DK.GetRow(i) as DataRowView;
                if (i == gvGV_DK.FocusedRowHandle)
                    continue; // Bỏ qua dòng đang được tập trung
                if (row != null)
                {
                    if (row["MAMH"].ToString() == cmbMonHoc.SelectedValue.ToString()
                        && row["MALOP"].ToString() == cmbLop.SelectedValue.ToString()
                        && row["LAN"].ToString() == cmbLanThi.SelectedItem.ToString()
                        )
                    {
                        MessageBox.Show("Mã MH, Mã lớp, Lần thi không là duy nhất", "", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            if (stateGhi == "ghi")
            {
                string lenh = $"EXEC SP_CREATEDANGKYTHI '{cmbGiaoVien.SelectedValue}', '{cmbMonHoc.SelectedValue}', '{cmbLop.SelectedValue}', " +
                    $"'{cmbTrinhDo.Text}', '{dateNgayThi.EditValue}', {cmbLanThi.SelectedItem}, {spinEditSoCauThi.Value}, {spinEditThoiGianThi.Value}";
                Console.WriteLine(lenh);
                if (Data.ExecSqlNonQueryByServerConnection(lenh) == 0)
                {
                    this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    this.GIAOVIEN_DANGKYTableAdapter.Fill(dSChuanBiThi.GIAOVIEN_DANGKY);
                    this.CT_GVDKTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    this.CT_GVDKTableAdapter.Fill(dSChuanBiThi.CT_GVDK);
                    bdsGiaoVienDangKy.Position = vitri;
                    DataRowView addedRow = (DataRowView)bdsGiaoVienDangKy.Current;
                    object[] addedRowArrayItem = addedRow.Row.ItemArray;
                    undoManager.AddNewRecord(addedRowArrayItem);
                    if (undoManager.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
                    else btnPhucHoi.Enabled = true;
                }
                else return;

            }
            else
            {
                // Nếu đã thay đổi trình độ, số câu hỏi, mã mh
                if (!string.Equals(trinhdo.Trim(), cmbTrinhDo.SelectedItem.ToString().Trim(), StringComparison.OrdinalIgnoreCase)
                    || socauhoi != spinEditSoCauThi.Value
                    || !string.Equals(mamh.Trim(), cmbMonHoc.SelectedItem.ToString().Trim(), StringComparison.OrdinalIgnoreCase)
                    )
                {
                    if (Data.ServerConnection.State == ConnectionState.Closed) Data.ServerConnection.Open();
                    SqlTransaction transaction = Data.ServerConnection.BeginTransaction();
                    try
                    {
                        String stringSuaGVDK =
                            $"UPDATE GIAOVIEN_DANGKY SET [MAGV] = '{cmbGiaoVien.SelectedValue}', [MAMH] = '{cmbMonHoc.SelectedValue}', " +
                            $"[MALOP] = '{cmbLop.SelectedValue}', [TRINHDO] = '{cmbTrinhDo.SelectedItem}', [NGAYTHI] = '{dateNgayThi.EditValue}'," +
                            $" [LAN] = {cmbLanThi.SelectedItem}, [SOCAUTHI] = {spinEditSoCauThi.Value}, [THOIGIAN] = {spinEditThoiGianThi.Value} " +
                            $"WHERE [ID_CTDK] = {txtID_CTDK.Text}";
                        // Tạo đối tượng SqlCommand và gắn kết nối và Transaction
                        using (SqlCommand commandSuaGVDK = new SqlCommand(stringSuaGVDK, Data.ServerConnection))
                        using (SqlCommand commandDeleteCT_GVDK = new SqlCommand($"DELETE FROM CT_GVDK WHERE ID_CTDK = {txtID_CTDK.Text}", Data.ServerConnection))
                        using (SqlCommand commandAddNewCT_GVDK = new SqlCommand("SP_INSERT_CT_GVDK", Data.ServerConnection))
                        {
                            commandDeleteCT_GVDK.Transaction = transaction;
                            commandDeleteCT_GVDK.CommandType = CommandType.Text;
                            commandAddNewCT_GVDK.Transaction = transaction;
                            commandAddNewCT_GVDK.CommandType = CommandType.StoredProcedure;
                            commandSuaGVDK.Transaction = transaction;
                            commandSuaGVDK.CommandType = CommandType.Text;

                            commandSuaGVDK.ExecuteNonQuery();
                            commandDeleteCT_GVDK.ExecuteNonQuery();

                            commandAddNewCT_GVDK.Parameters.Add("@ID_CTDK", SqlDbType.Int).Value = int.Parse(txtID_CTDK.Text);
                            commandAddNewCT_GVDK.Parameters.Add("@ERROR", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                            commandAddNewCT_GVDK.ExecuteNonQuery();
                            // 0 LA KHONG CO LOI, 1 LA LOI KHONG DU SO LUONG CAU HOI CUNG TRINH DO, 2 LA KO DU SO LUONG CAU HOI
                            int returnValue = int.Parse(commandAddNewCT_GVDK.Parameters["@ERROR"].Value.ToString());
                            Console.WriteLine(returnValue);
                            if (returnValue == 1)
                            {
                                MessageBox.Show("Số lượng cùng trình độ không đủ câu hỏi không đủ", "", MessageBoxButtons.OK);
                                transaction.Rollback();
                                Data.ServerConnection.Close();
                                return;
                            }
                            if (returnValue == 2)
                            {
                                MessageBox.Show("Số lượng câu hỏi không đủ", "", MessageBoxButtons.OK);
                                transaction.Rollback();
                                Data.ServerConnection.Close();
                                return;
                            }

                            // Nếu các thao tác thành công, thì commit Transaction
                            transaction.Commit();

                            Console.WriteLine("Transaction đã được commit.");
                            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSChuanBiThi.GIAOVIEN_DANGKY);
                            this.CT_GVDKTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                            this.CT_GVDKTableAdapter.Fill(this.dSChuanBiThi.CT_GVDK);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi xảy ra, thì huỷ bỏ Transaction
                        transaction.Rollback();

                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                    finally
                    {
                        // Đóng kết nối sau khi sử dụng
                        Data.ServerConnection.Close();
                    }
                }
                else
                {
                    bdsGiaoVienDangKy.EndEdit();
                    bdsGiaoVienDangKy.ResetCurrentItem();
                    this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    this.GIAOVIEN_DANGKYTableAdapter.Update(this.dSChuanBiThi.GIAOVIEN_DANGKY);
                }
                bdsGiaoVienDangKy.Position = vitri;
                DataRowView addedRow = (DataRowView)bdsGiaoVienDangKy.Current;
                object[] addedRowArrayItem = addedRow.Row.ItemArray;
                List<object[]> listRowItemArrayCopy = listRowItemArray.ConvertAll(rowItemArray =>
                {
                    // Tạo một bản sao của mảng đối tượng hiện tại
                    object[] newRowItemArray = new object[rowItemArray.Length];
                    Array.Copy(rowItemArray, newRowItemArray, rowItemArray.Length);
                    return newRowItemArray;
                });
                undoManager.EditRecord(oldRowItemArray, addedRowArrayItem, listRowItemArrayCopy);
                if (undoManager.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
                else btnPhucHoi.Enabled = true;
            }
            gcGV_DK.Refresh();
            gcCT_DK.Refresh();
            gcGV_DK.Enabled = true;
            pcGV_DK.Enabled = false;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            GridView view = sender as GridView;
            if (view.GetRowCellValue(e.FocusedRowHandle, "TRINHDO") == null) return;
            string trinhdo = view.GetRowCellValue(e.FocusedRowHandle, "TRINHDO").ToString().ToUpper();
            cmbTrinhDo.SelectedItem = trinhdo;
            string lanthi = view.GetRowCellValue(e.FocusedRowHandle, "LAN").ToString();
            cmbLanThi.SelectedItem = lanthi;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Data.ExecSqlNonQueryByServerConnection($"EXEC SP_CheckDotThiDaThi @mamh = {cmbMonHoc.SelectedValue}, @malop = {cmbLop.SelectedValue}, @lan = {cmbLanThi.SelectedItem}") != 0)
            {
                return;
            }
            if (bdsGiaoVienDangKy.Count == 0)
            {
                MessageBox.Show("Không có đợt thi để xóa", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show
                ("Bạn có thật sự muốn xóa đợt thi này ??", "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                // Duyệt qua từng DataRowView trong bds
                listRowItemArray.Clear();
                foreach (DataRowView rowView in bdsCT_GVDK)
                {
                    // Lấy ItemArray của mỗi hàng và thêm vào danh sách
                    listRowItemArray.Add(rowView.Row.ItemArray);
                }
                DataRowView deletedRow = (DataRowView)bdsGiaoVienDangKy.Current;
                object[] deletedRowArrayItem = deletedRow.Row.ItemArray;
                List<object[]> listRowItemArrayCopy = listRowItemArray.ConvertAll(rowItemArray =>
                {
                    // Tạo một bản sao của mảng đối tượng hiện tại
                    object[] newRowItemArray = new object[rowItemArray.Length];
                    Array.Copy(rowItemArray, newRowItemArray, rowItemArray.Length);
                    return newRowItemArray;
                });
                undoManager.DeleteRecord(deletedRowArrayItem, listRowItemArrayCopy);
                if (Data.ExecSqlNonQueryByServerConnection($"EXEC SP_DELETEGV_DK {txtID_CTDK.Text}") == 0)
                {
                    if (undoManager.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
                    else btnPhucHoi.Enabled = true;
                    this.GIAOVIEN_DANGKYTableAdapter.Fill(dSChuanBiThi.GIAOVIEN_DANGKY);
                    this.CT_GVDKTableAdapter.Fill(dSChuanBiThi.CT_GVDK);
                }
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.MONHOCTableAdapter.Fill(this.dSChuanBiThi.MONHOC);

            this.GIAOVIENTableAdapter1.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIENTableAdapter1.Fill(this.dSChuanBiThi.GIAOVIEN);

            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSChuanBiThi.GIAOVIEN_DANGKY);

            this.CT_GVDKTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.CT_GVDKTableAdapter.Fill(this.dSChuanBiThi.CT_GVDK);

            this.LOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.LOPTableAdapter.Fill(this.dSChuanBiThi.LOP);

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
