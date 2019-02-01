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

namespace BuildAndRunAutomationTool.Service
{
    public class ProjectBuilderService
    {
        private Result Build(string projectPath, string configuration = GlobalConstants.Debug)
        { 
            if(!File.Exists(projectPath))
            {
                return new Result(false, "Path does not exist!");
            }

            Environment.SetEnvironmentVariable("MSBUILD_EXE_PATH", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe");
            Environment.SetEnvironmentVariable("VSINSTALLDIR", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE");
            // msbuild C:\Projects\Probica\Probica.sln /t:Rebuild /p:Configuration=Release /p:Platform="any cpu"
            // msbuild C:\Projects\Probica\Model\Model.csproj /t:Rebuild
            //Environment.SetEnvironmentVariable("VisualStudioVersion", @"15.0");
            var project = new Project(projectPath);
            project.SetGlobalProperty("Configuration", configuration);
            bool result = project.Build();

            if(result)
            {
                return new Result(result, "Build success!");
            }
            else
            {
                return new Result(result, "Build fails!");
            }
        }

        public Result Build()
        {
            ShowHeader();
            string path = GetProjectPath();
            return Build(path);
        }

        private string GetProjectPath()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter project path >> ");
                string path = Console.ReadLine();

                if (!File.Exists(path))
                {
                    Console.WriteLine("Entered path does not existh!");
                    continue;
                }
                
                if(!path.EndsWith(GlobalConstants.csproj))
                {
                    Console.WriteLine("Entered path is not project path!");
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
