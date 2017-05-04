using OpenTK;
using System;

namespace BotWWorldViewer.Graphics
{
    internal class Matrix4ChangedEventArgs : EventArgs
    {
        public readonly Matrix4 Value;

        public Matrix4ChangedEventArgs(Matrix4 value)
        {
            Value = value;
        }
    }

    internal class Vector3ChangedEventArgs : EventArgs
    {
        public readonly Vector3 Value;

        public Vector3ChangedEventArgs(Vector3 value)
        {
            Value = value;
        }
    }

    internal class Vector2ChangedEventArgs : EventArgs
    {
        public readonly Vector2 Value;

        public Vector2ChangedEventArgs(Vector2 value)
        {
            Value = value;
        }
    }

    internal class FloatChangedEventArgs : EventArgs
    {
        public readonly float Value;

        public FloatChangedEventArgs(float value)
        {
            Value = value;
        }
    }

    internal class Camera
    {
        private bool myPerspectiveChanged;
        private bool myViewChanged;

        private Matrix4 myPerspectiveMatrix;
        private Matrix4 myViewMatrix;
        private Vector3 myPosition;
        private Vector2 myRotation;
        private float myViewDistance;
        private float myFieldOfView;
        private float myScreenRatio;

        public Matrix4 PerspectiveMatrix
        {
            get { return myPerspectiveMatrix; }
            set
            {
                myPerspectiveMatrix = value;
                myPerspectiveChanged = false;

                if (PerspectiveChanged != null)
                    PerspectiveChanged(this, new Matrix4ChangedEventArgs(value));
            }
        }

        public Matrix4 ViewMatrix
        {
            get { return myViewMatrix; }
            set
            {
                myViewMatrix = value;
                myViewChanged = false;

                if (ViewChanged != null)
                    ViewChanged(this, new Matrix4ChangedEventArgs(value));
            }
        }

        public Vector3 Position
        {
            get { return myPosition; }
            set
            {
                myPosition = value;
                myViewChanged = true;

                if (PositionChanged != null)
                    PositionChanged(this, new Vector3ChangedEventArgs(value));
            }
        }

        public Vector2 Rotation
        {
            get { return myRotation; }
            set
            {
                myRotation = value;
                myViewChanged = true;

                if (RotationChanged != null)
                    RotationChanged(this, new Vector2ChangedEventArgs(value));
            }
        }

        public float ViewDistance
        {
            get { return myViewDistance; }
            set
            {
                myViewDistance = value;
                ViewDistance2 = value * value;
                myPerspectiveChanged = true;

                if (ViewDistanceChanged != null)
                    ViewDistanceChanged(this, new FloatChangedEventArgs(value));
            }
        }

        public float ViewDistance2
        {
            get;
            private set;
        }

        public float FieldOfView
        {
            get { return myFieldOfView; }
            set
            {
                myFieldOfView = value;
                myPerspectiveChanged = true;

                if (FieldOfViewChanged != null)
                    FieldOfViewChanged(this, new FloatChangedEventArgs(value));
            }
        }

        public float ScreenRatio
        {
            get { return myScreenRatio; }
            set
            {
                myScreenRatio = value;
                myPerspectiveChanged = true;

                if (ScreenRatioChanged != null)
                    ScreenRatioChanged(this, new FloatChangedEventArgs(value));
            }
        }

        public event EventHandler<Matrix4ChangedEventArgs> PerspectiveChanged;
        public event EventHandler<Matrix4ChangedEventArgs> ViewChanged;
        public event EventHandler<Vector3ChangedEventArgs> PositionChanged;
        public event EventHandler<Vector2ChangedEventArgs> RotationChanged;
        public event EventHandler<FloatChangedEventArgs> ViewDistanceChanged;
        public event EventHandler<FloatChangedEventArgs> FieldOfViewChanged;
        public event EventHandler<FloatChangedEventArgs> ScreenRatioChanged;

        public Camera(float fov, float ratio, float viewDist)
        {
            FieldOfView = fov;
            ScreenRatio = ratio;
            ViewDistance = viewDist;

            Position = new Vector3();
            Rotation = new Vector2();

            UpdatePerspectiveMatrix();
            UpdateViewMatrix();
        }

        public void UpdatePerspectiveMatrix()
        {
            if (myPerspectiveChanged)
            {
                PerspectiveMatrix = Matrix4.CreatePerspectiveFieldOfView(
                    myFieldOfView, myScreenRatio, 1.0f / 8.0f, myViewDistance
                );
            }
        }

        public void UpdateViewMatrix()
        {
            if (myViewChanged)
            {
                Matrix4 yRot = Matrix4.CreateRotationY(myRotation.Y);
                Matrix4 xRot = Matrix4.CreateRotationX(myRotation.X);
                Matrix4 trns = Matrix4.CreateTranslation(-myPosition);

                ViewMatrix = Matrix4.Mult(Matrix4.Mult(Matrix4.Mult(trns, yRot), xRot), myPerspectiveMatrix);
            }
        }
    }
}
