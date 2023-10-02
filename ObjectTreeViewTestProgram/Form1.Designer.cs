namespace ObjectTreeViewTestProgram
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeView = new ObjectTreeViewControlLibrary.TreeView();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.BorderStyle = BorderStyle.FixedSingle;
            treeView.Location = new Point(32, 24);
            treeView.Name = "treeView";
            treeView.Size = new Size(472, 388);
            treeView.TabIndex = 0;
            treeView.ViewOffset = 0;
            treeView.ItemDoubleClick += treeView_ItemDoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(treeView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ObjectTreeViewControlLibrary.TreeView treeView;
    }
}