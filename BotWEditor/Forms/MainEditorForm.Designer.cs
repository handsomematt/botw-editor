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
            this.glControl = new OpenTK.GLControl();
            this.editorMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompressYaz0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractSARCArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testBFRESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.editorObjectsGroupBox = new System.Windows.Forms.GroupBox();
            this.EditorObjectTreeView = new System.Windows.Forms.TreeView();
            this.objectPropertiesBox = new System.Windows.Forms.GroupBox();
            this.ObjectPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.editorMainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.editorObjectsGroupBox.SuspendLayout();
            this.objectPropertiesBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.glControl.BackColor = System.Drawing.Color.Transparent;
            this.glControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.glControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(0, 0);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(1038, 657);
            this.glControl.TabIndex = 1;
            this.glControl.VSync = true;
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
            this.editorMainMenuStrip.Size = new System.Drawing.Size(1264, 24);
            this.editorMainMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dungeonToolStripMenuItem,
            this.terrainToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // dungeonToolStripMenuItem
            // 
            this.dungeonToolStripMenuItem.Name = "dungeonToolStripMenuItem";
            this.dungeonToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.dungeonToolStripMenuItem.Text = "Dungeon";
            this.dungeonToolStripMenuItem.Click += new System.EventHandler(this.dungeonToolStripMenuItem_Click);
            // 
            // terrainToolStripMenuItem
            // 
            this.terrainToolStripMenuItem.Name = "terrainToolStripMenuItem";
            this.terrainToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.terrainToolStripMenuItem.Text = "Terrain";
            this.terrainToolStripMenuItem.Click += new System.EventHandler(this.terrainToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decompressYaz0ToolStripMenuItem,
            this.extractSARCArchiveToolStripMenuItem,
            this.testBFRESToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // decompressYaz0ToolStripMenuItem
            // 
            this.decompressYaz0ToolStripMenuItem.Name = "decompressYaz0ToolStripMenuItem";
            this.decompressYaz0ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.decompressYaz0ToolStripMenuItem.Text = "Decompress Yaz0...";
            this.decompressYaz0ToolStripMenuItem.Click += new System.EventHandler(this.decompressYaz0ToolStripMenuItem_Click);
            // 
            // extractSARCArchiveToolStripMenuItem
            // 
            this.extractSARCArchiveToolStripMenuItem.Name = "extractSARCArchiveToolStripMenuItem";
            this.extractSARCArchiveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.extractSARCArchiveToolStripMenuItem.Text = "Extract SARC Archive...";
            this.extractSARCArchiveToolStripMenuItem.Click += new System.EventHandler(this.extractSARCArchiveToolStripMenuItem_Click);
            // 
            // testBFRESToolStripMenuItem
            // 
            this.testBFRESToolStripMenuItem.Name = "testBFRESToolStripMenuItem";
            this.testBFRESToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.testBFRESToolStripMenuItem.Text = "Test BFRES";
            this.testBFRESToolStripMenuItem.Click += new System.EventHandler(this.testBFRESToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.issueTrackerToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // issueTrackerToolStripMenuItem
            // 
            this.issueTrackerToolStripMenuItem.Name = "issueTrackerToolStripMenuItem";
            this.issueTrackerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.issueTrackerToolStripMenuItem.Text = "Issue Tracker";
            this.issueTrackerToolStripMenuItem.Click += new System.EventHandler(this.issueTrackerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.glControl);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 657);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.editorObjectsGroupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.objectPropertiesBox);
            this.splitContainer2.Size = new System.Drawing.Size(222, 657);
            this.splitContainer2.SplitterDistance = 311;
            this.splitContainer2.TabIndex = 2;
            // 
            // editorObjectsGroupBox
            // 
            this.editorObjectsGroupBox.Controls.Add(this.EditorObjectTreeView);
            this.editorObjectsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorObjectsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.editorObjectsGroupBox.Name = "editorObjectsGroupBox";
            this.editorObjectsGroupBox.Size = new System.Drawing.Size(222, 311);
            this.editorObjectsGroupBox.TabIndex = 2;
            this.editorObjectsGroupBox.TabStop = false;
            this.editorObjectsGroupBox.Text = "Editor Objects";
            // 
            // EditorObjectTreeView
            // 
            this.EditorObjectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorObjectTreeView.Location = new System.Drawing.Point(3, 16);
            this.EditorObjectTreeView.Name = "EditorObjectTreeView";
            this.EditorObjectTreeView.Size = new System.Drawing.Size(216, 292);
            this.EditorObjectTreeView.TabIndex = 0;
            // 
            // objectPropertiesBox
            // 
            this.objectPropertiesBox.Controls.Add(this.ObjectPropertyGrid);
            this.objectPropertiesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectPropertiesBox.Location = new System.Drawing.Point(0, 0);
            this.objectPropertiesBox.Name = "objectPropertiesBox";
            this.objectPropertiesBox.Size = new System.Drawing.Size(222, 342);
            this.objectPropertiesBox.TabIndex = 3;
            this.objectPropertiesBox.TabStop = false;
            this.objectPropertiesBox.Text = "Properties";
            // 
            // ObjectPropertyGrid
            // 
            this.ObjectPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectPropertyGrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.ObjectPropertyGrid.Location = new System.Drawing.Point(3, 16);
            this.ObjectPropertyGrid.Name = "ObjectPropertyGrid";
            this.ObjectPropertyGrid.Size = new System.Drawing.Size(216, 323);
            this.ObjectPropertyGrid.TabIndex = 0;
            // 
            // MainEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.editorMainMenuStrip);
            this.MainMenuStrip = this.editorMainMenuStrip;
            this.Name = "MainEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BotW Editor";
            this.editorMainMenuStrip.ResumeLayout(false);
            this.editorMainMenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.editorObjectsGroupBox.ResumeLayout(false);
            this.objectPropertiesBox.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dungeonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem testBFRESToolStripMenuItem;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.ToolStripMenuItem terrainToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox editorObjectsGroupBox;
        private System.Windows.Forms.GroupBox objectPropertiesBox;
        public System.Windows.Forms.TreeView EditorObjectTreeView;
        public System.Windows.Forms.PropertyGrid ObjectPropertyGrid;
    }
}