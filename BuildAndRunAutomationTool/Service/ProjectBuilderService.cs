using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildAndRunAutomationTool.Helper;
using Microsoft.Build.Evaluation;
using BuildAndRunAutomationTool.Constant;

namespace BuildAndRunAutomationTool.Service
{
    public class ProjectBuilderService
    {
        private Result Build(string projectPath, string configuration = ProjectBuilderConstants.Debug)
        { 
            if(!File.Exists(projectPath))
            {
                return new Result(false, "Path does not exist!");
            }

            var project = new Project(projectPath);
            project.SetGlobalProperty("Configuration", configuration);
            bool result = project.Build();

            if(result)
            {
                return new Result(project.Build(), "Build success!");
            }
            else
            {
                return new Result(project.Build(), "Build fails!");
            }
        }

        public Result Build()
        {
            ShowHeader();
            string path = GetDirectoryPath();
            return Build(path);
        }

        private string GetDirectoryPath()
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

                if(!path.EndsWith(ProjectBuilderConstants.csproj))
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
            Console.WriteLine("***********************");
            Console.WriteLine("* Bin & Obj destroyer *");
            Console.WriteLine("***********************");
        }
    }
}
