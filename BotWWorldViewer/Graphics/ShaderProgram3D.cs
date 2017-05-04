using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace BotWWorldViewer.Graphics
{
    internal class ShaderProgram3D : ShaderProgram
    {
        private int myViewMatrixLoc;

        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public Camera Camera
        {
            get;
            set;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            myViewMatrixLoc = GL.GetUniformLocation(Program, "view_matrix");
        }

        protected override void OnStartBatch()
        {
            if (Camera != null)
            {
                Matrix4 viewMat = Camera.ViewMatrix;
                GL.UniformMatrix4(myViewMatrixLoc, false, ref viewMat);
            }
        }
    }
}
