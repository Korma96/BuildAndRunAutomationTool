using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildAndRunAutomationTool.Helper;
using Microsoft.Build.Evaluation;
using BuildAndRunAutomationTool.Constant;
using System.Diagnostics;
using Microsoft.Build.Construction;

namespace BuildAndRunAutomationTool.Service
{
    public class ProjectBuilderService
    {
        public Result<bool> Build(string configuration = GlobalConstants.Debug)
        {
            string solutionPath = GetSolutionPath();

            // read all possible project names from .sln file
            List<string> projectNames = GetProjectNames(solutionPath);

            // choose project name
            Console.WriteLine("Enter project name >> ");
            string projectName = Console.ReadLine();

            // read from config file
            string msbuildPath = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe";
            Environment.SetEnvironmentVariable("MSBUILD_EXE_PATH", msbuildPath);
            //msbuild C:\Projects\Probica\Probica.sln -target:Model: Rebuild
            var result = false;

            if(result)
            {
                return new Result<bool>(result, true, "Build success!");
            }
            else
            {
                return new Result<bool>(result, false, "Build fails!");
            }
        }

        private List<string> GetProjectNames(string solutionPath)
        {
            return new List<string>() { "", "" };
        }

        private string GetSolutionPath()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter solution path >> ");
                string path = Console.ReadLine();

                if (!File.Exists(path))
                {
                    Console.WriteLine("Entered path does not exist!");
                    continue;
                }
                
                if(!path.EndsWith(GlobalConstants.sln))
                {
                    Console.WriteLine("Entered path is not solution path!");
                    continue;
                }
                
                return path;
            }
        }

        private void ShowHeader()
        {
            Console.WriteLine();
            Console.WriteLine("*******************");
            Console.WriteLine("* Project Builder *");
            Console.WriteLine("*******************");
        }
    }
}
