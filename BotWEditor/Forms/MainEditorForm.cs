using BotWEditor.Editor;
using BotWEditor.Forms.Dialogs;
using BotWLib.Formats;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using OpenTK.Graphics.OpenGL;

namespace BotWEditor.Forms
{
    public partial class MainEditorForm : Form
    {
        EditorCore MainEditorCore;

        public static MainEditorForm Instance;

        public MainEditorForm()
        {
            Instance = this;
            InitializeComponent();

            glControl.Resize += Display.Internal_EventResize;

            glControl.Load += (sender, args) =>
            {
                Application.Idle += HandleApplicationIdle;

                MainEditorCore = new EditorCore(this);
            };

            glControl.Paint += (sender, args) => RenderFrame();
        }

        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (glControl.IsIdle)
                RenderFrame();
        }

        void RenderFrame()
        {
            GL.ClearColor(System.Drawing.Color.GreenYellow);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (MainEditorCore != null)
                MainEditorCore.ProcessFrame();

            glControl.SwapBuffers();
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
                    //MainEditor = new DungeonEditor(this);
                    //MainEditor.LoadFromStream(stream);

                    
                }
            }
        }

        private void testBFRESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "BFRES files (*.bfres)|*.bfres|All files (*.*)|*.*";

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                using (var stream = ofd.OpenFile())
                {
                    BFRES file = new BFRES(stream);
                    file.ToString();

                }
            }
        }

        private void terrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Master terrain file (*.tscb)|*.tscb|All files (*.*)|*.*";

                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                using (var stream = ofd.OpenFile())
                {

                }
            }
        }
    }
}
