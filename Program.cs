using System.Diagnostics;
using System.Text;

namespace LW4
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Executing Task 1...");
            Task1();
            Console.WriteLine("\n");
            Console.WriteLine("Executing Task 2...");
            Task2();
            Console.WriteLine("\n");
            Console.WriteLine("Executing Task 3...");
            Task3();
            Console.WriteLine("\n");
            Console.WriteLine("Program completed!");
            System.Environment.Exit(0);
        }

        static void Task1()
        {
            var filePath = @"C:\Temp\CurrentProcessList.csv";
            Console.WriteLine("Getting process list...");
            Process[] processCollection = Process.GetProcesses();
            StringBuilder sb = new();

            sb.AppendLine("ProcessId,ProcessName");
            foreach (Process p in processCollection)
            {
                sb.AppendLine(string.Format("{0},{1}", p.Id, p.ProcessName));
            }
            Console.WriteLine("Writing process list to a file...");
            File.WriteAllText(filePath, sb.ToString());
            Console.WriteLine("Process list has been succesfully written to a file!");
            Console.WriteLine("Task 1 successfully completed!");
        }
        static void Task2()
        {
            string dateAndTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HH'-'mm'-'ss");
            var filePath = $"C:\\Temp\\TopProcessList_{dateAndTime}";
            Console.WriteLine("Getting process list...");
            Process[] processCollection = Process.GetProcesses();
            Console.WriteLine("Sorting process list by total process time and selecting top 5 processes...");
            _ = processCollection.OrderBy(p => p.TotalProcessorTime).Take(5);
            StringBuilder sb = new();

            sb.AppendLine("Selected process,Total process time");
            foreach (Process p in processCollection)
            {
                try
                {
                    sb.AppendLine(string.Format("{0},{1}", p.ProcessName, p.TotalProcessorTime));
                }
                catch (Exception)
                {
                    Console.WriteLine("Insufficient permissions to run Task 2. Run program as administrator.");
                    return;
                }
            }
            Console.WriteLine("Writing process list to a file...");
            File.WriteAllText(filePath, sb.ToString());
            Console.WriteLine("Process list has been succesfully written to a file!");
            Console.WriteLine("Task 2 successfully completed!");
        }
        static void Task3()
        {
            Console.WriteLine("Checking if notepad is running...");
            Process[] processName = Process.GetProcessesByName("notepad");

            if (processName.Length == 0)
            {
                Console.WriteLine("Notepad is not running.");
            }
            else
            {
                Console.WriteLine("Notepad is running. Would you like to close it? (y/n)");
                string yesOrNo = Console.ReadLine();
                foreach (Process p in processName)
                {
                    if (yesOrNo.Contains('y'))
                    {
                        p.Kill();
                        Console.WriteLine("Notepad successfully closed!");
                    }
                }
            }
            Console.WriteLine("Task 3 successfully completed!");
        }
    }
}