using OpenTK;

namespace BotWEditor.Editor.Components
{
    public class Transform : BaseComponent
    {
        public Transform()
        {
            Position = Vector3.Zero;
            Rotation = Quaternion.Identity;
            Rotate(Up, 180f);
            Scale = Vector3.One;
        }

        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;

        public Vector3 Right
        {
            get { return Rotation.Mult(Vector3.UnitX); }
        }

        public Vector3 Forward
        {
            get { return Rotation.Mult(Vector3.UnitZ); }
        }

        public Vector3 Up
        {
            get { return Rotation.Mult(Vector3.UnitY); }
        }

        public void LookAt(Vector3 worldPosition)
        {
            Rotation = Quaternion.FromAxisAngle((Position - worldPosition).Normalized(), 0f);
        }

        public void Rotate(Vector3 axis, float angleInDegrees)
        {
            Quaternion rotQuat = Quaternion.FromAxisAngle(axis, MathHelper.DegreesToRadians(angleInDegrees));
            Rotation = rotQuat * Rotation;
        }

        public void Translate(Vector3 amount)
        {
            Position += amount;
        }
    }
}
