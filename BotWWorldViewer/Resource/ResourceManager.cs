using System;
using System.Collections.Generic;

namespace BotWWorldViewer.Resource
{
    internal static class ResourceManager
    {
        private static List<Archive> loadedArchives = new List<Archive>();
        private static Dictionary<string, string> fileMap = new Dictionary<string, string>();

        public static Dictionary<string, string> FileMap
        {
            get
            {
                return fileMap;
            }
        }

        public static List<Archive> LoadedArchives
        {
            get
            {
                return loadedArchives;
            }
        }

        public static void LoadArchive(String filePath)
        {
            var archive = Archive.Load(filePath);
            loadedArchives.Add(archive);

            foreach (var file in archive.FileList)
                fileMap.Add(file.Key, filePath);
        }

        public static bool FileExists(String name)
        {
            foreach (Archive arch in loadedArchives)
                if (arch.ContainsFile(name))
                    return true;

            return false;
        }

        public static FramedStream ReadFile(String name)
        {
            foreach (Archive arch in loadedArchives)
                if (arch.ContainsFile(name))
                    return arch.ReadFile(name);

            return null;
        }
    }
}
