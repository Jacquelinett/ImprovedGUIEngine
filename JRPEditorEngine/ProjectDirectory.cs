using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using WeifenLuo.WinFormsUI.Docking;
using JRPLib;

namespace JRPEditorEngine
{
    public partial class ProjectDirectory : DockContent
    {
        bool[] _expand;

        public ProjectDirectory()
        {
            InitializeComponent();
            _expand = new bool[7];
            RefreshExpandBool();
        }

        public void RefreshExpandBool()
        {
            for (int i = 0; i < _expand.Length; i++)
                _expand[i] = false;
        }

        public void CheckExpand()
        {
            if (trvDirectory.Nodes.Count > 0)
            {
                if (trvDirectory.Nodes[0].IsExpanded)
                    _expand[0] = true;
                if (trvDirectory.Nodes[0].Nodes[0].IsExpanded)
                    _expand[5] = true;
                if (trvDirectory.Nodes[0].Nodes[1].IsExpanded)
                    _expand[1] = true;
                if (trvDirectory.Nodes[0].Nodes[0].Nodes[0].IsExpanded)
                    _expand[4] = true;
                if (trvDirectory.Nodes[0].Nodes[1].Nodes[0].IsExpanded)
                    _expand[2] = true;
                if (trvDirectory.Nodes[0].Nodes[1].Nodes[0].Nodes[0].IsExpanded)
                    _expand[3] = true;
                if (trvDirectory.Nodes[0].Nodes[1].Nodes[0].Nodes[1].IsExpanded)
                    _expand[6] = true;
            }
        }

        public void RefreshTreeView()
        {
            trvDirectory.Nodes.Clear();     

            if (Editor.Instance.CurGame == null)
                return;

            CheckExpand();
            
            TreeNode MainNode = new TreeNode("" + Editor.Instance.CurGame.GameFullName + ":");//
            TreeNode PipelineNode = new TreeNode("Content Pipeline:");//
            TreeNode GraphicNode = new TreeNode("Graphic:");//
            TreeNode TilesetNode = new TreeNode("Tileset:");//
            TreeNode MapNode = new TreeNode("Map");//
            TreeNode DataNode = new TreeNode("Project Data:");//
            TreeNode SpriteNode = new TreeNode("Sprite:");//

            foreach (Tileset tl in Editor.Instance.CurGame.GFXManager.TilesetPipeline)
            {
                TreeNode ts = new TreeNode(tl.Name);
                ts.Tag = tl;
                TilesetNode.Nodes.Add(ts);
            }

            foreach (Tilemap tm in Editor.Instance.CurGame.DataManager.MyMap)
            {
                TreeNode m = new TreeNode(tm.Name);
                m.Tag = tm;
                MapNode.Nodes.Add(m);
            }

            DataNode.Nodes.Add(MapNode);
            
            GraphicNode.Nodes.Add(TilesetNode);
            GraphicNode.Nodes.Add(SpriteNode);

            PipelineNode.Nodes.Add(GraphicNode);

            MainNode.Nodes.Add(DataNode);
            MainNode.Nodes.Add(PipelineNode);

            trvDirectory.Nodes.Add(MainNode);

            if (_expand[0])
                MainNode.Expand();
            if (_expand[1])
                PipelineNode.Expand();
            if (_expand[2])
                GraphicNode.Expand();
            if (_expand[3])
                TilesetNode.Expand();
            if (_expand[4])
                MapNode.Expand();
            if (_expand[5])
                DataNode.Expand();
            if (_expand[6])
                SpriteNode.Expand();


            RefreshExpandBool();
        }

        private void trvDirectory_DoubleClick(object sender, EventArgs e)
        {
            if (trvDirectory.SelectedNode == null)
                return;
            
            if (trvDirectory.SelectedNode.Tag == null)
                return;
            if (trvDirectory.SelectedNode.Tag is Tileset)
                Editor.Instance.NewTSViewer(trvDirectory.SelectedNode.Tag as Tileset);
            if (trvDirectory.SelectedNode.Tag is Tilemap)
                Editor.Instance.NewMapViewer(trvDirectory.SelectedNode.Tag as Tilemap);
        }
    }
}
