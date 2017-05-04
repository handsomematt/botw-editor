using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using BotWWorldViewer.Resource;
using System.IO;
using System.Reflection;
using BotWWorldViewer.Graphics;

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

        private const float CameraMoveSpeed = 16.0f;
        private Camera myCamera;
        private TerrainShader myShader;
        private Terrain myTerrain;
        private bool myIgnoreMouse;
        private Vector2 lastMousePos;

        public ViewerWindow()
            : base(800, 600,
                  GraphicsMode.Default,
                  "BotW World Viewer",
                  GameWindowFlags.Default,
                  DisplayDevice.Default,
                  4, // OpenGL major version
                  0, // OpenGL minor version
                  GraphicsContextFlags.ForwardCompatible)
        {
            VSync = VSyncMode.On;
            Context.SwapInterval = 1;

            WindowBorder = WindowBorder.Fixed;
            Title += ": OpenGL Version: " + GL.GetString(StringName.Version);
        }

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = false;

            Mouse.Move += OnMouseMove;
            Mouse.ButtonUp += OnMouseButtonUp;
            Mouse.ButtonDown += OnMouseButtonDown;
            Mouse.WheelChanged += OnMouseWheelChanged;

            myCamera = new Camera(MathHelper.Pi / 3.0f, (float)Width / (float)Height, 1024.0f);
            myShader = new TerrainShader();
            myShader.Camera = myCamera;

            var stream = ResourceManager.ReadFile("5100000002.hght");
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            myTerrain = new Terrain(new ZeldaHeightmap(buffer));
        }

        protected override void OnResize(EventArgs e)
        {
            myCamera.ScreenRatio = (float)Width / (float)Height;
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (Keyboard[Key.Escape])
                Environment.Exit(0);

            Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
            float angleY = myCamera.Rotation.Y;
            float angleX = myCamera.Rotation.X;

            if (Keyboard[Key.D])
            {
                movement.X += (float)Math.Cos(angleY);
                movement.Z += (float)Math.Sin(angleY);
            }
            if (Keyboard[Key.A])
            {
                movement.X -= (float)Math.Cos(angleY);
                movement.Z -= (float)Math.Sin(angleY);
            }
            if (Keyboard[Key.S])
            {
                movement.Z += (float)Math.Cos(angleY) * (float)Math.Cos(angleX);
                movement.Y += (float)Math.Sin(angleX);
                movement.X -= (float)Math.Sin(angleY) * (float)Math.Cos(angleX);
            }
            if (Keyboard[Key.W])
            {
                movement.Z -= (float)Math.Cos(angleY) * (float)Math.Cos(angleX);
                movement.Y -= (float)Math.Sin(angleX);
                movement.X += (float)Math.Sin(angleY) * (float)Math.Cos(angleX);
            }

            if (movement.Length != 0)
            {
                movement.Normalize();
                myCamera.Position = myCamera.Position + movement * CameraMoveSpeed * (float)e.Time
                    * (Keyboard[Key.ShiftLeft] ? 4.0f : 1.0f)
                    * 1024.0f / 512.0f;
            }

            //ResourceManager.CheckGLDisposals();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(System.Drawing.Color.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            myCamera.UpdateViewMatrix();

            myShader.StartBatch();
            myShader.Render(myTerrain);
            myShader.EndBatch();

            SwapBuffers();
        }

        private void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            Vector2 delta = lastMousePos - new Vector2(OpenTK.Input.Mouse.GetState().X, OpenTK.Input.Mouse.GetState().Y);

            Vector2 rot = myCamera.Rotation;

            rot.Y -= delta.X / 180.0f;
            rot.X -= delta.Y / 180.0f;

            if (rot.X < (float)-Math.PI / 2.0f)
                rot.X = (float)-Math.PI / 2.0f;
            if (rot.X > (float)Math.PI / 2.0f)
                rot.X = (float)Math.PI / 2.0f;

            myCamera.Rotation = rot;

            ResetCursor();
        }

        void ResetCursor()
        {
            OpenTK.Input.Mouse.SetPosition(Bounds.Left + Width / 2, Bounds.Top + Height / 2);
            lastMousePos = new Vector2(OpenTK.Input.Mouse.GetState().X, OpenTK.Input.Mouse.GetState().Y);
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