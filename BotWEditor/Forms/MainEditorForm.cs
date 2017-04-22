﻿using BotWEditor.Forms.Dialogs;
using BotWLib.Formats;
using System;
using System.Diagnostics;
using System.IO;
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

        private void decompressYaz0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog(this) != DialogResult.OK)
                        return;

                    using (var stream = ofd.OpenFile())
                    using (var outputStream = new MemoryStream())
                    {
                        Yaz0.Decompress(stream, outputStream);

                        using (var sfd = new SaveFileDialog())
                        {
                            sfd.FileName = ofd.FileName;

                            if (sfd.ShowDialog(this) != DialogResult.OK)
                                return;

                            using (var outputFile = sfd.OpenFile())
                            {
                                outputStream.Seek(0, SeekOrigin.Begin);
                                outputStream.CopyTo(outputFile);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
