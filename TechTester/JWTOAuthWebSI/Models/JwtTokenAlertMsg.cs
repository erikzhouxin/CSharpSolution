using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOper.TechTester.JWTOAuthWebSI
{
    public class JwtTokenAlertMsg
    {
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
    }
}
