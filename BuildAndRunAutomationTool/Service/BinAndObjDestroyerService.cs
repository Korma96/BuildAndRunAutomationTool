using BuildAndRunAutomationTool.Constant;
using BuildAndRunAutomationTool.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAndRunAutomationTool.Service
{
    public class BinAndObjDestroyerService
    {
        private int numOfBinDirsDeleted;
        private int numOfObjDirsDeleted;

        public int[] DeleteBinsAndObjs(bool ignoreCase = false)
        {
            numOfBinDirsDeleted = 0;
            numOfObjDirsDeleted = 0;
            ShowHeader();
            string path = GetDirectoryPath();
            DeletingLevel deletingLevel = GetDeletingLevel();
            DoDeleteBinsAndObjs(path, deletingLevel, ignoreCase);
            return new int[] { numOfBinDirsDeleted, numOfObjDirsDeleted };
        }

        private void DoDeleteBinsAndObjs(string dirPath, DeletingLevel deletingLevel, bool ignoreCase)
        {
            foreach (var dir in Directory.GetDirectories(dirPath))
            {
                string dirName = Path.GetFileName(dir);
                if (ignoreCase)
                {
                    dirName = dirName.ToLower();
                }

                if (dirName.Equals(GlobalConstants.bin) || dirName.Equals(GlobalConstants.obj))
                {
                    if (dirName.Equals(GlobalConstants.bin))
                    {
                        numOfBinDirsDeleted += 1;
                    }
                    else if (dirName.Equals(GlobalConstants.obj))
                    {
                        numOfObjDirsDeleted += 1;
                    }

                    Directory.Delete(dir, true);
                }
                else
                {
                    if (deletingLevel == DeletingLevel.DEEP)
                    {
                        DoDeleteBinsAndObjs(dir, deletingLevel, ignoreCase);
                    }
                }
            }
        }

        private string GetDirectoryPath()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter directory path >> ");
                string path = Console.ReadLine();

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Entered path is not directory path!");
                    continue;
                }

                return path;
            }
        }

        private DeletingLevel GetDeletingLevel()
        {
            while (true)
            {
                Console.Write("Do you want deep or shallow deleting lvl?(d/s) >> ");
                string decision = Console.ReadLine();

                switch (decision)
                {
                    case "s":
                        return DeletingLevel.SHALLOW;
                    case "d":
                        return DeletingLevel.DEEP;
                    default:
                        continue;
                }
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
