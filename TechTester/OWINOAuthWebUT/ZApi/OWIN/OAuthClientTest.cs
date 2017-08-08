using EZOper.TechTester.OWINOAuthWebSI;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Xunit;

namespace EZOper.TechTester.OWINOAuthWebUT.ZApi.OWIN
{
    public class OAuthClientTest
    {
        private const string HOST_ADDRESS = "http://localhost:29367";
        //private IDisposable _webApp;
        private static HttpClient _httpClient;

        public OAuthClientTest()
        {
            //_webApp = WebApp.Start<Startup>(HOST_ADDRESS);
            //Console.WriteLine("Web API started!");
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(HOST_ADDRESS);
            Console.WriteLine("HttpClient started!");
        }

        /// <summary>
        /// 客户端模式
        /// </summary>
        /// <returns></returns>
        //[Fact]
        public async Task OAuth_ClientCredentials_Test()
        {
            var tokenResponse = GetToken("client_credentials", null, null, null, null, "/client_token").Result; //获取 access_token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

            var response = await _httpClient.GetAsync($"/api/values");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine((await response.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
            }
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Thread.Sleep(10000);

            var tokenResponseTwo = GetToken("refresh_token", tokenResponse.RefreshToken).Result;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponseTwo.AccessToken);
            var responseTwo = await _httpClient.GetAsync($"/api/values");
            Assert.Equal(HttpStatusCode.OK, responseTwo.StatusCode);
        }

        /// <summary>
        /// 密码模式
        /// </summary>
        /// <returns></returns>
        //[Fact]
        public async Task OAuth_Password_Test()
        {
            var tokenResponse = GetToken("password", null, "xishuai", "123", null, "/rowner_token").Result; //获取 access_token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

            var response = await _httpClient.GetAsync($"/api/values");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine((await response.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
            }
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Thread.Sleep(10000);

            var tokenResponseTwo = GetToken("refresh_token", tokenResponse.RefreshToken, null, null, null, "/rowner_token").Result;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponseTwo.AccessToken);
            var responseTwo = await _httpClient.GetAsync($"/api/values");
            Assert.Equal(HttpStatusCode.OK, responseTwo.StatusCode);
        }

        /// <summary>
        /// 授权码模式
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task OAuth_AuthorizationCode_Test()
        {
            //获取 authorization_code
            var clientId = "xishuai";
            var asyncString = $"/authorize?grant_type=authorization_code&response_type=code&client_id={clientId}&redirect_uri={HttpUtility.UrlEncode(HOST_ADDRESS + "/api/authorization_code")}";
            var authResponse = await _httpClient.GetAsync(asyncString);
            var authorizationCode = await authResponse.Content.ReadAsStringAsync();
            if (authResponse.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(authResponse.StatusCode);
                Console.WriteLine((await authResponse.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
                Assert.Equal(false, true);
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
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Thread.Sleep(10000);

            var tokenResponseTwo = GetToken("refresh_token", tokenResponse.RefreshToken).Result; //根据 refresh_token 获取 access_token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponseTwo.AccessToken);
            var responseTwo = await _httpClient.GetAsync($"/api/values");
            Assert.Equal(HttpStatusCode.OK, responseTwo.StatusCode);
        }

        /// <summary>
        /// 简单模式
        /// </summary>
        /// <returns></returns>
        //[Fact]
        public async Task OAuth_Implicit_Test()
        {
            var clientId = "xishuai";

            var tokenResponse = await _httpClient.GetAsync($"/implicate_authorize?response_type=token&client_id={clientId}&redirect_uri={HttpUtility.UrlEncode(HOST_ADDRESS + "/api/access_token")}");
            //redirect_uri: HOST_ADDRESS + "/api/access_token#access_token=AQAAANCMnd8BFdERjHoAwE_Cl-sBAAAAfoPB4HZ0PUe-X6h0UUs2q42&token_type=bearer&expires_in=10
            var accessToken = string.Empty;//get form redirect_uri
            var urlParams = tokenResponse.RequestMessage.RequestUri.Fragment.TrimStart('#');
            foreach (var item in urlParams.Split('&'))
            {
                if (item.StartsWith("access_token="))
                {
                    accessToken = item.Replace("access_token=", "");
                }
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"/api/values");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine((await response.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
            }
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #region // 辅助方法
        private static async Task<TokenResponse> GetToken(string grantType, string refreshToken = null, string userName = null, string password = null, string authorizationCode = null, string tokenUrl = "/token")
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
