using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITRACNGHIEM
{
    internal enum ActionState
    {
        ADDED = 1,
        MODIFIED = 2,
        MODIFIED_MODIFIED_ROW = 3,
        DELETED = 4,
        DELETED_NEW_ROW = 5,
        DELETED_MODIFIED_ROW = 6
    }
    internal class Action
    {
        //Các trường hợp có thể có
        // 1. Thêm một dòng mới
        // 2. Sửa một dòng củ
        // 3. Sửa trên dòng đã sửa
        // 4.Xóa một dòng củ
        // 5. Xóa một dòng mới 
        // 6. Xóa một dòng củ(đã hiệu chỉnh)
        public static  int ADDED = 1;
        public static int MODIFIED = 2;
        public static int MODIFIED_MODIFIED_ROW = 3;
        public static int DELETED = 4;
        public static int DELETED_NEW_ROW = 5;
        public static int DELETED_MODIFIED_ROW = 6;
        private int _action;
        private int _index;
        private Object[] _objects;
        private DataRowView _data;

        public Action(int _action, int _index) {
            this._action = _action;
            this._index = _index;
            _data = null;
        }
        public Action(int aciton,int index, DataRowView data)
        {
            this._action = aciton;   
            this._index = index;
            this._data = data;
        }
        public Action(int aciton, DataRowView data)
        {
            this._action = aciton;
            this._index = index;
            this._data = data;
        }
        public Action(int aciton, DataRowView data,Object[] objects)
        {
            this._action = aciton;
            this._index = index;
            this._data = data;
            this._objects = objects;
        }
        public int getAction()
        {
            return _action;
        }
        public int action
        {
            get { return _action; }
         }
        public int getIndex() {
            return _index;
        }
        public int index
        {
            get { return _index; }
        }
        public DataRowView data {
            get { return _data; }
        }
        public Object[] objects { 
            get { return _objects; }
        }
    }
    internal class MyStack
    {
        //Các trường hợp khi phục hồi
        // 1. Thêm một dòng mới => Xóa đi dòng đó:  added -> rejectchange
        // 2. Sửa một dòng củ => trả lại dữ liệu cho dòng đó: rejectchange
        // 3. Xóa một dòng củ => trả lại dòng củ đó: rejectchange
        // 4. Xóa một dòng mới thêm => trả lại dòng mới đó:
        // +Không dùng reject được vì dòng mới thêm reject thì sẽ xóa đi giống trường hợp 1
        // + Lấy data đã lưu trong stack 
        // + Gán giá trị đó cho DataRowView
        // + Lưu datarow đó lại vào table -> nếu nhấn phục hồi thì sẽ reject dòng đó:: reject-> added 
        // 5. Xóa một dòng hiệu chỉnh = > trả lại dòng đó với trạng thái hiệu chỉnh:
        // + Reject dòng đó: delete => unchange
        // + gán dữ liệu đã sửa đổi lại cho dòng đó: unchage -> modified
        // 6. Hiệu chỉnh trên dòng đã hiệu chỉnh:
        // + trả lại dữ liệu trước đó
        //7.Hiệu chỉnh trên dòng mới thêm thì bỏ qua
        private Stack<Action> stack = new Stack<Action>();
        public delegate void MyEventHandler();
        public event MyEventHandler StackChange;
        public void TriggerEvent()
        {
            if (StackChange != null) StackChange();
        }
        public MyStack() {
            TriggerEvent();
        }
        public void Push(int action, int index)
        {
            stack.Push(new Action(action, index));
            TriggerEvent();
        }
        public void Push(int action,int index,DataRowView data) {
            stack.Push(new Action(action,index,data));
            TriggerEvent();
        }
        public void Push(int action, DataRowView data)
        {
            stack.Push(new Action(action, data));
            TriggerEvent();
        }
        public void Push(int action, DataRowView data,Object[] objects)
        {
                stack.Push(new Action(action, data,objects));
                TriggerEvent();
        }
            public void Push(Action action)
        {
            stack.Push(action);
            TriggerEvent();
        }
        public Action Pop()
        {
            Action tmp = stack.Pop();
            TriggerEvent();
            return tmp;
        }
        public int getSize()
        {
            return stack.Count;
        }
        public void Clear()
        {
            stack.Clear();
            TriggerEvent();
        }
    }
}
