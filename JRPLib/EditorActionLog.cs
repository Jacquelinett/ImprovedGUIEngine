using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPLib
{
    public class EditorActionLog
    {
        List<EditorAction> _log;

        public EditorActionLog()
        {
            _log = new List<EditorAction>();
        }

        public List<EditorAction> Log
        {
            get { return _log; }
        }

    }
}
