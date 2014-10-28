namespace JRPEditorEngine
{
    partial class ToolBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBox));
            this.stlToolBox = new System.Windows.Forms.ToolStrip();
            this.btnPencil = new System.Windows.Forms.ToolStripButton();
            this.btnEraser = new System.Windows.Forms.ToolStripButton();
            this.btnFlipV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFlipH = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.stlToolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // stlToolBox
            // 
            this.stlToolBox.AutoSize = false;
            this.stlToolBox.CanOverflow = false;
            this.stlToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stlToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPencil,
            this.btnEraser,
            this.toolStripSeparator3,
            this.btnFlipH,
            this.btnFlipV,
            this.toolStripSeparator4});
            this.stlToolBox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.stlToolBox.Location = new System.Drawing.Point(0, 0);
            this.stlToolBox.Name = "stlToolBox";
            this.stlToolBox.Size = new System.Drawing.Size(176, 46);
            this.stlToolBox.TabIndex = 0;
            this.stlToolBox.Text = "toolStrip1";
            // 
            // btnPencil
            // 
            this.btnPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPencil.Image = ((System.Drawing.Image)(resources.GetObject("btnPencil.Image")));
            this.btnPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPencil.Name = "btnPencil";
            this.btnPencil.Size = new System.Drawing.Size(23, 20);
            this.btnPencil.Text = "Pencil";
            // 
            // btnEraser
            // 
            this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
            this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(23, 20);
            this.btnEraser.Text = "Eraser";
            // 
            // btnFlipV
            // 
            this.btnFlipV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFlipV.Image = ((System.Drawing.Image)(resources.GetObject("btnFlipV.Image")));
            this.btnFlipV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFlipV.Name = "btnFlipV";
            this.btnFlipV.Size = new System.Drawing.Size(23, 20);
            this.btnFlipV.Text = "Flip Verticle";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnFlipH
            // 
            this.btnFlipH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFlipH.Image = ((System.Drawing.Image)(resources.GetObject("btnFlipH.Image")));
            this.btnFlipH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFlipH.Name = "btnFlipH";
            this.btnFlipH.Size = new System.Drawing.Size(23, 20);
            this.btnFlipH.Text = "Flip Horizontal";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 46);
            this.Controls.Add(this.stlToolBox);
            this.Name = "ToolBox";
            this.Text = "ToolBox";
            this.stlToolBox.ResumeLayout(false);
            this.stlToolBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip stlToolBox;
        private System.Windows.Forms.ToolStripButton btnPencil;
        private System.Windows.Forms.ToolStripButton btnEraser;
        private System.Windows.Forms.ToolStripButton btnFlipV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnFlipH;
    }
}