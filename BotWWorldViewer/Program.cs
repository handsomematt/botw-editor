using BotWLib.Formats;
using BotWWorldViewer.Resource;
using System;
using System.IO;

namespace BotWWorldViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
                Directory.SetCurrentDirectory(args[0]);

            Console.Write("Loading archives");

            foreach (var archive in Directory.EnumerateFiles("Terrain/A/MainField"))
            {
                ResourceManager.LoadArchive(archive);
                Console.Write(".");

                GC.Collect();
            }
            
            Console.WriteLine(" Done!");

            var writer = File.AppendText("MainField.txt");

            foreach (var mappedFile in ResourceManager.FileMap)
                writer.WriteLine("{0}/{1}", mappedFile.Value, mappedFile.Key);

            writer.Close();
            
            //ViewerWindow window = new ViewerWindow();
            //window.Run();
            //window.Dispose();
        }
    }
}
