using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAndRunAutomationTool.Helper
{
    public class Result<T>
    {
        public Result(T data)
        {
            Data = data;
            IsSuccess = true;
            Message = string.Empty;
        }

        public Result(T data, bool success)
        {
            Data = data;
            IsSuccess = success;
        }

        public Result(T data, bool success, string message)
        {
            Data = data;
            IsSuccess = success;
            Message = message;
        }

        public T Data { get; private set; }
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
