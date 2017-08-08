using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.JWTOAuthWebSI
{
    public class AlertMsg
    {
        public AlertMsg()
        {
            IsSuccess = false;
            Message = string.Empty;
        }
        public AlertMsg(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Message = string.Empty;
        }
        public AlertMsg(bool result, string message)
        {
            IsSuccess = result;
            Message = message;
        }

        /// <summary>
        /// 处理结果
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }

    }
}
