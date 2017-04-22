using BotWEditor.Forms.Dialogs;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BotWEditor.Forms
{
    public partial class MainEditorForm : Form
    {
        public MainEditorForm()
        {
            InitializeComponent();
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/HandsomeMatt/botw-modding");
        }

        private void issueTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/HandsomeMatt/botw-editor/issues");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popup = new AboutBoxForm();
            popup.Show(); 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
