using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace BotWWorldViewer
{
    internal class ViewerWindow : GameWindow
    {
        public bool Fullscreen
        {
            get { return WindowState == OpenTK.WindowState.Fullscreen; }
            set
            {
                if (value != (WindowState == OpenTK.WindowState.Fullscreen))
                {
                    if (value)
                    {
                        WindowState = OpenTK.WindowState.Fullscreen;
                    }
                    else
                    {
                        WindowState = WindowState.Normal;
                    }
                }
            }
        }

        public ViewerWindow()
            : base(800, 600, new GraphicsMode(new ColorFormat(8, 8, 8, 8), 16, 0), "BotW World Viewer")
        {
            VSync = VSyncMode.On;
            Context.SwapInterval = 1;

            WindowBorder = WindowBorder.Fixed;
        }

        protected override void OnLoad(EventArgs e)
        {
            Mouse.Move += OnMouseMove;
            Mouse.ButtonUp += OnMouseButtonUp;
            Mouse.ButtonDown += OnMouseButtonDown;
            Mouse.WheelChanged += OnMouseWheelChanged;

        }

        protected override void OnResize(EventArgs e)
        {

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SwapBuffers();
        }

        private void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
        }

        private void OnMouseWheelChanged(object sender, MouseWheelEventArgs e)
        {
        }

        private void OnMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void OnMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
        }

        protected override void OnMouseLeave(EventArgs e)
        {
        }

        protected override void OnMouseEnter(EventArgs e)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}