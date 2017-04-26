using System.Windows.Forms;

namespace BotWEditor.Editor
{
    public class Display
    {
        public static int Width;
        public static int Height;

        internal static void Internal_EventResize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            Width = control.Width;
            Height = control.Height;
        }
    }
}