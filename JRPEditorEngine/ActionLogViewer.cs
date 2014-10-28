using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using JRPLib;

namespace JRPEditorEngine
{
    public partial class ActionLogViewer : DockContent
    {
        CurrencyManager cm;

        public ActionLogViewer()
        {
            InitializeComponent();

            lstLog.DataSource = Editor.Instance.Log.Log;
            lstLog.DisplayMember = "Message";

            cm = (CurrencyManager)BindingContext[Editor.Instance.Log.Log];
        }

        public void RefreshDatabase()
        {
            if (Editor.Instance.Log == null)
                return;

            if (cm == null)
                return;

            cm.Refresh();
        }

        public void AddLog(string msg, int type)
        {
            if (Editor.Instance.Log == null)
                return;
            Editor.Instance.Log.Log.Add(new EditorAction((EditorActionType)type ){Message = msg});
            RefreshDatabase();
        }

        public void AddLog(string msg, int type, object o)
        {
            if (Editor.Instance.Log == null)
                return;
            Editor.Instance.Log.Log.Add(new EditorAction((EditorActionType)type, o ){Message = msg});
            RefreshDatabase();
        }
    }
}
