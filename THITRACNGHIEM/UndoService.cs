using DevExpress.CodeParser;
using DevExpress.Office.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THITRACNGHIEM;

namespace THITRACNGHIEM
{
    public enum TrangThaiGhi
    {
        hieuchinh,
        them
    }
    public enum ActionType
    {
        Add,
        Delete,
        Edit
    }

    public class RowData
    {
        public ActionType ActionType { get; private set; }
        public object[] RowItemArray { get; private set; }
        public object[] EditedRowItemArray { get; private set; }
        public List<Object[]> ListRowItemArray { get; private set; }
        public RowData(ActionType actionType, object[] rowItemArray, object[] editedRowItemArray)
        {
            ActionType = actionType;
            RowItemArray = rowItemArray;
            EditedRowItemArray = editedRowItemArray;
        }

        public RowData(ActionType actionType, object[] rowItemArray)
        {
            ActionType = actionType;
            RowItemArray = rowItemArray;
        }

        public RowData(ActionType actionType, object[] rowItemArray, List<Object[]> listRowItemArray)
        {
            ActionType = actionType;
            RowItemArray = rowItemArray;
            ListRowItemArray = listRowItemArray;
        }

        public RowData(ActionType actionType, object[] rowItemArray, object[] editedRowItemArray,List<Object[]> listRowItemArray)
        {
            ActionType = actionType;
            RowItemArray = rowItemArray;
            EditedRowItemArray= editedRowItemArray;
            ListRowItemArray = listRowItemArray;
        }
    }

    public class UndoManager
    {
        private BindingSource bds;
        private Stack<RowData> UndoStack;
        private Stack<RowData> ReUndoStack;

        public UndoManager(BindingSource bds)
        {
            this.bds = bds;
            this.UndoStack = new Stack<RowData>();
            this.ReUndoStack = new Stack<RowData>();
        }

        public void ClearUndoStack()
        {
            this.UndoStack.Clear();
        }

        public void ClearReUndoStack()
        {
            this.ReUndoStack.Clear();
        }
        public void AddNewRecord(object[] newRowItemArray)
        {
            // Lưu lại thông tin về bản ghi mới vào UndoStack
            UndoStack.Push(new RowData(ActionType.Add, newRowItemArray));
        }

        public void EditRecord(object[] oldRowItemArray, object[] editedRowItemArray)
        {
            // Lưu thông tin về bản ghi trước khi chỉnh sửa vào UndoStack
            UndoStack.Push(new RowData(ActionType.Edit, oldRowItemArray, editedRowItemArray));
        }

        public void DeleteRecord(object[] deletedRowItemArray)
        {
            // Lưu thông tin về bản ghi đã bị xóa vào UndoStack
            UndoStack.Push(new RowData(ActionType.Delete,
                deletedRowItemArray));
        }


        public DataRowView FindRowView(object[] rowArrayItem)
        {
            foreach (DataRowView rowView in bds)
            {
                object[] trimmedRowItemArray = rowView.Row.ItemArray.Select(item => item.ToString().Trim()).ToArray();
                object[] trimmedRowArrayItem = rowArrayItem.Select(item => item.ToString().Trim()).ToArray();

                if (Enumerable.SequenceEqual(trimmedRowItemArray, trimmedRowArrayItem))
                {
                    return rowView;
                }
            }
            return null;
        }

