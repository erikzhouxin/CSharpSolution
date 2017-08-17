using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace EZOper.CSharpSolution.WebUI.Payment.WxPayment
{
    /// <summary>
    /// 回调处理基类
    /// 主要负责接收微信支付后台发送过来的数据，对数据进行签名验证
    /// 子类在此类基础上进行派生并重写自己的回调处理过程
    /// </summary>
    public class WxPayNotify
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page"></param>
        public WxPayNotify(Page page)
        {
            this.page = page;
            IsWebForm = true;
        }

        /// <summary>
        /// MVC的构造函数
        /// </summary>
        /// <param name="context"></param>
        public WxPayNotify(HttpContextBase context)
        {
            this.context = context;
            IsWebForm = false;
        }

        /// <summary>
        /// 是否WebForm
        /// </summary>
        public bool IsWebForm { get; private set; }

        /// <summary>
        /// 页面
        /// </summary>
        public Page page { get; private set; }

        /// <summary>
        /// 环境信息
        /// </summary>
        public HttpContextBase context { get; private set; }

        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        public WxPayData GetNotifyData()
        {
            //接收从微信后台POST过来的数据
            Stream s = GetInputStream();
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            WxPayLog.Info(this.GetType().ToString(), "Receive data from WeChat : " + builder.ToString());

            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builder.ToString());
            }
            catch (WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                var resXml = res.ToXml();
                WxPayLog.Error(this.GetType().ToString(), "Sign check error : " + resXml);
                ResponseWriteEnd(resXml);
            }

            WxPayLog.Info(this.GetType().ToString(), "Check sign success");
            return data;
        }

        /// <summary>
        /// 派生类需要重写这个方法，进行不同的回调处理
        /// </summary>
        public virtual void ProcessNotify()
        {
        }

        /// <summary>
        /// 返回页面数据
        /// </summary>
        /// <param name="resXml"></param>
        protected void ResponseWriteEnd(string resXml)
        {
            if (IsWebForm)
            {
                page.Response.Write(resXml);
                page.Response.End();
            }
            else
            {
                context.Response.Write(resXml);
                context.Response.End();
            }
        }

        /// <summary>
        /// 获取请求数据
        /// </summary>
        /// <returns></returns>
        protected Stream GetInputStream()
        {
            if (IsWebForm)
            {
                return page.Request.InputStream;
            }
            return context.Request.InputStream;
        }
    }
}