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
        DELETED = 3
    }
    internal class Action
    {
        private ActionState _action;
        private Object[] _objects;
        private DataRow _data;



        public Action(ActionState aciton, DataRow data = null,Object[] objects =null)
        {
            this._action = aciton;
            this._data = data;
            this._objects = objects;
        }
        public ActionState getAction()
        {
            return _action;
        }
        public ActionState action
        {
            get { return _action; }
         }

        public DataRow data {
            get { return _data; }
        }
        public Object[] objects { 
            get { return _objects; }
        }
    }
    internal class MyStack
    {
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

        public void Push(ActionState action, DataRow data)
        {
            stack.Push(new Action(action, data));
            TriggerEvent();
        }
        public void Push(ActionState action, DataRow data,Object[] objects)
        {
                stack.Push(new Action(action, data,objects));
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
