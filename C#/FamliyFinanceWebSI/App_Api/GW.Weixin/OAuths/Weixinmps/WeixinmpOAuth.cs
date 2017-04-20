using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using GW.Weixin.OAuths;
using GW.Weixin.Entitys;
using GW.Weixin.Helpers;
using GW.Weixin.OAuths.Weixinmps.Models;

namespace GW.Weixin.OAuths.Weixinmps
{
    /// <summary>
    /// 腾讯微信协议
    /// <para>管理员后台直接授权方式</para>
    /// </summary>
    public class WeixinmpOAuth : OAuthBase
    {
        #region 属性
        private new string OAuthClientIdKey = "appid";
        private new string OAuthClientSecretKey = "secret";
        private const string OAuthClientIpKey = "clientip";
        private string _openid = String.Empty;


        /// <summary>
        /// 协议节点名称(区分大小写)
        /// </summary>
        public override string OAuthName { get { return "weixinmp"; } }
        /// <summary>
        /// 协议节点描述
        /// </summary>
        public override string OAuthDesc { get { return "腾讯微信公众平台"; } }
        #endregion


        public WeixinmpOAuth()
        {
        }

        public WeixinmpOAuth(string cfgAppName)
        {
        }


        /// <summary>
        /// 获取token参数
        /// </summary>
        /// <returns></returns>
        public override NameValueCollection GetTokenParas()
        {
            NameValueCollection paras = new NameValueCollection();
            paras.Add(OAuthAccessTokenKey, this.AccessToken);
            return paras;
        }

        /// <summary>
        /// 获取授权过的Access Token
        /// <param name="accessTokenUrl">Access Url</param>
        /// </summary>
        public override string GetAccessToken(string accessTokenUrl)
        {
            if (string.IsNullOrEmpty(accessTokenUrl))
            {
                throw new ArgumentNullException(string.Format("accessTokenUrl 为空值"));
            }

            NameValueCollection paras = new NameValueCollection();
            paras.Add(OAuthClientIdKey, this.ClientId);
            paras.Add(OAuthClientSecretKey, this.ClientSecret);
            paras.Add(OAuthGrantTypeKey, "client_credential");
            return HttpHelper.HttpGet(accessTokenUrl, paras);
        }

        /// <summary>
        /// 获取授权过的Access Token
        /// </summary>
        public override ApiToken GetAccessToken()
        {
            string accessTokenUrl = OAuthConfig.GetConfigAPI(OAuthName, this.App.AppName, OAuthAccessTokenKey);
            string response = GetAccessToken(accessTokenUrl);
            var token = Helpers.UtilHelper.ParseJson<WeixinMToken>(response);
            var api = new ApiToken();
            api.expires_in = token.expires_in;
            api.access_token = token.access_token;
            api.errcode = Convert.ToString(token.errcode);
            api.ret = token.errcode;
            api.msg = token.errmsg;
            return api;
        }
    }
}
/*
 * Author: xusion
 * Created: 2012.07.25
 * Support: http://wobumang.com
 */