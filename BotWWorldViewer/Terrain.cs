using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using BotWWorldViewer.Graphics;

namespace BotWWorldViewer
{
    internal class Terrain
    {
        public int Width { get; set; }
        public int Length { get; set; }

        private float[] vertices;
        private ushort[] indices;

        private ZeldaHeightmap heightMap;

        public VertexBuffer VertexBuffer { get; private set; }

        public Terrain(ZeldaHeightmap heightmap)
        {
            heightMap = heightmap;

            Width = heightMap.Width;
            Length = heightMap.Length;

            VertexBuffer = null;
        }

        public void Render(TerrainShader shader)
        {
            if (VertexBuffer == null || !VertexBuffer.DataSet)
                return;
            
            GL.DrawElements(BeginMode.LineStrip, indices.Length / 3, DrawElementsType.UnsignedShort, 0);
        }

        public void SetupVertexBuffer()
        {
            if (VertexBuffer != null)
                return;

            VertexBuffer = new VertexBuffer(3);

            vertices = new float[Width * Length * 3];
            for (int x = 0; x < Width; x++)
                for (int z = 0; z < Length; z++)
                {
                    vertices[(x * 3 + z * 3 * Width)] = (x * 100.0f);
                    vertices[(x * 3 + z * 3 * Width) + 1] = heightMap.GetHeight(x, z) / 10.0f;
                    vertices[(x * 3 + z * 3 * Width) + 2] = (z * 100.0f);
                }

            indices = new ushort[(Width - 1) * (Length - 1) * 6];
            int counter = 0;
            for (int y = 0; y < Length - 1; y++)
            {
                for (int x = 0; x < Width - 1; x++)
                {
                    ushort lowerLeft = (ushort)(x + y * Width);
                    ushort lowerRight = (ushort)((x + 1) + y * Width);
                    ushort topLeft = (ushort)(x + (y + 1) * Width);
                    ushort topRight = (ushort)((x + 1) + (y + 1) * Width);

                    indices[counter++] = topLeft;
                    indices[counter++] = lowerRight;
                    indices[counter++] = lowerLeft;

                    indices[counter++] = topLeft;
                    indices[counter++] = topRight;
                    indices[counter++] = lowerRight;
                }
            }

            VertexBuffer.SetData(vertices, indices);
        }
    }
}
