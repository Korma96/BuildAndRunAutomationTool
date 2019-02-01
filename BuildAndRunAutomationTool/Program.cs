using BuildAndRunAutomationTool.Constant;
using BuildAndRunAutomationTool.Helper;
using BuildAndRunAutomationTool.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAndRunAutomationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("*** Choose option ***");
                Console.WriteLine("1) Rebuild projects");
                Console.WriteLine("2) Run projects");
                Console.WriteLine("3) Quit");
                Console.Write(">> ");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        InvokeBuildService();
                        break;

                    case "2":
                        InvokeRunService();
                        break;

                    case "3":
                        return;
                }
            }
        }

        private static void InvokeBinAndObjService()
        {
            var service = new BinAndObjDestroyerService();
            while (true)
            {
                int[] result = service.DeleteBinsAndObjs(true);
                Console.WriteLine("Number of deleted bins: " + result[0]);
                Console.WriteLine("Number of deleted objs: " + result[1]);

                if(GetPotentiallyExitKey().Equals(GlobalConstants.QuitCharacter))
                {
                    break;
                }
            }
        }

        private static string GetPotentiallyExitKey()
        {
            Console.Write(string.Format("Press any key to continue, '{0}' to quit >> ", GlobalConstants.QuitCharacter));
            return Console.ReadLine();
        }

        private static void InvokeBuildService()
        {
            var service = new ProjectBuilderService();
            while(true)
            {
                Result result = service.Build();
                Console.WriteLine(result.Message);

                if (GetPotentiallyExitKey().Equals(GlobalConstants.QuitCharacter))
                {
                    break;
                }
            }

        }

        private static void InvokeRunService()
        {
            var service = new ProjectRunnerService();
            service.Run();
        }
    }
}
