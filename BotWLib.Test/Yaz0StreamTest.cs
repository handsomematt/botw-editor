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
    }
}
