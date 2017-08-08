using EZOper.TechTester.JWTOAuthWebSI3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace EZOper.TechTester.JWTOAuthWebSI3.Areas.ZApi.Controllers
{
    public class AuthController : ApiController
    {
        public JwtTokenAlertMsg GetToken(string userName, string password)
        {
            var userModel = new JwtUserViewModel()
            {
                Audience = SysContext.JwtAudience,
                Issuer = SysContext.JwtIssuer,
                SigningKey = SysContext.JwtSigningKey,
                UserName = userName,
                Password = password,
            };
            var service = new AuthValidationService();
            var result = service.GetAuthToken(userModel);

            return result;
        }

        /// <summary>
        /// 通过URI传递数据后返回Token
        /// $.post('http://www.erikzhouxin.com/Api/Auth/PostUriToken?userName=xxx&password=xxx',function(data){})
        /// </summary>
        /// <param name="userName">URL中的userName值</param>
        /// <param name="password">URL中的password值</param>
        /// <returns>[Object]JwtTokenAlertMsg</returns>
        [HttpPost]
        public JwtTokenAlertMsg UriToken([FromUri]string userName, [FromUri]string password)
        {
            var userModel = new JwtUserViewModel()
            {
                Audience = SysContext.JwtAudience,
                Issuer = SysContext.JwtIssuer,
                SigningKey = SysContext.JwtSigningKey,
                UserName = userName,
                Password = password,
            };
            var service = new AuthValidationService();
            var result = service.GetAuthToken(userModel);

            return result;
        }

        /// <summary>
        /// 通过POST的JSON数据映射到动态变量中传递数据后返回Token
        /// $.ajax({type:"post",url:[URL],contentType:'application/json',data:JSON.stringify([JSON]),success:function(data, status){},error:function(data){}});
        /// </summary>
        /// <param name="obj">动态变量对象</param>
        /// <returns>[Object]JwtTokenAlertMsg</returns>
        [HttpPost]
        public JwtTokenAlertMsg PostToken(dynamic obj)
        {
            string userName = Convert.ToString(obj.userName);
            string password = obj.password ?? string.Empty;

            var userModel = new JwtUserViewModel()
            {
                Audience = SysContext.JwtAudience,
                Issuer = SysContext.JwtIssuer,
                SigningKey = SysContext.JwtSigningKey,
                UserName = userName,
                Password = password,
            };
            var service = new AuthValidationService();
            var result = service.GetAuthToken(userModel);

            return result;
        }
    }
}
