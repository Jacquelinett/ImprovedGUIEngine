namespace JRPEditorEngine
{
    partial class ViewLayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewLayer));
            this.trvLayer = new System.Windows.Forms.TreeView();
            this.ToolBox = new System.Windows.Forms.ToolStrip();
            this.btnNewLayer = new System.Windows.Forms.ToolStripButton();
            this.btnEditLayer = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveLayer = new System.Windows.Forms.ToolStripButton();
            this.ToolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvLayer
            // 
            this.trvLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvLayer.Location = new System.Drawing.Point(0, 0);
            this.trvLayer.Name = "trvLayer";
            this.trvLayer.Size = new System.Drawing.Size(181, 386);
            this.trvLayer.TabIndex = 0;
            this.trvLayer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvLayer_AfterSelect);
            // 
            // ToolBox
            // 
            this.ToolBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewLayer,
            this.btnEditLayer,
            this.btnRemoveLayer});
            this.ToolBox.Location = new System.Drawing.Point(0, 388);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(181, 25);
            this.ToolBox.TabIndex = 1;
            this.ToolBox.Text = "toolStrip1";
            // 
            // btnNewLayer
            // 
            this.btnNewLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewLayer.Image = ((System.Drawing.Image)(resources.GetObject("btnNewLayer.Image")));
            this.btnNewLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewLayer.Name = "btnNewLayer";
            this.btnNewLayer.Size = new System.Drawing.Size(23, 22);
            this.btnNewLayer.Text = "New Layer";
            this.btnNewLayer.Click += new System.EventHandler(this.btnNewLayer_Click);
            // 
            // btnEditLayer
            // 
            this.btnEditLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditLayer.Image = ((System.Drawing.Image)(resources.GetObject("btnEditLayer.Image")));
            this.btnEditLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditLayer.Name = "btnEditLayer";
            this.btnEditLayer.Size = new System.Drawing.Size(23, 22);
            this.btnEditLayer.Text = "Edit Layer";
            // 
            // btnRemoveLayer
            // 
            this.btnRemoveLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveLayer.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveLayer.Image")));
            this.btnRemoveLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveLayer.Name = "btnRemoveLayer";
            this.btnRemoveLayer.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveLayer.Text = "Remove Layer";
            // 
            // ViewLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 413);
            this.Controls.Add(this.ToolBox);
            this.Controls.Add(this.trvLayer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewLayer";
            this.Text = "ViewLayer";
            this.ToolBox.ResumeLayout(false);
            this.ToolBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvLayer;
        private System.Windows.Forms.ToolStrip ToolBox;
        private System.Windows.Forms.ToolStripButton btnNewLayer;
        private System.Windows.Forms.ToolStripButton btnEditLayer;
        private System.Windows.Forms.ToolStripButton btnRemoveLayer;
    }
}