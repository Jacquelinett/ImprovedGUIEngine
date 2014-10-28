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
using System.IO;

namespace JRPEditorEngine
{
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();

            txtLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Jackie's RPG Maker\Project\";
        }

        public string GameName
        {
            get;
            set;
        }

        public string SubName
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int SizeX
        {
            get;
            set;
        }

        public int SizeY
        {
            get;
            set;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = @"Select folder to create game in.";
                folderDialog.SelectedPath = txtLocation.Text;

                var folderResult = folderDialog.ShowDialog();

                if (folderResult == DialogResult.OK)
                {
                    txtLocation.Text = folderDialog.SelectedPath + "\\";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLocation.Text))
            {
                MessageBox.Show(@"You must enter a name and location.", @"Error");
                DialogResult = DialogResult.Cancel;
                return;
            }

            if (Directory.Exists(System.IO.Path.Combine(txtLocation.Text, txtName.Text + " - " + txtSubName.Text)))
            {
                MessageBox.Show(@"A project with this name already exists in this directory.", @"Error");
                DialogResult = DialogResult.Cancel;
                return;
            }


            GameName = txtName.Text;
            SubName = txtSubName.Text;
            Description = txtDescription.Text;
            SizeX = int.Parse(txtMaxX.Text);
            SizeY = int.Parse(txtMaxY.Text);
            Path = txtLocation.Text;
            
            Editor.Instance.NewProject();

            Close();

        }
    }
}
