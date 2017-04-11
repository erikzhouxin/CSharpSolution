using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class AlertMsg
    {
        public AlertMsg()
        {
            Message = string.Empty;
        }

        public AlertMsg(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Message = string.Empty;
        }

        public AlertMsg(string message)
        {
            IsSuccess = false;
            Message = string.Empty;
        }

        public bool IsSuccess { get; set; } 

        public string Message { get; set; }
    }
}
