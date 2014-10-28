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

namespace JRPEditorEngine
{
    public partial class NewMap : Form
    {
        public NewMap()
        {
            InitializeComponent();

            for (int i = 0; i < Enum.GetNames(typeof(MapType)).Length; i++)
            {
                cmbType.Items.Add(Enum.GetName(typeof(MapType), i));
            }

            cmbType.SelectedIndex = 0;
        }

        public string MapName
        {
            get;
            set;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public int Fringe
        {
            get;
            set;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MapName = txtName.Text;
            X = int.Parse(txtMaxX.Text);
            Y = int.Parse(txtMaxY.Text); 
            Type = cmbType.SelectedIndex;
            Fringe = int.Parse(txtPlayerAbove.Text);

            Editor.Instance.NewMap();

            Close();
        }
    }
}
