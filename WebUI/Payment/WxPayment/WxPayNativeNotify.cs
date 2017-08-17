﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EZOper.CSharpSolution.WebUI.Payment.WxPayment
{
    /// <summary>
    /// 扫码支付模式一回调处理类
    /// 接收微信支付后台发送的扫码结果，调用统一下单接口并将下单结果返回给微信支付后台
    /// NativeNotify
    /// </summary>
    public class WxPayNativeNotify : WxPayNotify
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page"></param>
        public WxPayNativeNotify(Page page) : base(page)
        {
        }

        /// <summary>
        /// MVC构造函数
        /// </summary>
        /// <param name="context"></param>
        public WxPayNativeNotify(HttpContextBase context) : base(context)
        {
        }

        /// <summary>
        /// 处理通知
        /// </summary>
        public override void ProcessNotify()
        {
            WxPayData notifyData = GetNotifyData();

            //检查openid和product_id是否返回
            if (!notifyData.IsSet("openid") || !notifyData.IsSet("product_id"))
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "回调数据异常");
                var resXml = res.ToXml();
                WxPayLog.Info(this.GetType().ToString(), "The data WeChat post is error : " + resXml);
                ResponseWriteEnd(resXml);
            }

            //调统一下单接口，获得下单结果
            string openid = notifyData.GetValue("openid").ToString();
            string product_id = notifyData.GetValue("product_id").ToString();
            WxPayData unifiedOrderResult = new WxPayData();
            try
            {
                unifiedOrderResult = UnifiedOrder(openid, product_id);
            }
            catch (Exception ex)//若在调统一下单接口时抛异常，立即返回结果给微信支付后台
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                var resXml = res.ToXml();
                WxPayLog.Error(this.GetType().ToString(), "UnifiedOrder failure : " + resXml + "\n===========>" + ex.Message);
                ResponseWriteEnd(resXml);
            }

            //若下单失败，则立即返回结果给微信支付后台
            if (!unifiedOrderResult.IsSet("appid") || !unifiedOrderResult.IsSet("mch_id") || !unifiedOrderResult.IsSet("prepay_id"))
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                var resXml = res.ToXml();
                WxPayLog.Error(this.GetType().ToString(), "UnifiedOrder failure : " + resXml);
                ResponseWriteEnd(resXml);
            }

            //统一下单成功,则返回成功结果给微信支付后台
            WxPayData data = new WxPayData();
            data.SetValue("return_code", "SUCCESS");
            data.SetValue("return_msg", "OK");
            data.SetValue("appid", WxPayConfig.AppID);
            data.SetValue("mch_id", WxPayConfig.MchID);
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
            data.SetValue("prepay_id", unifiedOrderResult.GetValue("prepay_id"));
            data.SetValue("result_code", "SUCCESS");
            data.SetValue("err_code_des", "OK");
            data.SetValue("sign", data.MakeSign());

            var dataXml = data.ToXml();
            WxPayLog.Info(this.GetType().ToString(), "UnifiedOrder success , send data to WeChat : " + dataXml);
            ResponseWriteEnd(dataXml);
        }

        private WxPayData UnifiedOrder(string openId, string productId)
        {
            //统一下单
            WxPayData req = new WxPayData();
            req.SetValue("body", "test");
            req.SetValue("attach", "test");
            req.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());
            req.SetValue("total_fee", 1);
            req.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            req.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            req.SetValue("goods_tag", "test");
            req.SetValue("trade_type", "NATIVE");
            req.SetValue("openid", openId);
            req.SetValue("product_id", productId);
            WxPayData result = WxPayApi.UnifiedOrder(req);
            return result;
        }
    }
}