using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace EZOper.NetSiteUtilities.Wepayment
{
    /// <summary>
    /// 微信支付业务处理
    /// 历史:
    /// 2017-8-27|NEW
    /// </summary>
    public class WxPayApiBiz
    {
        private const string TypeString = "EZOper.NetSiteUtilities.Wepayment.WxPayAPI.WxPayBiz";
        #region // OrderQuery.cs
        /// <summary>
        /// 订单查询完整业务流程逻辑
        /// OrderQuery.Run
        /// </summary>
        /// <param name="transaction_id">微信订单号（优先使用）</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// <returns>订单查询结果（xml格式）</returns>
        public static string OrderQuery(string transaction_id, string out_trade_no)
        {
            WxPayLog.Info("OrderQuery", "OrderQuery is processing...");

            WxPayData data = new WxPayData();
            if (!string.IsNullOrEmpty(transaction_id))//如果微信订单号存在，则以微信订单号为准
            {
                data.SetValue("transaction_id", transaction_id);
            }
            else//微信订单号不存在，才根据商户订单号去查单
            {
                data.SetValue("out_trade_no", out_trade_no);
            }

            WxPayData result = WxPayApi.OrderQuery(data);//提交订单查询请求给API，接收返回数据

            WxPayLog.Info("OrderQuery", "OrderQuery process complete, result : " + result.ToXml());
            return result.ToPrintStr();
        }
        #endregion
        #region // DownloadBill.cs
        /// <summary>
        /// 下载对账单完整业务流程逻辑
        /// DownloadBill.Run
        /// </summary>
        /// <param name="bill_date">下载对账单的日期（格式：20140603，一次只能下载一天的对账单）</param>
        /// <param name="bill_type">
        /// 账单类型
        /// ALL，返回当日所有订单信息，默认值 
        /// SUCCESS，返回当日成功支付的订单
        /// REFUND，返回当日退款订单
        /// REVOKED，已撤销的订单
        /// </param>
        /// <returns>对账单结果（xml格式）</returns>
        public static string DownloadBill(string bill_date, string bill_type)
        {
            var methodString = TypeString + ".DownloadBill";
            WxPayLog.Info(methodString, "DownloadBill is processing...");

            WxPayData data = new WxPayData();
            data.SetValue("bill_date", bill_date);//账单日期
            data.SetValue("bill_type", bill_type);//账单类型
            WxPayData result = WxPayApi.DownloadBill(data);//提交下载对账单请求给API，接收返回结果

            WxPayLog.Info(methodString, "DownloadBill process complete, result : \n" + result.ToXml());
            return result.ToPrintStr();
        }
        #endregion
        #region // NativePay.cs
        /// <summary>
        /// 生成扫描支付模式一URL
        /// NativePay.GetPrePayUrl
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <returns>模式一URL</returns>
        public static string GetNativePrePayUrl(string productId)
        {
            var methodString = TypeString + ".GetNativePrePayUrl";
            WxPayLog.Info(methodString, "Native pay mode 1 url is producing...");

            WxPayData data = new WxPayData();
            data.SetValue("appid", WxPayConfig.APPID);//公众帐号id
            data.SetValue("mch_id", WxPayConfig.MCHID);//商户号
            data.SetValue("time_stamp", WxPayApi.GenerateTimeStamp());//时间戳
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
            data.SetValue("product_id", productId);//商品ID
            data.SetValue("sign", data.MakeSign());//签名
            string str = string.Join("&", data.GetValues().Select(s => string.Format("{0}={1}", s.Key, s.Value)));//转换为URL串
            string url = "weixin://wxpay/bizpayurl?" + str;

            WxPayLog.Info(methodString, "Get native pay mode 1 url : " + url);
            return url;
        }

        /// <summary>
        /// 生成直接支付url，支付url有效期为2小时,模式二
        /// NativePay.GetPayUrl
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <returns>模式二URL</returns>
        public static string GetNativePayUrl(string productId)
        {
            var methodString = TypeString + ".GetNativePrePayUrl";
            WxPayLog.Info(methodString, "Native pay mode 2 url is producing...");

            WxPayData data = new WxPayData();
            data.SetValue("body", "test");//商品描述
            data.SetValue("attach", "test");//附加数据
            data.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());//随机字符串
            data.SetValue("total_fee", 1);//总金额
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
            data.SetValue("goods_tag", "jjj");//商品标记
            data.SetValue("trade_type", "NATIVE");//交易类型
            data.SetValue("product_id", productId);//商品ID

            WxPayData result = WxPayApi.UnifiedOrder(data);//调用统一下单接口
            string url = result.GetValue("code_url").ToString();//获得统一下单接口返回的二维码链接

            WxPayLog.Info(methodString, "Get native pay mode 2 url : " + url);
            return url;
        }
        #endregion
        #region // MicroPay.cs
        /// <summary>
        /// 刷卡支付完整业务流程逻辑
        /// MicroPay.Run
        /// </summary>
        /// <param name="body">商品描述</param>
        /// <param name="total_fee">总金额</param>
        /// <param name="auth_code">支付授权码</param>
        /// <returns>刷卡支付结果</returns>
        /// <exception cref="WxPayException"></exception>
        public static string MicroPay(string body, string total_fee, string auth_code)
        {
            var methodString = TypeString + ".MicroPay";
            WxPayLog.Info(methodString, "Micropay is processing...");

            WxPayData data = new WxPayData();
            data.SetValue("auth_code", auth_code);//授权码
            data.SetValue("body", body);//商品描述
            data.SetValue("total_fee", int.Parse(total_fee));//总金额
            data.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());//产生随机的商户订单号

            WxPayData result = WxPayApi.Micropay(data, 10); //提交被扫支付，接收返回结果

            //如果提交被扫支付接口调用失败，则抛异常
            if (!result.IsSet("return_code") || result.GetValue("return_code").ToString() == "FAIL")
            {
                string returnMsg = result.IsSet("return_msg") ? result.GetValue("return_msg").ToString() : "";
                WxPayLog.Error(methodString, "Micropay API interface call failure, result : " + result.ToXml());
                throw new WxPayException("Micropay API interface call failure, return_msg : " + returnMsg);
            }

            //签名验证
            result.CheckSign();
            WxPayLog.Debug("MicroPay", "Micropay response check sign success");

            //刷卡支付直接成功
            if (result.GetValue("return_code").ToString() == "SUCCESS" &&
                result.GetValue("result_code").ToString() == "SUCCESS")
            {
                WxPayLog.Debug(methodString, "Micropay business success, result : " + result.ToXml());
                return result.ToPrintStr();
            }

            /******************************************************************
             * 剩下的都是接口调用成功，业务失败的情况
             * ****************************************************************/
            //1）业务结果明确失败
            if (result.GetValue("err_code").ToString() != "USERPAYING" &&
            result.GetValue("err_code").ToString() != "SYSTEMERROR")
            {
                WxPayLog.Error(methodString, "micropay API interface call success, business failure, result : " + result.ToXml());
                return result.ToPrintStr();
            }

            //2）不能确定是否失败，需查单
            //用商户订单号去查单
            string out_trade_no = data.GetValue("out_trade_no").ToString();

            //确认支付是否成功,每隔一段时间查询一次订单，共查询10次
            int queryTimes = 10;//查询次数计数器
            while (queryTimes-- > 0)
            {
                int succResult = 0;//查询结果
                WxPayData queryResult = MicroPayQuery(out_trade_no, out succResult);
                //如果需要继续查询，则等待2s后继续
                if (succResult == 2)
                {
                    Thread.Sleep(2000);
                    continue;
                }
                //查询成功,返回订单查询接口返回的数据
                else if (succResult == 1)
                {
                    WxPayLog.Debug(methodString, "Mircopay success, return order query result : " + queryResult.ToXml());
                    return queryResult.ToPrintStr();
                }
                //订单交易失败，直接返回刷卡支付接口返回的结果，失败原因会在err_code中描述
                else
                {
                    WxPayLog.Error(methodString, "Micropay failure, return micropay result : " + result.ToXml());
                    return result.ToPrintStr();
                }
            }

            //确认失败，则撤销订单
            WxPayLog.Error(methodString, "Micropay failure, Reverse order is processing...");
            if (!MicroPayCancel(out_trade_no))
            {
                WxPayLog.Error(methodString, "Reverse order failure");
                throw new WxPayException("Reverse order failure！");
            }

            return result.ToPrintStr();
        }

        /// <summary>
        /// 查询订单情况
        /// MicroPay.Query
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="succCode">查询订单结果：0表示订单不成功，1表示订单成功，2表示继续查询</param>
        /// <returns>订单查询接口返回的数据，参见协议接口</returns>
        public static WxPayData MicroPayQuery(string out_trade_no, out int succCode)
        {
            WxPayData queryOrderInput = new WxPayData();
            queryOrderInput.SetValue("out_trade_no", out_trade_no);
            WxPayData result = WxPayApi.OrderQuery(queryOrderInput);

            if (result.GetValue("return_code").ToString() == "SUCCESS"
                && result.GetValue("result_code").ToString() == "SUCCESS")
            {
                //支付成功
                if (result.GetValue("trade_state").ToString() == "SUCCESS")
                {
                    succCode = 1;
                    return result;
                }
                //用户支付中，需要继续查询
                else if (result.GetValue("trade_state").ToString() == "USERPAYING")
                {
                    succCode = 2;
                    return result;
                }
            }

            //如果返回错误码为“此交易订单号不存在”则直接认定失败
            if (result.GetValue("err_code").ToString() == "ORDERNOTEXIST")
            {
                succCode = 0;
            }
            else
            {
                //如果是系统错误，则后续继续
                succCode = 2;
            }
            return result;
        }

        /// <summary>
        /// 撤销订单，如果失败会重复调用10次
        /// MicroPay.Cancel
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="depth">调用次数，这里用递归深度表示</param>
        /// <returns>false表示撤销失败，true表示撤销成功</returns>
        public static bool MicroPayCancel(string out_trade_no, int depth = 0)
        {
            if (depth > 10)
            {
                return false;
            }

            WxPayData reverseInput = new WxPayData();
            reverseInput.SetValue("out_trade_no", out_trade_no);
            WxPayData result = WxPayApi.Reverse(reverseInput);

            //接口调用失败
            if (result.GetValue("return_code").ToString() != "SUCCESS")
            {
                return false;
            }

            //如果结果为success且不需要重新调用撤销，则表示撤销成功
            if (result.GetValue("result_code").ToString() != "SUCCESS" && result.GetValue("recall").ToString() == "N")
            {
                return true;
            }
            else if (result.GetValue("recall").ToString() == "Y")
            {
                return MicroPayCancel(out_trade_no, ++depth);
            }
            return false;
        }
        #endregion
        #region // RefundQuery.cs
        /// <summary>
        /// 退款查询完整业务流程逻辑
        /// RefundQuery.Run
        /// </summary>
        /// <param name="refund_id">微信退款单号（优先使用）</param>
        /// <param name="out_refund_no">商户退款单号</param>
        /// <param name="transaction_id">微信订单号</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// <returns>退款查询结果（xml格式）</returns>
        public static string RefundQuery(string refund_id, string out_refund_no, string transaction_id, string out_trade_no)
        {
            var methodString = TypeString + ".RefundQuery";
            WxPayLog.Info(methodString, "RefundQuery is processing...");

            WxPayData data = new WxPayData();
            if (!string.IsNullOrEmpty(refund_id))
            {
                data.SetValue("refund_id", refund_id);//微信退款单号，优先级最高
            }
            else if (!string.IsNullOrEmpty(out_refund_no))
            {
                data.SetValue("out_refund_no", out_refund_no);//商户退款单号，优先级第二
            }
            else if (!string.IsNullOrEmpty(transaction_id))
            {
                data.SetValue("transaction_id", transaction_id);//微信订单号，优先级第三
            }
            else
            {
                data.SetValue("out_trade_no", out_trade_no);//商户订单号，优先级最低
            }

            WxPayData result = WxPayApi.RefundQuery(data);//提交退款查询给API，接收返回数据

            WxPayLog.Info(methodString, "RefundQuery process complete, result : " + result.ToXml());
            return result.ToPrintStr();
        }
        #endregion
        #region // Refund.cs
        /// <summary>
        /// 申请退款完整业务流程逻辑
        /// Refund.Run
        /// </summary>
        /// <param name="transaction_id">微信订单号（优先使用）</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="total_fee">订单总金额</param>
        /// <param name="refund_fee">退款金额</param>
        /// <returns>退款结果（xml格式）</returns>
        public static string Refund(string transaction_id, string out_trade_no, string total_fee, string refund_fee)
        {
            var methodString = TypeString + ".Refund";
            WxPayLog.Info(methodString, "Refund is processing...");

            WxPayData data = new WxPayData();
            if (!string.IsNullOrEmpty(transaction_id))//微信订单号存在的条件下，则已微信订单号为准
            {
                data.SetValue("transaction_id", transaction_id);
            }
            else//微信订单号不存在，才根据商户订单号去退款
            {
                data.SetValue("out_trade_no", out_trade_no);
            }

            data.SetValue("total_fee", int.Parse(total_fee));//订单总金额
            data.SetValue("refund_fee", int.Parse(refund_fee));//退款金额
            data.SetValue("out_refund_no", WxPayApi.GenerateOutTradeNo());//随机生成商户退款单号
            data.SetValue("op_user_id", WxPayConfig.MCHID);//操作员，默认为商户号

            WxPayData result = WxPayApi.Refund(data);//提交退款申请给API，接收返回数据

            WxPayLog.Info(methodString, "Refund process complete, result : " + result.ToXml());
            return result.ToPrintStr();
        }
        #endregion
        #region // Notify.cs 
        // 回调处理基类，主要负责接收微信支付后台发送过来的数据，对数据进行签名验证，子类在此类基础上进行派生并重写自己的回调处理过程
        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// Notify.GetNotifyData
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        public static WxPayData GetNotifyData(Page page)
        {
            var methodString = TypeString + ".GetNotifyData";

            //接收从微信后台POST过来的数据
            Stream inputStream = page.Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = inputStream.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            inputStream.Flush();
            inputStream.Close();
            inputStream.Dispose();

            var builderString = builder.ToString();
            WxPayLog.Info(methodString, "Receive data from WeChat : " + builderString);

            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builderString);
            }
            catch (WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                var resXml = res.ToXml();
                WxPayLog.Error(methodString, "Sign check error : " + resXml);
                page.Response.Write(resXml);
                page.Response.End();
            }

            WxPayLog.Info(methodString, "Check sign success");
            return data;
        }

        public static WxPayData GetNotifyData(HttpContextBase httpContext)
        {
            var methodString = TypeString + ".GetNotifyData";

            //接收从微信后台POST过来的数据
            Stream inputStream = httpContext.Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = inputStream.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            inputStream.Flush();
            inputStream.Close();
            inputStream.Dispose();

            var builderString = builder.ToString();
            WxPayLog.Info(methodString, "Receive data from WeChat : " + builderString);

            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builderString);
            }
            catch (WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                var resXml = res.ToXml();
                WxPayLog.Error(methodString, "Sign check error : " + resXml);
                httpContext.Response.Write(resXml);
                httpContext.Response.End();
            }

            WxPayLog.Info(methodString, "Check sign success");
            return data;
        }
        #region // NativeNotify[Notify].cs
        //扫码支付模式一回调处理类，接收微信支付后台发送的扫码结果，调用统一下单接口并将下单结果返回给微信支付后台
        /// <summary>
        /// 处理回调通知
        /// NativeNotify[Notify].ProcessNotify
        /// </summary>
        public static void ProcessNativeNotify(Page page)
        {
            var methodString = TypeString + ".ProcessNativeNotify";
            WxPayData notifyData = GetNotifyData(page);

            //检查openid和product_id是否返回
            if (!notifyData.IsSet("openid") || !notifyData.IsSet("product_id"))
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "回调数据异常");
                WxPayLog.Info(methodString, "The data WeChat post is error : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            //调统一下单接口，获得下单结果
            string openid = notifyData.GetValue("openid").ToString();
            string product_id = notifyData.GetValue("product_id").ToString();
            WxPayData unifiedOrderResult = new WxPayData();
            try
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
                req.SetValue("openid", openid);
                req.SetValue("product_id", product_id);
                unifiedOrderResult = WxPayApi.UnifiedOrder(req);
            }
            catch (Exception ex)//若在调统一下单接口时抛异常，立即返回结果给微信支付后台
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                WxPayLog.Error(methodString, "UnifiedOrder failure : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            //若下单失败，则立即返回结果给微信支付后台
            if (!unifiedOrderResult.IsSet("appid") || !unifiedOrderResult.IsSet("mch_id") || !unifiedOrderResult.IsSet("prepay_id"))
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                WxPayLog.Error(methodString, "UnifiedOrder failure : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            //统一下单成功,则返回成功结果给微信支付后台
            WxPayData data = new WxPayData();
            data.SetValue("return_code", "SUCCESS");
            data.SetValue("return_msg", "OK");
            data.SetValue("appid", WxPayConfig.APPID);
            data.SetValue("mch_id", WxPayConfig.MCHID);
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
            data.SetValue("prepay_id", unifiedOrderResult.GetValue("prepay_id"));
            data.SetValue("result_code", "SUCCESS");
            data.SetValue("err_code_des", "OK");
            data.SetValue("sign", data.MakeSign());

            WxPayLog.Info(methodString, "UnifiedOrder success , send data to WeChat : " + data.ToXml());
            page.Response.Write(data.ToXml());
            page.Response.End();
        }

        public static void ProcessNativeNotify(HttpContextBase httpContext)
        {
            var methodString = TypeString + ".ProcessNativeNotify";
            WxPayData notifyData = GetNotifyData(httpContext);

            //检查openid和product_id是否返回
            if (!notifyData.IsSet("openid") || !notifyData.IsSet("product_id"))
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "回调数据异常");
                WxPayLog.Info(methodString, "The data WeChat post is error : " + res.ToXml());
                httpContext.Response.Write(res.ToXml());
                httpContext.Response.End();
            }

            //调统一下单接口，获得下单结果
            string openid = notifyData.GetValue("openid").ToString();
            string product_id = notifyData.GetValue("product_id").ToString();
            WxPayData unifiedOrderResult = new WxPayData();
            try
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
                req.SetValue("openid", openid);
                req.SetValue("product_id", product_id);
                unifiedOrderResult = WxPayApi.UnifiedOrder(req);
            }
            catch (Exception ex)//若在调统一下单接口时抛异常，立即返回结果给微信支付后台
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                WxPayLog.Error(methodString, "UnifiedOrder failure : " + res.ToXml());
                httpContext.Response.Write(res.ToXml());
                httpContext.Response.End();
            }

            //若下单失败，则立即返回结果给微信支付后台
            if (!unifiedOrderResult.IsSet("appid") || !unifiedOrderResult.IsSet("mch_id") || !unifiedOrderResult.IsSet("prepay_id"))
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                WxPayLog.Error(methodString, "UnifiedOrder failure : " + res.ToXml());
                httpContext.Response.Write(res.ToXml());
                httpContext.Response.End();
            }

            //统一下单成功,则返回成功结果给微信支付后台
            WxPayData data = new WxPayData();
            data.SetValue("return_code", "SUCCESS");
            data.SetValue("return_msg", "OK");
            data.SetValue("appid", WxPayConfig.APPID);
            data.SetValue("mch_id", WxPayConfig.MCHID);
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
            data.SetValue("prepay_id", unifiedOrderResult.GetValue("prepay_id"));
            data.SetValue("result_code", "SUCCESS");
            data.SetValue("err_code_des", "OK");
            data.SetValue("sign", data.MakeSign());

            WxPayLog.Info(methodString, "UnifiedOrder success , send data to WeChat : " + data.ToXml());
            httpContext.Response.Write(data.ToXml());
            httpContext.Response.End();
        }
        #endregion
        #region // ResultNotify[Notify].cs
        // 支付结果通知回调处理类，负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
        /// <summary>
        /// 处理回调通知
        /// ResultNotify.ProcessNotify
        /// </summary>
        /// <param name="page"></param>
        public static void ProcessResultNotify(Page page)
        {
            var methodString = TypeString + ".ProcessResultNotify";
            WxPayData notifyData = GetNotifyData(page);

            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                WxPayLog.Error(methodString, "The Pay result is error : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();

            //查询订单，判断订单真实性
            if (!QueryResultOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                WxPayLog.Error(methodString, "Order query failure : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }
            //查询订单成功
            else
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");
                WxPayLog.Info(methodString, "order query success : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }
        }

        public static void ProcessResultNotify(HttpContextBase httpContext)
        {
            var methodString = TypeString + ".ProcessResultNotify";
            WxPayData notifyData = GetNotifyData(httpContext);

            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                WxPayLog.Error(methodString, "The Pay result is error : " + res.ToXml());
                httpContext.Response.Write(res.ToXml());
                httpContext.Response.End();
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();

            //查询订单，判断订单真实性
            if (!QueryResultOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                WxPayLog.Error(methodString, "Order query failure : " + res.ToXml());
                httpContext.Response.Write(res.ToXml());
                httpContext.Response.End();
            }
            //查询订单成功
            else
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");
                WxPayLog.Info(methodString, "order query success : " + res.ToXml());
                httpContext.Response.Write(res.ToXml());
                httpContext.Response.End();
            }
        }

        /// <summary>
        /// 查询订单
        /// ResultNotify.QueryOrder
        /// </summary>
        /// <param name="transaction_id"></param>
        /// <returns></returns>
        private static bool QueryResultOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            return res.GetValue("return_code").ToString() == "SUCCESS" && res.GetValue("result_code").ToString() == "SUCCESS";
        }
        #endregion
        #endregion
    }
}
