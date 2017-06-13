using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using EZOper.TechTester.OWINOAuthWebSI;

namespace EZOper.TechTester.OWINOAuthWebUT.ZApi.OWIN
{
    [TestClass]
    public class OAuthClientUT
    {
        private const string HOST_ADDRESS = "http://localhost:6598";
        private HttpClient _httpClient;

        public OAuthClientUT()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(HOST_ADDRESS);
            Console.WriteLine("HttpClient started!");
        }
        /// <summary>
        /// 授权码模式
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async void OAuth_AuthorizationCode_Test()
        {
            //获取 authorization_code
            var clientId = "xishuai";
            var authResponse = await _httpClient.GetAsync($"/authorize?grant_type=authorization_code&response_type=code&client_id={clientId}&redirect_uri={HttpUtility.UrlEncode(HOST_ADDRESS + "/api/authorization_code")}");
            var authorizationCode = await authResponse.Content.ReadAsStringAsync();
            if (authResponse.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(authResponse.StatusCode);
                Console.WriteLine((await authResponse.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
                Assert.AreEqual(false, true);
            }
            var tokenResponse = GetToken("authorization_code", null, null, null, authorizationCode).Result; //根据 authorization_code 获取 access_token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

            var response = await _httpClient.GetAsync($"/api/values");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine((await response.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
            }
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Thread.Sleep(10000);

            var tokenResponseTwo = GetToken("refresh_token", tokenResponse.RefreshToken).Result; //根据 refresh_token 获取 access_token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponseTwo.AccessToken);
            var responseTwo = await _httpClient.GetAsync($"/api/values");
            Assert.AreEqual(HttpStatusCode.OK, responseTwo.StatusCode);
        }

        #region // 辅助方法
        private async Task<TokenResponse> GetToken(string grantType, string refreshToken = null, string userName = null, string password = null, string authorizationCode = null, string tokenUrl = "/token")
        {
            var clientId = "xishuai";
            var clientSecret = "123";
            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", grantType);

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                parameters.Add("username", userName);
                parameters.Add("password", password);
            }
            if (!string.IsNullOrEmpty(authorizationCode))
            {
                parameters.Add("code", authorizationCode);
                parameters.Add("redirect_uri", HOST_ADDRESS + "/api/authorization_code"); //和获取 authorization_code 的 redirect_uri 必须一致，不然会报错
            }
            if (!string.IsNullOrEmpty(refreshToken))
            {
                parameters.Add("refresh_token", refreshToken);
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));

            var response = await _httpClient.PostAsync(tokenUrl, new FormUrlEncodedContent(parameters));
            var responseValue = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine((await response.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
                return null;
            }
            return await response.Content.ReadAsAsync<TokenResponse>();
        }
        #endregion
    }
}
