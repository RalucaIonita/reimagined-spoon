using System;
using System.IO;
using System.Linq;

namespace ShellDummie
{
    public static class DirectoryMethods
    {
        public static void ChangeDirectory(string newPath)
        {
            try
            {
                Directory.SetCurrentDirectory(newPath);
            }
            catch (Exception)
            {
                Console.WriteLine("Directory not found.");
            }
        }

        public static void DeleteDirectory(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath);
            }
            catch (Exception)
            {
                Console.WriteLine("Directory not found.");
            }
        }

        public static void ListAll(string path)
        {
            try
            {
                var directories = Directory.GetDirectories(path);
                var files = Directory.GetFiles(path);
                var items = files.Concat(directories).OrderBy(x => x);
                foreach (var item in items)
                    Console.WriteLine(item.Split(@"\").Last());
            }
            catch (Exception)
            {
                Console.WriteLine("Directory not found.");
            }
        }

        public static void MakeDirectory(string name)
        {
            try
            {
                Directory.CreateDirectory(name);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not create directory");
            }
        }
    }
}
