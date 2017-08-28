using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Net;
using System.Web.Security;
using System.Security.Cryptography;
using System.Threading;

namespace EZOper.NetSiteUtilities.Wepayment
{
    /// <summary>
    /// 历史:
    /// 2017-8-27|JsApiPay->WxPayJsApi
    /// 2017-8-27|重载构造函数并做相应更改
    /// </summary>
    public class WxPayJsApi
    {
        private const string TypeString = "EZOper.NetSiteUtilities.Wepayment.WxPayAPI";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page"></param>
        public WxPayJsApi(Page page) : this(page.Request)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="request"></param>
        public WxPayJsApi(HttpRequest request)
        {
            Code = request.QueryString["code"];
            UrlHost = request.Url.Host;
            Path = request.Path;
            UrlQuery = request.Url.Query;
        }

        /// <summary>
        /// MVC构造函数
        /// </summary>
        /// <param name="request"></param>
        public WxPayJsApi(HttpRequestBase request)
        {
            Code = request.QueryString["code"];
            UrlHost = request.Url.Host;
            Path = request.Path;
            UrlQuery = request.Url.Query;
        }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string UrlHost { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string UrlQuery { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// openid用于调用统一下单接口
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// access_token用于获取收货地址js函数入口参数
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 商品金额，用于统一下单
        /// </summary>
        public int total_fee { get; set; }

        /// <summary>
        /// 统一下单接口返回结果
        /// </summary>
        public WxPayData unifiedOrderResult { get; set; }

        /// <summary>
        /// 网页授权获取用户基本信息的全部过程
        /// 详情请参看网页授权获取用户基本信息：http://mp.weixin.qq.com/wiki/17/c0f37d5704f0b64713d5d2c37b468d75.html
        /// 第一步：利用url跳转获取code
        /// 第二步：利用code去获取openid和access_token
        /// </summary>
        /// <returns>返回RedirectURL,若为空则不跳转</returns>
        public string GetOpenidAndAccessToken()
        {
            if (!string.IsNullOrEmpty(Code))
            {
                //获取code码，以获取openid和access_token
                WxPayLog.Debug(TypeString + ".GetOpenidAndAccessToken", "Get code : " + Code);
                GetOpenidAndAccessTokenFromCode(Code);
            }
            else
            {
                //构造网页授权获取code的URL
                string redirect_uri = HttpUtility.UrlEncode("http://" + UrlHost + Path);
                WxPayData data = new WxPayData();
                data.SetValue("appid", WxPayConfig.APPID);
                data.SetValue("redirect_uri", redirect_uri);
                data.SetValue("response_type", "code");
                data.SetValue("scope", "snsapi_base");
                data.SetValue("state", "STATE" + "#wechat_redirect");
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?" + data.ToUrl();
                WxPayLog.Debug(TypeString + ".GetOpenidAndAccessToken", "Will Redirect to URL : " + url);
                try
                {
                    //触发微信返回code码         
                    return url;//Redirect函数会抛出ThreadAbortException异常，不用处理这个异常
                }
                catch (ThreadAbortException ex)
                {
                    WxPayLog.Error(TypeString + ".GetOpenidAndAccessToken", ex.Message);
                }
            }
            return null;
        }

        /// <summary>
        /// 通过code换取网页授权access_token和openid的返回数据，正确时返回的JSON数据包如下：
        /// {
        ///     "access_token":"ACCESS_TOKEN",
        ///     "expires_in":7200,
        ///     "refresh_token":"REFRESH_TOKEN",
        ///     "openid":"OPENID",
        ///     "scope":"SCOPE",
        ///     "unionid": "o6_bmasdasdsad6_2sgVt7hMZOPfL"
        /// }
        /// 其中access_token可用于获取共享收货地址
        /// openid是微信支付jsapi支付接口统一下单时必须的参数
        /// 更详细的说明请参考网页授权获取用户基本信息：http://mp.weixin.qq.com/wiki/17/c0f37d5704f0b64713d5d2c37b468d75.html
        /// 未实现解读Json信息
        /// </summary>
        /// <param name="code"></param>
        /// <exception cref="WxPayException">异常处理</exception>
        public void GetOpenidAndAccessTokenFromCode(string code)
        {
            try
            {
                //构造获取openid及access_token的url
                WxPayData data = new WxPayData();
                data.SetValue("appid", WxPayConfig.APPID);
                data.SetValue("secret", WxPayConfig.APPSECRET);
                data.SetValue("code", code);
                data.SetValue("grant_type", "authorization_code");
                string url = "https://api.weixin.qq.com/sns/oauth2/access_token?" + data.ToUrl();

                //请求url以获取数据
                string result = WxPayHttpService.Get(url);

                WxPayLog.Debug(TypeString + ".GetOpenidAndAccessTokenFromCode", "GetOpenidAndAccessTokenFromCode response : " + result);

                //保存access_token，用于收货地址获取
                IDictionary<string, object> jd = ToObject(result);
                access_token = (string)jd["access_token"];

                //获取用户openid
                openid = (string)jd["openid"];

                WxPayLog.Debug(TypeString + ".GetOpenidAndAccessTokenFromCode", "Get openid : " + openid + "\nGet access_token : " + access_token);
            }
            catch (Exception ex)
            {
                WxPayLog.ErrorThrow(TypeString + ".GetOpenidAndAccessTokenFromCode", ex.ToString());
            }
        }

        private IDictionary<string, object> ToObject(string result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 调用统一下单，获得下单结果
        /// </summary>
        /// <returns>统一下单结果</returns>
        /// <exception cref="WxPayException">异常处理</exception>
        public WxPayData GetUnifiedOrderResult()
        {
            //统一下单
            WxPayData data = new WxPayData();
            data.SetValue("body", "test");
            data.SetValue("attach", "test");
            data.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());
            data.SetValue("total_fee", total_fee);
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            data.SetValue("goods_tag", "test");
            data.SetValue("trade_type", "JSAPI");
            data.SetValue("openid", openid);

            WxPayData result = WxPayApi.UnifiedOrder(data);
            if (!result.IsSet("appid") || !result.IsSet("prepay_id") || result.GetValue("prepay_id").ToString() == "")
            {
                WxPayLog.ErrorThrow(TypeString + ".GetUnifiedOrderResult", "UnifiedOrder response error!");
            }

            unifiedOrderResult = result;
            return result;
        }

        /// <summary>
        /// 从统一下单成功返回的数据中获取微信浏览器调起jsapi支付所需的参数，
        /// 微信浏览器调起JSAPI时的输入参数格式如下：
        /// {
        ///   "appId" : "wx2421b1c4370ec43b",     //公众号名称，由商户传入     
        ///   "timeStamp":" 1395712654",         //时间戳，自1970年以来的秒数     
        ///   "nonceStr" : "e61463f8efa94090b1f366cccfbbb444", //随机串     
        ///   "package" : "prepay_id=u802345jgfjsdfgsdg888",     
        ///   "signType" : "MD5",         //微信签名方式:    
        ///   "paySign" : "70EA570631E4BB79628FBCA90534C63FF7FADD89" //微信签名 
        /// }
        /// @return string 微信浏览器调起JSAPI时的输入参数，json格式可以直接做参数用
        /// 更详细的说明请参考网页端调起支付API：http://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=7_7
        /// </summary>
        /// <returns></returns>
        public string GetJsApiParameters()
        {
            WxPayLog.Debug(TypeString + ".GetJsApiParameters", "JsApiPay::GetJsApiParam is processing...");

            WxPayData jsApiParam = new WxPayData();
            jsApiParam.SetValue("appId", unifiedOrderResult.GetValue("appid"));
            jsApiParam.SetValue("timeStamp", WxPayApi.GenerateTimeStamp());
            jsApiParam.SetValue("nonceStr", WxPayApi.GenerateNonceStr());
            jsApiParam.SetValue("package", "prepay_id=" + unifiedOrderResult.GetValue("prepay_id"));
            jsApiParam.SetValue("signType", "MD5");
            jsApiParam.SetValue("paySign", jsApiParam.MakeSign());

            string parameters = jsApiParam.ToJson();

            WxPayLog.Debug(TypeString + ".GetJsApiParameters", "Get jsApiParam : " + parameters);
            return parameters;
        }

        /// <summary>
        /// 获取收货地址js函数入口参数,详情请参考收货地址共享接口：http://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=7_9
        /// 调用js获取收货地址时需要传入的参数
        /// 格式：json串
        /// 包含以下字段：
        ///     appid：公众号id
        ///     scope: 填写“jsapi_address”，获得编辑地址权限
        ///     signType:签名方式，目前仅支持SHA1
        ///     addrSign: 签名，由appid、url、timestamp、noncestr、accesstoken参与签名
        ///     timeStamp：时间戳
        ///     nonceStr: 随机字符串
        /// </summary>
        /// <returns>共享收货地址js函数需要的参数，json格式可以直接做参数使用</returns>
        public string GetEditAddressParameters()
        {
            string parameter = "";
            try
            {
                //这个地方要注意，参与签名的是网页授权获取用户信息时微信后台回传的完整url
                string url = "http://" + UrlHost + Path + UrlQuery;

                //构造需要用SHA1算法加密的数据
                WxPayData signData = new WxPayData();
                signData.SetValue("appid", WxPayConfig.APPID);
                signData.SetValue("url", url);
                signData.SetValue("timestamp", WxPayApi.GenerateTimeStamp());
                signData.SetValue("noncestr", WxPayApi.GenerateNonceStr());
                signData.SetValue("accesstoken", access_token);
                string param = signData.ToUrl();

                WxPayLog.Debug(TypeString + ".GetEditAddressParameters", "SHA1 encrypt param : " + param);
                //SHA1加密
                string addrSign = Sha1Hash(param);

                WxPayLog.Debug(TypeString + ".GetEditAddressParameters", "SHA1 encrypt result : " + addrSign);

                //获取收货地址js函数入口参数
                WxPayData afterData = new WxPayData();
                afterData.SetValue("appId", WxPayConfig.APPID);
                afterData.SetValue("scope", "jsapi_address");
                afterData.SetValue("signType", "sha1");
                afterData.SetValue("addrSign", addrSign);
                afterData.SetValue("timeStamp", signData.GetValue("timestamp"));
                afterData.SetValue("nonceStr", signData.GetValue("noncestr"));

                //转为json格式
                parameter = afterData.ToJson();
                WxPayLog.Debug(TypeString + ".GetEditAddressParameters", "Get EditAddressParam : " + parameter);
            }
            catch (Exception ex)
            {
                WxPayLog.ErrorThrow(TypeString + ".GetEditAddressParameters", ex.ToString());
            }

            return parameter;
        }

        /// <summary>
        /// SHA1加密
        /// 替代:FormsAuthentication.HashPasswordForStoringInConfigFile(param, "SHA1");
        /// </summary>
        /// <param name="input">加密字符串</param>
        /// <returns></returns>
        private static string Sha1Hash(string input)
        {
            var md5Hasher = new SHA1CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2").ToUpper());
            }
            return sBuilder.ToString();
        }
    }
}