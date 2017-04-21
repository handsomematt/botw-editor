namespace BotWFormatReader.Types
{
    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(float xVal, float yVal, float zVal)
        {
            X = xVal;
            Y = yVal;
            Z = zVal;
        }

        public float this[int key]
        {
            get
            {
                if (key == 0) return X;
                if (key == 1) return Y;
                if (key == 2) return Z;
                return 0.0f;
            }
            set {
                if (key == 0) X = value;
                if (key == 1) Y = value;
                if (key == 2) Z = value;
            }
        }
    }
}
