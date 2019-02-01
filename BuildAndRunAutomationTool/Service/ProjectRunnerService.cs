using BuildAndRunAutomationTool.Constant;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAndRunAutomationTool.Service
{
    public class ProjectRunnerService
    {
        public void Run()
        {
            string path = GetExePath();
            Process.Start(path);
        }

        private string GetExePath()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter project exe path >> ");
                string path = Console.ReadLine();

                if (!File.Exists(path))
                {
                    Console.WriteLine("Entered path does not exist!");
                    continue;
                }

                if (!path.EndsWith(GlobalConstants.exe))
                {
                    Console.WriteLine("Entered path is not exe path!");
                    continue;
                }

                return path;
            }
        }
    }
}
