using System;
using System.Collections.Generic;
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

                var directoryCommands = new List<string>() { "changeDir", "deleteDir", "listFiles", "makeDir" };
                var processComamnds = new List<string>() { "listProc", "killProc" };

                Thread.Sleep(200);
                var currentPath = Directory.GetCurrentDirectory();
                Console.Write($"{currentPath}>");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var argument = "";
                var command = line;

                if (line.Contains(" "))
                {
                    argument = line.Remove(0, line.IndexOf(" ") + 1);
                    command = line.Remove(line.IndexOf(" "));
                }

                if(directoryCommands.Contains(command))
                {
                    ExecuteDirectories(command, currentPath, argument);
                    continue;
                }

                if (processComamnds.Contains(command))
                {
                    ExecuteProcesses(command, argument);
                    continue;
                }
                Console.WriteLine("Command is not recognized.");


            }
        }


        private static void ExecuteDirectories(string command, string currentPath,  string path)
        {
            switch (command)
            {
                case "changeDir":
                    path = Path.Combine(currentPath, path);
                    DirectoryMethods.ChangeDirectory(path);
                    break;
                case "deleteDir":
                    DirectoryMethods.DeleteDirectory(path);
                    break;
                case "listAll":
                    DirectoryMethods.ListAll(currentPath);
                    break;
                case "makeDir":
                    path = Path.Combine(currentPath, path);
                    DirectoryMethods.MakeDirectory(path);
                    break;
            }
        }

        private static void ExecuteProcesses(string command, string argument = "")
        {
            switch (command)
            {
                case "listProc":
                    ProcessMethods.ListAllBackgroundProcesses();
                    break;
                case "killProc":
                    var processId = int.Parse(argument);
                    ProcessMethods.KillProcess(processId);
                    break;
                default:
                    return;
            }
        }

    }
}
