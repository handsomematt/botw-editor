using NUnit.Framework;
using BotWLib.Common;
using System.IO;
using System.Security.Cryptography;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace BotWLib.Tests
{
    [TestFixture]
    public class Yaz0StreamTest
    {
        static Dictionary<string, string> md5Hashes = new Dictionary<string, string>()
        {
            { "580000C000.hght.stera", "3F-6A-5B-17-96-CE-49-DC-56-D2-1C-B2-23-05-80-10" }
        };

        [Test]
        public void FullDecompressIntegirty()
        {
            var filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestData\\580000C000.hght.sstera";
            var stream = new Yaz0Stream(new FileStream(filePath, FileMode.Open, FileAccess.Read));

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);

            var bufferHash = BitConverter.ToString(MD5.Create().ComputeHash(buffer));
            Assert.AreEqual(bufferHash, md5Hashes["580000C000.hght.stera"]);
        }

        [Test]
        public void RandomSeeking()
        {
            var filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TestData\\580000C000.hght.sstera";
            var stream = new Yaz0Stream(new FileStream(filePath, FileMode.Open, FileAccess.Read));

            stream.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(0x53, stream.ReadByte());
            Assert.AreEqual(0x41, stream.ReadByte());
            Assert.AreEqual(0x52, stream.ReadByte());
            Assert.AreEqual(0x43, stream.ReadByte());

            stream.Seek(20, SeekOrigin.Begin);
            Assert.AreEqual(0x53, stream.ReadByte());
            Assert.AreEqual(0x46, stream.ReadByte());
            Assert.AreEqual(0x41, stream.ReadByte());
            Assert.AreEqual(0x54, stream.ReadByte());

            stream.Seek(16, SeekOrigin.Begin);
            stream.Seek(4, SeekOrigin.Current);
            Assert.AreEqual(0x53, stream.ReadByte());
            Assert.AreEqual(0x46, stream.ReadByte());
            Assert.AreEqual(0x41, stream.ReadByte());
            Assert.AreEqual(0x54, stream.ReadByte());

            stream.Position = 20;
            Assert.AreEqual(0x53, stream.ReadByte());
            Assert.AreEqual(0x46, stream.ReadByte());
            Assert.AreEqual(0x41, stream.ReadByte());
            Assert.AreEqual(0x54, stream.ReadByte());

            stream.Position = 0;
            Assert.AreEqual(0x53, stream.ReadByte());
            Assert.AreEqual(0x41, stream.ReadByte());
            Assert.AreEqual(0x52, stream.ReadByte());
            Assert.AreEqual(0x43, stream.ReadByte());

            stream.Position = 24;
            stream.Seek(-4, SeekOrigin.Current);
            Assert.AreEqual(0x53, stream.ReadByte());
            Assert.AreEqual(0x46, stream.ReadByte());
            Assert.AreEqual(0x41, stream.ReadByte());
            Assert.AreEqual(0x54, stream.ReadByte());

            stream.Seek(-4, SeekOrigin.Current);
            Assert.AreEqual(0x53, stream.ReadByte());
            Assert.AreEqual(0x46, stream.ReadByte());
            Assert.AreEqual(0x41, stream.ReadByte());
            Assert.AreEqual(0x54, stream.ReadByte());

            stream.Seek(524452, SeekOrigin.Begin);
            Assert.AreEqual(0xB8, stream.ReadByte());
            Assert.AreEqual(0x27, stream.ReadByte());
            Assert.AreEqual(0xB9, stream.ReadByte());
            Assert.AreEqual(0x27, stream.ReadByte());

            stream.Seek(-4, SeekOrigin.End);
            Assert.AreEqual(0xB8, stream.ReadByte());
            Assert.AreEqual(0x27, stream.ReadByte());
            Assert.AreEqual(0xB9, stream.ReadByte());
            Assert.AreEqual(0x27, stream.ReadByte());
        }
    }
}
