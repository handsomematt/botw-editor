namespace BotWEditor.Forms
{
    partial class MainEditorForm
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
            this.editorMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompressYaz0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractSARCArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorMainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorMainMenuStrip
            // 
            this.editorMainMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.editorMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.editorMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.editorMainMenuStrip.Name = "editorMainMenuStrip";
            this.editorMainMenuStrip.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.editorMainMenuStrip.Size = new System.Drawing.Size(2317, 42);
            this.editorMainMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decompressYaz0ToolStripMenuItem,
            this.extractSARCArchiveToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(72, 34);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // decompressYaz0ToolStripMenuItem
            // 
            this.decompressYaz0ToolStripMenuItem.Name = "decompressYaz0ToolStripMenuItem";
            this.decompressYaz0ToolStripMenuItem.Size = new System.Drawing.Size(314, 34);
            this.decompressYaz0ToolStripMenuItem.Text = "Decompress Yaz0...";
            this.decompressYaz0ToolStripMenuItem.Click += new System.EventHandler(this.decompressYaz0ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.issueTrackerToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 34);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // issueTrackerToolStripMenuItem
            // 
            this.issueTrackerToolStripMenuItem.Name = "issueTrackerToolStripMenuItem";
            this.issueTrackerToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.issueTrackerToolStripMenuItem.Text = "Issue Tracker";
            this.issueTrackerToolStripMenuItem.Click += new System.EventHandler(this.issueTrackerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // extractSARCArchiveToolStripMenuItem
            // 
            this.extractSARCArchiveToolStripMenuItem.Name = "extractSARCArchiveToolStripMenuItem";
            this.extractSARCArchiveToolStripMenuItem.Size = new System.Drawing.Size(314, 34);
            this.extractSARCArchiveToolStripMenuItem.Text = "Extract SARC Archive...";
            this.extractSARCArchiveToolStripMenuItem.Click += new System.EventHandler(this.extractSARCArchiveToolStripMenuItem_Click);
            // 
            // MainEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2317, 1257);
            this.Controls.Add(this.editorMainMenuStrip);
            this.MainMenuStrip = this.editorMainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BotW Editor";
            this.editorMainMenuStrip.ResumeLayout(false);
            this.editorMainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip editorMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueTrackerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompressYaz0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractSARCArchiveToolStripMenuItem;
    }
}