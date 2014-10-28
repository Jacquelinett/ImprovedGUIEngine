using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JRPLib;
using WeifenLuo.WinFormsUI.Docking;

namespace JRPEditorEngine
{
    public partial class ViewLayer : DockContent
    {
        int _curMap;

        public ViewLayer()
        {
            InitializeComponent();
        }

        public void EnableTool()
        {
            trvLayer.Enabled = true;
            ToolBox.Enabled = true;
        }

        public void DisableTool()
        {
            trvLayer.Enabled = false;
            ToolBox.Enabled = false;
        }

        public void FocusChanged(int id)
        {
            _curMap = Editor.Instance.CurGame.DataManager.MyMap.IndexOf(Editor.Instance.GetCurMapViewer().Map);
            RefreshTreeView();
        }

        public void RefreshTreeView()
        {
            trvLayer.Nodes.Clear();
            if (Editor.Instance.CurGame == null)
                return;
            
            foreach(TileLayer layer in Editor.Instance.CurGame.DataManager.MyMap[_curMap].MyLayer)
            {
                TreeNode l = new TreeNode(layer.Name + " (" + layer.Visible + ", " + layer.Opacity + ")");
                l.Name = layer.Name;
                l.Tag = layer;
                trvLayer.Nodes.Add(l);
            }
        }

        private void btnNewLayer_Click(object sender, EventArgs e)
        {
            if (Editor.Instance.CurGame == null)
                return;

            if (Editor.Instance.GetCurMapViewer() == null)
                return;

            int success = Editor.Instance.GetCurMapViewer().CacheCount;

            Editor.Instance.CurGame.DataManager.MyMap[_curMap].MyLayer.Add(new TileLayer(Editor.Instance.CurGame.DataManager.MyMap[_curMap].MyLayer.Count));
            Editor.Instance.GetCurMapViewer().NewCache();
            RefreshTreeView();
            trvLayer.SelectedNode = trvLayer.Nodes[trvLayer.Nodes.Count - 1];

            if (Editor.Instance.GetCurMapViewer().CacheCount > success)
                Editor.Instance.LogViewer.AddLog(Editor.Instance.CurrentTime + "; Cache generated (new Layer)", (int)EditorActionType.CacheLayerGenerated);
        }

        private void trvLayer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Editor.Instance.CurrentLayer = (TileLayer)trvLayer.SelectedNode.Tag;
        }

    }
}
