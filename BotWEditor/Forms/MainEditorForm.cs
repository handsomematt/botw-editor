using BotWEditor.Forms.Dialogs;
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

        private void extractSARCArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog(this) != DialogResult.OK)
                        return;

                    using (var stream = ofd.OpenFile())
                    {
                        var arch = new SARC(stream);

                        using (var fbd = new FolderBrowserDialog())
                        {
                            fbd.SelectedPath = Path.GetDirectoryName(ofd.FileName);

                            if (fbd.ShowDialog(this) != DialogResult.OK)
                                return;

                            var path = fbd.SelectedPath + Path.DirectorySeparatorChar;

                            foreach (var node in arch.SfatNodes)
                            {
                                var fullPath = path + node.copied_name.Replace('/', Path.DirectorySeparatorChar);
                                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                                using (var fileOutput = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                                    fileOutput.Write(node.copied_data, 0, node.copied_data.Length);
                            }

                            // Open folder in Explorer
                            Process.Start(fbd.SelectedPath);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dungeonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Pack files (*.pack)|*.pack|All files (*.*)|*.*";

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                using (var stream = ofd.OpenFile())
                {

                }
            }
        }
    }
}
