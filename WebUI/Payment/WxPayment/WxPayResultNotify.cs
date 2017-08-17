using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EZOper.CSharpSolution.WebUI.Payment.WxPayment
{
    /// <summary>
    /// 支付结果通知回调处理类
    /// 负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
    /// ResultNotify
    /// </summary>
    public class WxPayResultNotify : WxPayNotify
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page">页面</param>
        public WxPayResultNotify(Page page) : base(page)
        {
        }

        /// <summary>
        /// MVC构造函数
        /// </summary>
        /// <param name="context"></param>
        public WxPayResultNotify(HttpContextBase context) : base(context)
        {
        }

        /// <summary>
        /// 处理通知
        /// </summary>
        public override void ProcessNotify()
        {
            WxPayData notifyData = GetNotifyData();

            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                var resXml = res.ToXml();
                WxPayLog.Error(this.GetType().ToString(), "The Pay result is error : " + resXml);
                ResponseWriteEnd(resXml);
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();

            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                var resXml = res.ToXml();
                WxPayLog.Error(this.GetType().ToString(), "Order query failure : " + resXml);
                ResponseWriteEnd(resXml);
            }
            //查询订单成功
            else
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");
                var resXml = res.ToXml();
                WxPayLog.Info(this.GetType().ToString(), "order query success : " + resXml);
                ResponseWriteEnd(resXml);
            }
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="transaction_id"></param>
        /// <returns></returns>
        private bool QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}