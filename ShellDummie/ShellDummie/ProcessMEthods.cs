using System;
using System.Diagnostics;

namespace ShellDummie
{
    public static class ProcessMethods
    {
        public static void ListAllBackgroundProcesses()
        {
            var processes = Process.GetProcesses();
            foreach(var process in processes)
            {
                Console.WriteLine($"{process.ProcessName}   {process.Id}");
            }
        }

        public static void KillProcess(int id)
        {
            var process = Process.GetProcessById(id);
            process.Kill();
        }
    }
}