        public int Undo()
        {
            if (UndoStack.Count > 0)
            {
                RowData lastAction = UndoStack.Pop();
                switch (lastAction.ActionType)
                {
                    case ActionType.Add:
                        DataRowView addedRowItemArray = FindRowView(lastAction.RowItemArray);
                        if (addedRowItemArray != null)
                        {
                            bds.Remove(addedRowItemArray);
                            bds.EndEdit();
                            ReUndoStack.Push(new RowData(ActionType.Delete, lastAction.RowItemArray));
                            return 0;
                        }
                        else
                        {
                            MessageBox.Show("Khong dc", "", MessageBoxButtons.OK);
                        }
                        break;
                    case ActionType.Edit:
                        try
                        {
                            DataRowView editedRow = FindRowView(lastAction.EditedRowItemArray);
                            if (editedRow != null)
                            {
                                int i = 0;
                                //bds.Remove(editedRow);
                                //DataRowView newRowView = (DataRowView)bds.AddNew(); // Thêm một bản ghi mới
                                //newRowView.Row.ItemArray = lastAction.RowItemArray; // Sao chép các giá trị từ hàng đã xóa vào hàng mới
                                //bds.EndEdit();
                                foreach (DataColumn column in editedRow.Row.Table.Columns)
                                {
                                    DataRow row = editedRow.Row;
                                    row[column] = lastAction.RowItemArray[i];
                                    i++;
                                }
                                bds.EndEdit();
                                ReUndoStack.Push(new RowData(ActionType.Edit, lastAction.EditedRowItemArray, lastAction.RowItemArray));
                                return 0;
                                //MessageBox.Show("Vo day dc", "", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("Khong dc", "", MessageBoxButtons.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Xử lý ngoại lệ và hiển thị thông báo lỗi cho người dùng
                            MessageBox.Show("Không thể khôi phục dữ liệu: " + ex.Message, "Lỗi Undo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case ActionType.Delete:
                        try
                        {
                            DataRowView newRowView = (DataRowView)bds.AddNew(); // Thêm một bản ghi mới
                            // Sao chép các giá trị từ hàng đã xóa vào hàng mới
                            newRowView.Row.ItemArray = lastAction.RowItemArray;

                            // Kết thúc chỉnh sửa để xác nhận thêm mới
                            bds.EndEdit();
                            ReUndoStack.Push(new RowData(ActionType.Add, lastAction.RowItemArray));
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            // Xử lý ngoại lệ và hiển thị thông báo lỗi cho người dùng
                            MessageBox.Show("Không thể khôi phục dữ liệu: " + ex.Message, "Lỗi Undo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
               
                // Kết thúc chỉnh sửa để xác nhận việc undo
            }
            else
            {
                MessageBox.Show("Không còn gì để undo");
            }
            return 1;
        }

        public int ReUndo()
        {
            if (ReUndoStack.Count > 0)
            {
                RowData lastAction = ReUndoStack.Pop();
                switch (lastAction.ActionType)
                {
                    case ActionType.Add:
                        DataRowView addedRowItemArray = FindRowView(lastAction.RowItemArray);
                        if (addedRowItemArray != null)
                        {
                            bds.Remove(addedRowItemArray);
                            bds.EndEdit();
                            UndoStack.Push(new RowData(ActionType.Delete, lastAction.RowItemArray));
                            return 0;
                        }
                        else
                        {
                            MessageBox.Show("Khong dc", "", MessageBoxButtons.OK);
                        }
                        break;
                    case ActionType.Edit:
                        try
                        {
                            DataRowView editedRow = FindRowView(lastAction.EditedRowItemArray);
                            if (editedRow != null)
                            {
                                int i = 0;
                                //bds.Remove(editedRow);
                                //DataRowView newRowView = (DataRowView)bds.AddNew(); // Thêm một bản ghi mới
                                //newRowView.Row.ItemArray = lastAction.RowItemArray; // Sao chép các giá trị từ hàng đã xóa vào hàng mới
                                //bds.EndEdit();
                                foreach (DataColumn column in editedRow.Row.Table.Columns)
                                {
                                    DataRow row = editedRow.Row;
                                    row[column] = lastAction.RowItemArray[i];
                                    i++;
                                }
                                bds.EndEdit();
                                UndoStack.Push(new RowData(ActionType.Edit, lastAction.EditedRowItemArray, lastAction.RowItemArray));
                                return 0;
                                //MessageBox.Show("Vo day dc", "", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("Khong dc", "", MessageBoxButtons.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Xử lý ngoại lệ và hiển thị thông báo lỗi cho người dùng
                            MessageBox.Show("Không thể khôi phục dữ liệu: " + ex.Message, "Lỗi Undo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case ActionType.Delete:
                        try
                        {
                            DataRowView newRowView = (DataRowView)bds.AddNew(); // Thêm một bản ghi mới
                            newRowView.Row.ItemArray = lastAction.RowItemArray; // Sao chép các giá trị từ hàng đã xóa vào hàng mới
                            bds.EndEdit(); // Kết thúc chỉnh sửa để xác nhận thêm mới
                            UndoStack.Push(new RowData(ActionType.Add, lastAction.RowItemArray));
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            // Xử lý ngoại lệ và hiển thị thông báo lỗi cho người dùng
                            MessageBox.Show("Không thể khôi phục dữ liệu: " + ex.Message, "Lỗi Undo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
                // Kết thúc chỉnh sửa để xác nhận việc undo
            }
            else
            {
                MessageBox.Show("Không còn gì để undo");
            }
            return 1;
        }

        public Stack<RowData> GetUndoStack()
        {
            return UndoStack;
        }
        public Stack<RowData> GetReUndoStack()
        {
            return ReUndoStack;
        }
    }
}
public class UndoManagerWithSubBds
{
    public Stack<RowData> UndoStack;

    public UndoManagerWithSubBds()
    {
        this.UndoStack = new Stack<RowData>();
    }

    public void ClearUndoStack()
    {
        this.UndoStack.Clear();
    }

    public void AddNewRecord(object[] newRowItemArray)
    {
        // Lưu lại thông tin về bản ghi mới vào UndoStack
        UndoStack.Push(new RowData(ActionType.Add, newRowItemArray));
    }

    public void EditRecord(object[] oldRowItemArray, object[] editedRowItemArray, List<object[]> listOldItemArraySubBds)
    {
        // Lưu thông tin về bản ghi trước khi chỉnh sửa vào UndoStack
        UndoStack.Push(new RowData(ActionType.Edit, oldRowItemArray, editedRowItemArray, listOldItemArraySubBds));
    }

    public void DeleteRecord(object[] deletedRowItemArray, List<object[]> listOldItemArraySubBds)
    {
        // Lưu thông tin về bản ghi đã bị xóa vào UndoStack
        UndoStack.Push(new RowData(ActionType.Delete,
            deletedRowItemArray, listOldItemArraySubBds));
    }


    public Stack<RowData> GetUndoStack()
    {
        return UndoStack;
    }

}