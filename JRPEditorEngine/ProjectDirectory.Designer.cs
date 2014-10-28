namespace JRPEditorEngine
{
    partial class ProjectDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trvDirectory = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trvDirectory
            // 
            this.trvDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDirectory.Location = new System.Drawing.Point(0, 0);
            this.trvDirectory.Name = "trvDirectory";
            this.trvDirectory.Size = new System.Drawing.Size(200, 511);
            this.trvDirectory.TabIndex = 0;
            this.trvDirectory.DoubleClick += new System.EventHandler(this.trvDirectory_DoubleClick);
            // 
            // ProjectDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 511);
            this.Controls.Add(this.trvDirectory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProjectDirectory";
            this.Text = "Solution Explorer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvDirectory;
    }
}