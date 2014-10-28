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
    public partial class TilesetPickerForm : DockContent
    {
        TilesetPicker tp;
        int _id;

        public TilesetPickerForm(Tileset ts, int id)
        {
            InitializeComponent();
            tp = new TilesetPicker(picScreen.Handle, picScreen.Width, picScreen.Height, ts);
            tmrReset.Enabled = true;

            tp.Debug = true;
            //tp.DebugFont = 0;

            Resized();

            _id = id;
        }

        public TilesetPicker Picker
        {
            get { return tp; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public Tileset Tileset
        {
            get { return tp.Tileset; }
        }

        public void Resized()
        {
            

            if ((int)tp.Tileset.MyTileset.Size.Y - picScreen.Height <= 0)
                vOffsetY.Enabled = false;
            else
            {
                vOffsetY.Enabled = true;
                vOffsetY.Maximum = (int)tp.Tileset.MyTileset.Size.Y - picScreen.Height + 9;
            }
            if ((int)tp.Tileset.MyTileset.Size.X - picScreen.Width <= 0)
                hOffsetX.Enabled = false;
            else
            {
                hOffsetX.Enabled = true;
                hOffsetX.Maximum = (int)tp.Tileset.MyTileset.Size.X - picScreen.Width + 9;
            }


            tp.ResizeView(picScreen.Width, picScreen.Height, picScreen.Handle);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tmrReset_Tick(object sender, EventArgs e)
        {
            tp.Update();
            tp.Draw();
        }

        private void picScreen_Click(object sender, EventArgs e)
        {
            tp.Picked();
            //MessageBox.Show(tp.PickedX + ", " + tp.PickedY);
        }

        private void hOffsetX_Scroll(object sender, ScrollEventArgs e)
        {
            tp.OffsetX = hOffsetX.Value;
        }

        private void vOffsetY_Scroll(object sender, ScrollEventArgs e)
        {
            tp.OffsetY = vOffsetY.Value;
        }

        private void TilesetPickerForm_Resize(object sender, EventArgs e)
        {
            Resized();
        }

        private void TilesetPickerForm_Load(object sender, EventArgs e)
        {

        }

        private void TilesetPickerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Editor.Instance.CloseTSViewer(this);
        }

        private void TilesetPickerForm_Enter(object sender, EventArgs e)
        {
            Editor.Instance.SetFocus(0, _id);
        }


    }
}
