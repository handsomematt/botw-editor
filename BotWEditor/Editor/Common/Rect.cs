namespace BotWEditor.Editor
{
    public struct Rect
    {
        public float Width;
        public float Height;
        public float X;
        public float Y;

        public Rect(float width, float height, float x, float y)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }
    }
}
