using BotWFormatReader.Common;
using System.IO;

namespace BotWFormatReader.Formats
{
    /// <summary>
    /// Decompresses Yaz0-compressed data.
    /// </summary>
    public class Yaz0
    {
        /// <summary>
        /// Decompresses Yaz0-compressed contents from an input <see cref="Stream"/> and writes the output directly
        /// to the output <see cref="MemoryStream"/>.
        /// Throws an <see cref="InvalidDataException"/> if the stream is not positioned to the start of a Yaz0 file.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> containing Yaz0-compressed data.</param>
        /// <param name="output>The output <see cref="MemoryStream"/> to write decompressed data to.</param>
        public static void Decompress(Stream input, MemoryStream output)
        {
            using (EndianBinaryReader reader = new EndianBinaryReader(input, Endian.Big))
            using (EndianBinaryWriter writer = new EndianBinaryWriter(output, Endian.Big))
            {
                if (reader.ReadUInt32() != 0x59617A30) // "Yaz0" Magic
                    throw new InvalidDataException("Invalid Yaz0 header.");

                uint decompressedSize = reader.ReadUInt32();
                reader.BaseStream.Position += 8;

                // Decompress the data.
                int decompressedBytes = 0;
                while (decompressedBytes < decompressedSize)
                {
                    // Read the configuration byte of a decompression setting group, and go through each bit of it.
                    byte groupConfig = reader.ReadByte();
                    for (int i = 7; i >= 0; i--)
                    {
                        // Check if bit of the current chunk is set.
                        if ((groupConfig & (1 << i)) == (1 << i))
                        {
                            // Bit is set, copy 1 raw byte to the output.
                            writer.Write(reader.ReadByte());
                            decompressedBytes++;
                        }
                        else if (decompressedBytes < decompressedSize) // This does not make sense for last byte.
                        {
                            // Bit is not set and data copying configuration follows, either 2 or 3 bytes long.
                            ushort dataBackSeekOffset = reader.ReadUInt16();
                            int dataSize;
                            // If the nibble of the first back seek offset byte is 0, the config is 3 bytes long.
                            byte nibble = (byte)(dataBackSeekOffset >> 12/*1 byte (8 bits) + 1 nibble (4 bits)*/);
                            if (nibble == 0)
                            {
                                // Nibble is 0, the number of bytes to read is in third byte, which is (size + 0x12).
                                dataSize = reader.ReadByte() + 0x12;
                            }
                            else
                            {
                                // Nibble is not 0, and determines (size + 0x02) of bytes to read.
                                dataSize = nibble + 0x02;
                                // Remaining bits are the real back seek offset.
                                dataBackSeekOffset &= 0x0FFF;
                            }
                            // Since bytes can be reread right after they were written, write and read bytes one by one.
                            for (int j = 0; j < dataSize; j++)
                            {
                                // Read one byte from the current back seek position.
                                writer.BaseStream.Position -= dataBackSeekOffset + 1;
                                byte readByte = (byte)writer.BaseStream.ReadByte();
                                // Write the byte to the end of the memory stream.
                                writer.Seek(0, SeekOrigin.End);
                                writer.Write(readByte);
                                decompressedBytes++;
                            }
                        }
                    }
                }
            }
        }
    }
}
