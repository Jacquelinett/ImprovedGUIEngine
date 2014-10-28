using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class EditorAction
    {
        int _type;
        Object _previous;
        bool _undoable;

        public EditorAction(EditorActionType t)
        {
            _type = (int)t;
            _undoable = false;
        }

        public EditorAction(EditorActionType t, Object o)
        {
            _type = (int)t;
            _previous = o;
            _undoable = true;
        }

        public string Message
        {
            get;
            set;
        }

        public int Type
        {
            get { return _type; }
        }

        public bool UndoAble
        {
            get { return _undoable; }
        }

        public Object Tag
        {
            get;
            set;
        }
    }
}
