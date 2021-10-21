using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace ShellDummie
{
    class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                //changeDir
                //deleteDir
                //listFiles
                //makeDir

                Thread.Sleep(200);
                var currentPath = Directory.GetCurrentDirectory();
                Console.Write($"{currentPath}>");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var path = "";
                var command = line;

                if (line.Contains(" "))
                {
                    path = line.Remove(0, line.IndexOf(" ") + 1);
                    command = line.Remove(line.IndexOf(" "));
                }

                switch (command)
                {
                    case "changeDir":
                        path = Path.Combine(currentPath, path);
                        ChangeDirectory(path);
                        break;
                    case "deleteDir":
                        DeleteDirectory(path);
                        break;
                    case "listAll":
                        ListAll(currentPath);
                        break;
                    case "makeDir":
                        path = Path.Combine(currentPath, path);
                        MakeDirectory(path);
                        break;
                    default:
                        Console.WriteLine("Command is not recognized.");
                        continue;
                }
                
            }
        }

        private static void ChangeDirectory(string newPath)
        {
            try
            {
                Directory.SetCurrentDirectory(newPath);
            }
            catch(Exception)
            {
                Console.WriteLine("Directory not found.");
            }
        }

        private static void DeleteDirectory(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath);
            }
            catch(Exception)
            {
                Console.WriteLine("Directory not found.");
            }
        }

        private static void ListAll(string path)
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

        private static void MakeDirectory(string name)
        {
            try
            {
                Directory.CreateDirectory(name);
            }
            catch(Exception)
            {
                Console.WriteLine("Could not create directory");
            }
        }
    }
}
