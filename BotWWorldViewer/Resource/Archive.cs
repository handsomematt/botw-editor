using BotWLib.Common;
using BotWLib.Formats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BotWWorldViewer.Resource
{
    internal class Archive
    {
        private Stream archiveFileStream;

        private ArchiveHeader archiveHeader;
        private class ArchiveHeader
        {
            public ushort Length;
            public uint FileSize;
            public uint DataOffset;

            public ArchiveHeader(EndianBinaryReader er)
            {
                if (new string(er.ReadChars(4)) != "SARC") throw new InvalidDataException("Invalid SARC header.");
                Length = er.ReadUInt16();
                er.ReadUInt16(); // bom
                FileSize = er.ReadUInt32();
                DataOffset = er.ReadUInt32();
                er.ReadUInt32(); // unk
            }
        }

        private SFATHeader sfatHeader;
        private class SFATHeader
        {
            public ushort Length;
            public ushort NodeCount;
            public uint HashMultiplier;

            public SFATHeader(EndianBinaryReader er)
            {
                if (new string(er.ReadChars(4)) != "SFAT") throw new InvalidDataException("Invalid SFAT header.");
                Length = er.ReadUInt16();
                NodeCount = er.ReadUInt16();
                HashMultiplier = er.ReadUInt32();
            }
        }

        private SFATEntry[] sfatEntries;
        private class SFATEntry
        {
            public string FileName;
            public uint FileNameHash;
            public byte FileType;
            public uint FileNameTableOffset;
            public uint DataOffsetStart;
            public uint DataOffsetEnd;

            public SFATEntry(EndianBinaryReader er)
            {
                FileNameHash = er.ReadUInt32();
                uint data = er.ReadUInt32();
                FileType = (byte)(data & 0xFF000000);
                FileNameTableOffset = data & 0x00FFFFFF;
                DataOffsetStart = er.ReadUInt32();
                DataOffsetEnd = er.ReadUInt32();
            }
        }

        private string[] sfatStringTable;

        private Dictionary<string, ArchiveEntry> fileDictionary;
        public Dictionary<string, ArchiveEntry> FileList
        {
            get
            {
                return fileDictionary;
            }
        }
        public class ArchiveEntry
        {
            public readonly string Name;
            public readonly uint Offset;
            public readonly uint Size;
            public readonly byte Type;

            public ArchiveEntry(string name, uint offset, uint size, byte type)
            {
                Name = name;
                Offset = offset;
                Size = size;
                Type = type;
            }
        }

        public Archive(Stream stream)
        {
            byte[] header = new byte[4];
            stream.Read(header, 0, 4);
            stream.Seek(-4, SeekOrigin.Current);

            if (header[0] == 'Y')
            {
                archiveFileStream = new MemoryStream();
                Yaz0.Decompress(stream, (MemoryStream)archiveFileStream); // need to do something better then this whacky shit, need a just in time reader
                stream.Close();
                stream.Dispose();
                stream = null;
            }
            else
            {
                archiveFileStream = stream;
            }

            using (EndianBinaryReader er = new EndianBinaryReader(archiveFileStream, Encoding.ASCII, true, Endian.Big))
            {
                archiveHeader = new ArchiveHeader(er);
                sfatHeader = new SFATHeader(er);

                sfatEntries = new SFATEntry[sfatHeader.NodeCount];
                for (int i = 0; i < sfatHeader.NodeCount; i++)
                    sfatEntries[i] = new SFATEntry(er);

                er.Skip(8); // SFNT, 0x00, 0x08, 0x00, 0x00

                sfatStringTable = new string[sfatHeader.NodeCount];
                for (int i = 0; i < sfatHeader.NodeCount; i++)
                {
                    // These strings are aligned to 4 bytes.
                    while (er.PeekReadByte() == 0)
                        er.ReadByte();

                    sfatStringTable[i] = Encoding.ASCII.GetString(er.ReadBytesUntil(0));
                }
            }

            for (int i = 0; i < sfatEntries.Length; i++)
                sfatEntries[i].FileName = sfatStringTable[sfatEntries[i].FileNameTableOffset / 4];

            fileDictionary = new Dictionary<string, ArchiveEntry>(sfatEntries.Length);

            for (int i = 0; i < sfatEntries.Length; i++)
            {
                string name = sfatStringTable[sfatEntries[i].FileNameTableOffset / 4];
                uint size = sfatEntries[i].DataOffsetEnd - sfatEntries[i].DataOffsetStart;

                fileDictionary.Add(name, new ArchiveEntry(name, sfatEntries[i].DataOffsetStart + archiveHeader.DataOffset, size, sfatEntries[i].FileType));
            }
        }

        public static Archive Load(String filePath)
        {
            return new Archive(new FileStream(filePath, FileMode.Open, FileAccess.Read));
        }

        public bool ContainsFile(string name)
        {
            return fileDictionary.ContainsKey(name);
        }

        public FramedStream ReadFile(string name)
        {
            var entry = fileDictionary[name];
            FramedStream stream = new FramedStream(archiveFileStream, entry.Offset, entry.Size);
            return stream;
        }
    }
}
