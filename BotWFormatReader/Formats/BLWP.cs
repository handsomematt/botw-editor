// Based on code by https://github.com/LordNed

using BotWFormatReader.Common;
using BotWFormatReader.Types;
using System.Collections.Generic;
using System.Diagnostics;

namespace BotWFormatReader
{
    public class BLWP
    {
        public List<BLWPMesh> ObjectInstances { get; private set; }
        public BLWPStringTable StringTable;
        
        public string Magic;
        public int Unknown0;
        public int Unknown1;
        public int Unknown2;
        public int FileSize;
        public int EntryCount;
        public int StringTableOffset;
        public int Padding;

        public BLWP()
        {
            ObjectInstances = new List<BLWPMesh>();
        }

        public void LoadFromStream(EndianBinaryReader reader)
        {
            Magic = reader.ReadChars(4).ToString(); // PrOD todo: sanity checks
            Unknown0 = reader.ReadInt32();
            Unknown1 = reader.ReadInt32();
            Unknown2 = reader.ReadInt32();
            FileSize = reader.ReadInt32();
            EntryCount = reader.ReadInt32();
            StringTableOffset = reader.ReadInt32();
            Padding = reader.ReadInt32();

            // There are EntryCount many InstanceHeaders (+ data) following
            for (int i = 0; i < EntryCount; i++)
            {
                var size = reader.ReadInt32();
                var instanceCount = reader.ReadInt32();
                var stringOffset = reader.ReadInt32();
                Trace.Assert(reader.ReadInt32() == 0);

                // Read the string name for these instances
                long streamPos = reader.BaseStream.Position;
                reader.BaseStream.Position = StringTableOffset + stringOffset;
                string instanceName = reader.ReadStringUntil('\0');

                BLWPMesh instanceHdr = new BLWPMesh();
                instanceHdr.InstanceName = instanceName;
                ObjectInstances.Add(instanceHdr);

                // Jump back to where we were in our stream and read instanceCount many instances of data.
                reader.BaseStream.Position = streamPos;
                for (int j = 0; j < instanceCount; j++)
                {
                    BLWPMeshInstance inst = new BLWPMeshInstance();
                    inst.Position = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    inst.Rotation = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    inst.UniformScale = reader.ReadSingle();
                    instanceHdr.Instances.Add(inst);

                    reader.ReadUInt32();

                }
            }
        }
    }

    public class BLWPMesh
    {
        public string InstanceName;
        public List<BLWPMeshInstance> Instances;
        
        public BLWPMesh()
        {
            Instances = new List<BLWPMeshInstance>();
        }
    }

    /// <summary>
    /// Immediately following the <see cref="BLWPMesh"/> is <see cref="BLWPMesh.InstanceCount"/> many instances of that actor.
    /// Each instance is padded up to 0x32 bytes.
    /// </summary>
    public class BLWPMeshInstance
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public float UniformScale;

        public BLWPMeshInstance()
        {
            UniformScale = 1f;
        }
    }

    /// <summary>
    /// The <see cref="BLWP.StringTableOffset"/> offset is an offset from the start of the file
    /// which points to this class.
    /// </summary>
    public class BLWPStringTable
    {
        public int StringCount; // Number of strings in the String Table
        public int StringTableSize; // Size of string table that follows this header (does not include header). Each string is null terminated and then padded up to the next highest 4 byte alignment (even if null termination falls on 4 byte alignment)
        public string[] Strings;
    }
}
