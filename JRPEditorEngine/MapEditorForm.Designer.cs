﻿namespace JRPEditorEngine
{
    partial class MapEditorForm
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
            this.components = new System.ComponentModel.Container();
            this.vOffsetY = new System.Windows.Forms.VScrollBar();
            this.hOffsetX = new System.Windows.Forms.HScrollBar();
            this.picScreen = new System.Windows.Forms.PictureBox();
            this.tmrReset = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // vOffsetY
            // 
            this.vOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vOffsetY.Location = new System.Drawing.Point(293, 1);
            this.vOffsetY.Name = "vOffsetY";
            this.vOffsetY.Size = new System.Drawing.Size(20, 253);
            this.vOffsetY.TabIndex = 11;
            this.vOffsetY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vOffsetY_Scroll);
            // 
            // hOffsetX
            // 
            this.hOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hOffsetX.Location = new System.Drawing.Point(1, 257);
            this.hOffsetX.Name = "hOffsetX";
            this.hOffsetX.Size = new System.Drawing.Size(289, 17);
            this.hOffsetX.TabIndex = 10;
            this.hOffsetX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hOffsetX_Scroll);
            // 
            // picScreen
            // 
            this.picScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picScreen.Location = new System.Drawing.Point(1, 1);
            this.picScreen.Name = "picScreen";
            this.picScreen.Size = new System.Drawing.Size(289, 253);
            this.picScreen.TabIndex = 9;
            this.picScreen.TabStop = false;
            this.picScreen.Click += new System.EventHandler(this.picScreen_Click);
            this.picScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picScreen_MouseDown);
            this.picScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picScreen_MouseUp);
            this.picScreen.Resize += new System.EventHandler(this.picScreen_Resize);
            // 
            // tmrReset
            // 
            this.tmrReset.Interval = 17;
            this.tmrReset.Tick += new System.EventHandler(this.tmrReset_Tick);
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 275);
            this.Controls.Add(this.vOffsetY);
            this.Controls.Add(this.hOffsetX);
            this.Controls.Add(this.picScreen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MapEditorForm";
            this.Text = "MapEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapEditorForm_FormClosed);
            this.Enter += new System.EventHandler(this.MapEditorForm_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vOffsetY;
        private System.Windows.Forms.HScrollBar hOffsetX;
        private System.Windows.Forms.PictureBox picScreen;
        private System.Windows.Forms.Timer tmrReset;

    }
}