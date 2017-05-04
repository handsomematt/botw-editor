using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BotWLib.Common;

namespace BotWWorldViewer
{
    /// <summary>
    /// The height maps used in Zelda are generally 256 x 256
    /// And use a 2 byte half-float to define the height.
    /// This class offers a quick way to read a provided byte[].
    /// </summary>
    internal class ZeldaHeightmap
    {
        private ushort[] heightmap;
        private int width;
        private int height;

        public int Width
        {
            get { return width; }
        }

        public int Length
        {
            get { return height; }
        }


        public ZeldaHeightmap(byte[] _heightmap)
        {
            heightmap = new ushort[_heightmap.Length / 2];

            for (int i = 0; i < heightmap.Length; i++)
                heightmap[i] = BitConverter.ToUInt16(_heightmap, i * 2);

            // todo: maybe these could be dynamic
            width = 256;
            height = 256;
        }

        public ushort GetHeight(int x, int y)
        {
            return heightmap[(y * Length) + x];
        }
    }
}
