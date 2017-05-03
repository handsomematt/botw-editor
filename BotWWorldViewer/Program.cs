﻿using BotWLib.Common;
using BotWWorldViewer.Resource;
using System;
using System.Diagnostics;
using System.IO;

namespace BotWWorldViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
                Directory.SetCurrentDirectory(args[0]);

            Console.Write("Loading MainField archives... ");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var archives = Directory.EnumerateFiles("Terrain/A/MainField");
            foreach (var archive in archives)
            {
                ResourceManager.LoadArchive(archive);
            }
            sw.Stop();
            
            Console.WriteLine(" Done! Time elapsed: {0}ms", sw.ElapsedMilliseconds);
            Console.WriteLine("Mapped {0} files across {1} archives.", ResourceManager.FileMap.Count, ResourceManager.LoadedArchives.Count);

            if (!ResourceManager.FileExists("580000C000.hght"))
            {
                Console.WriteLine("Could not find 580000C000.hght");
                Environment.Exit(1);
            }

            FramedStream fileStream = ResourceManager.ReadFile("580000C000.hght");

            Console.WriteLine("580000C000.hght is {0} bytes long, position is set to {1} ({2})", fileStream.Length, fileStream.Position, fileStream.GlobalPosition);

            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);

            ViewerWindow window = new ViewerWindow();
            window.Run();
            window.Dispose();
        }
    }
}
