using BotWFormatReader.Common;
using System.IO;

namespace BotWFormatReader.Formats
{
    /// <summary>
    /// Compress and Decompress Yaz0 encoded files.
    /// 
    /// Port of thakis' yaz0dec.cpp and shevious' yaz0enc.cpp for C#. Minor code cleanup in 2015 by Lord Ned (@LordNed) but otherwise
    /// unmodified versions of thakis' and shevious' work. 
    /// </summary>
    public class Yaz0
    {
        /// <summary>
        /// Decode the specified stream as a Yaz0 encoded file and return the decoded data as a MemoryStream.
        /// Throws an <see cref="InvalidDataException"/> if the stream is not positioned to the start of a Yaz0 file.
        /// </summary>
        /// <param name="stream">Stream to read data from.</param>
        /// <returns>Decoded file as <see cref="MemoryStream"/></returns>
        public static MemoryStream Decode(EndianBinaryReader stream)
        {
            if (stream.ReadUInt32() != 0x59617A30) // "Yaz0" Magic
                throw new InvalidDataException("Invalid Magic, not a Yaz0 File");

            int uncompressedSize = stream.ReadInt32();
            stream.ReadBytes(8);

            byte[] output = new byte[uncompressedSize];
            int destPos = 0;

            byte curCodeByte = 0;
            uint validBitCount = 0;

            while (destPos < uncompressedSize)
            {
                // The codeByte specifies what to do for the next 8 steps. Read a new one if we've exhausted the current one.
                if (validBitCount == 0)
                {
                    curCodeByte = stream.ReadByte();
                    validBitCount = 8;
                }

                if ((curCodeByte & 0x80) != 0)
                {
                    // If the bit is set then there is no compression, just write the data to the output.
                    output[destPos] = stream.ReadByte();
                    destPos++;
                }
                else
                {
                    // If the bit is not set, then the data needs to be decompressed. The next two bytes tells the data location and size.
                    // The decompressed data has already been written to the output stream, so we go and retrieve it.
                    byte byte1 = stream.ReadByte();
                    byte byte2 = stream.ReadByte();

                    int dist = ((byte1 & 0xF) << 8) | byte2;
                    int copySource = destPos - (dist + 1);

                    int numBytes = byte1 >> 4;
                    if (numBytes == 0)
                    {
                        // Read the third byte which tells you how much data to read.
                        numBytes = stream.ReadByte() + 0x12;
                    }
                    else
                    {
                        numBytes += 2;
                    }

                    // Copy Run
                    for (int k = 0; k < numBytes; k++)
                    {
                        output[destPos] = output[copySource];
                        copySource++;
                        destPos++;
                    }
                }

                // Use the next bit from the code byte
                curCodeByte <<= 1;
                validBitCount -= 1;
            }

            return new MemoryStream(output);
        }
    }
}
