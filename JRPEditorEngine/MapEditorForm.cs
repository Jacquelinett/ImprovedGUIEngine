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
using System.Threading;

namespace JRPEditorEngine
{
    public partial class MapEditorForm : DockContent
    {
        MapEditor _me;
        int _id;
        Thread t;
        int _startX;
        int _startY;
        int _tempX;
        int _tempY;
        Dictionary<int, int> _tempPick = new Dictionary<int, int>();

        public MapEditorForm(Tilemap tm, int id)
        {
            InitializeComponent();

            _me = new MapEditor(picScreen.Handle, picScreen.Width, picScreen.Height, tm);
            Resized();
            _id = id;

            _startX = -1;
            _startY = -1;
            _tempX = -1;
            _tempY = -1;

            tmrReset.Enabled = true;

            if (_me.CacheWork)
                Editor.Instance.LogViewer.AddLog(Editor.Instance.CurrentTime + "; Map's cache generated (load map)", (int)EditorActionType.CacheGenerated);
        }

        public void NewCache()
        {
            _me.NewLayer();
        }

        public int CacheCount
        {
            get { return _me.CacheCount; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public Tilemap Map
        {
            get { return _me.Map; }
        }

        public void Resized()
        {


            if ((int)_me.Map.Y * Editor.Instance.CurGame.GFXEngine.TileSizeY - picScreen.Height <= 0)
                vOffsetY.Enabled = false;
            else
            {
                vOffsetY.Enabled = true;
                vOffsetY.Maximum = (int)_me.Map.Y * Editor.Instance.CurGame.GFXEngine.TileSizeY - picScreen.Height + 9;
            }
            if ((int)_me.Map.X * Editor.Instance.CurGame.GFXEngine.TileSizeX - picScreen.Width <= 0)
                hOffsetX.Enabled = false;
            else
            {
                hOffsetX.Enabled = true;
                hOffsetX.Maximum = (int)_me.Map.X * Editor.Instance.CurGame.GFXEngine.TileSizeX - picScreen.Width + 9;
            }


            _me.ResizeView(picScreen.Width, picScreen.Height, picScreen.Handle);
        }

        private void vOffsetY_Scroll(object sender, ScrollEventArgs e)
        {
            _me.OffsetY = vOffsetY.Value;
        }

        private void hOffsetX_Scroll(object sender, ScrollEventArgs e)
        {
            _me.OffsetX = hOffsetX.Value;
        }

        private void tmrReset_Tick(object sender, EventArgs e)
        {
            _me.Update();
            _me.Draw();
        }

        private void MapEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Editor.Instance.CloseMapViewer(this);
        }

        private void picScreen_Resize(object sender, EventArgs e)
        {
            Resized();
        }

        private void MapEditorForm_Enter(object sender, EventArgs e)
        {
            Editor.Instance.SetFocus(1, _id);
        }

        private void picScreen_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + _me.PickedX.ToString() + ", " + _me.PickedY.ToString());
        }

        private void picScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (Editor.Instance.TPF.Count < 1)
                return;

            _startX = _me.MouseLoc.X;
            _startY = _me.MouseLoc.Y;

            t = new System.Threading.Thread(TilePlacingThread);
            t.Start();
        }

        public void TilePlacingThread()
        {

            while (true)
            {
                //you need to use Invoke because the new thread can't access the UI elements directly
                if (Editor.Instance.PickType == 0)
                {
                    if (Editor.Instance.DrawType == 0)
                    {
                        MethodInvoker mi = delegate() { _me.Picked(Editor.Instance.TPF[Editor.Instance.CurrentFocus[0]].Picker, Editor.Instance.CurrentLayer); };
                        this.Invoke(mi);
                    }
                    else 
                    {
                        _tempX = _me.MouseLoc.X;
                        _tempY = _me.MouseLoc.Y;
                    }
                }
                
            }
        }

        private void picScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (t != null)
            {
                t.Abort();

                if (_tempX == -1 || _tempY == -1 || _startX == -1 || _startY == -1)
                    return;
                if (Editor.Instance.PickType == 0)
                {
                    switch (Editor.Instance.DrawType)
                    {
                        case 1:
                            
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                }
            }

        }

    }
}
