using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOper.TechTester.JWTOAuthWebSI3
{
    public class JwtTokenAlertMsg
    {
        public JwtTokenAlertMsg() : this(false, string.Empty)
        { }

        public JwtTokenAlertMsg(bool isSuccess) : this(isSuccess, string.Empty)
        { }

        public JwtTokenAlertMsg(string message) : this(false, message)
        { }

        public JwtTokenAlertMsg(bool isSuccess, string message)
        {
            statusCode = isSuccess ? "200" : "400";
            IsSuccess = isSuccess;
            Message = message;
        }

        /// <summary>
        /// 处理结果
        /// </summary>
        public string statusCode { get; set; }

        public string access_token { get; set; }

        public int expires_in { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }

        public bool IsSuccess { get; set; }
    }
}
