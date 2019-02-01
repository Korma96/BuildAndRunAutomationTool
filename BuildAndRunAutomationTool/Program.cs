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
                Console.WriteLine("1) Delete bins and objs");
                Console.WriteLine("2) Build projects");
                Console.WriteLine("3) Run projects");
                Console.WriteLine("4) Quit");
                Console.Write(">> ");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        InvokeBinAndObjService();
                        break;
                  
                    case "2":
                        InvokeBuildService();
                        break;

                    case "3":
                        InvokeRunService();
                        break;

                    case "4":
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
            Console.WriteLine("Run service not implemented!");
        }
    }
}
