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
        private String _key;
        private Object[] _previousObjects;
        public Action(ActionState action, Object[] objects = null, Object[] previousObjects = null)
        {
            this._action = action;
            this._objects = objects;
        }

        public Action(ActionState action, DataRow data = null,Object[] objects =null)
        {
            this._action = action;
            this._data = data;
            this._objects = objects;
        }
        public Action(ActionState action,String key=null, Object[] objects=null, DataRow data = null)
        {
            this._action = action;
            this._key = key;
            this._objects = objects;
            this._data = data;
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
        public String key
        {
            get { return _key; }
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
        public void Push(ActionState action, Object[] objects = null)
        {
            stack.Push(new Action(action, objects));
            TriggerEvent();
        }
        public void Push(ActionState action, DataRow data=null,Object[] objects=null)
        {
                stack.Push(new Action(action, data,objects));
                TriggerEvent();
        }
        public void Push(ActionState action, String key=null, Object[] objects=null, DataRow data=null)
        {
            stack.Push(new Action(action, key,objects,data));
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
            if(stack.Count == 0) return;
            stack.Clear();
            TriggerEvent();
        }
    }
}
