using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAndRunAutomationTool.Helper
{
    public class Result
    {
        public Result(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }

        public Result(bool success)
        {
            IsSuccess = success;
            Message = string.Empty;
        }

        public string Message { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsFailure
        {
            get
            {
                return !IsSuccess;
            }
        }
    }
}
