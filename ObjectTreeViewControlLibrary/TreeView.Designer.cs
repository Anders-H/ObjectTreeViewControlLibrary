namespace ObjectTreeViewControlLibrary
{
    partial class TreeView
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            vScrollBar1 = new VScrollBar();
            SuspendLayout();
            // 
            // vScrollBar1
            // 
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.LargeChange = 2;
            vScrollBar1.Location = new Point(530, 0);
            vScrollBar1.Maximum = 1;
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(20, 489);
            vScrollBar1.TabIndex = 0;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            vScrollBar1.ValueChanged += vScrollBar1_ValueChanged;
            // 
            // TreeWiew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(vScrollBar1);
            Name = "TreeWiew";
            Size = new Size(550, 489);
            Load += UserControl1_Load;
            ResumeLayout(false);
        }

        #endregion

        private VScrollBar vScrollBar1;
    }
}