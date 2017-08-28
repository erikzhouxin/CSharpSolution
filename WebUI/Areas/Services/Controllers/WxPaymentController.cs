using EZOper.CSharpSolution.WebUI.EntitiesModels;
using EZOper.NetSiteUtilities.Wepayment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ThoughtWorks.QRCode.Codec;

namespace EZOper.CSharpSolution.WebUI.Areas.Services.Controllers
{
    /// <summary>
    /// 微信支付控制器
    /// GET: Services/WxPayment
    /// </summary>
    public class WxPaymentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region // 下载账单
        public ActionResult DownloadBill()
        {
            WxPayLog.Debug(this.GetType().ToString(), "DownloadBillPage load");
            return View();
        }

        [HttpPost]
        public ActionResult DownloadBillPage(string bill_type, DateTime? bill_date)
        {
            var dateStr = (bill_date.HasValue ? bill_date.Value : DateTime.Now).ToString("yyyyMMdd");
            var alertMsg = new AlertMsg();
            //调用下载对账单接口,如果内部出现异常则在页面上显示异常原因
            try
            {
                string result = WxPayApiBiz.DownloadBill(dateStr, bill_type);
                alertMsg.IsSuccess = true;
                alertMsg.Message = result;
            }
            catch (WxPayException ex)
            {
                alertMsg.Message = ex.Message;
            }
            catch (Exception ex)
            {
                alertMsg.Message = ex.Message;
            }
            return Json(alertMsg);
        }
        #endregion
        #region // JSAPI支付
        public ActionResult Product()
        {
            var alertMsg = new AlertMsg();
            WxPayLog.Info(this.GetType().ToString(), "page load");
            WxPayJsApi jsApiPay = new WxPayJsApi(Request);
            try
            {
                //调用【网页授权获取用户信息】接口获取用户的openid和access_token
                var url = jsApiPay.GetOpenidAndAccessToken();
                if (url != null)
                {
                    return Redirect(url);
                }
                //获取收货地址js函数入口参数
                var wxEditAddrParam = jsApiPay.GetEditAddressParameters();
                TempData["openid"] = jsApiPay.openid;
                alertMsg.IsSuccess = true;
                ViewBag.WxEditAddrParam = wxEditAddrParam;
            }
            catch (Exception ex)
            {
                alertMsg.Message = $"页面加载出错，请重试，错误信息:{ex.Message}";
            }
            return View(alertMsg);
        }

        public ActionResult JsApiPay(string openid, string total_fee)
        {
            WxPayLog.Info(this.GetType().ToString(), "JsApiPayPage load");
            //检测是否给当前页面传递了相关参数
            if (string.IsNullOrEmpty(openid) || string.IsNullOrEmpty(total_fee))
            {
                WxPayLog.Error(this.GetType().ToString(), "This page have not get params, cannot be inited, exit...");
                return View(new AlertMsg("页面传参出错, 请返回重试"));
            }

            var alertMsg = new AlertMsg();
            //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
            WxPayJsApi jsApiPay = new WxPayJsApi(Request);
            jsApiPay.openid = openid;
            jsApiPay.total_fee = int.Parse(total_fee);

            //JSAPI支付预处理
            try
            {
                WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult();
                var wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数                    
                WxPayLog.Debug(this.GetType().ToString(), "wxJsApiParam : " + wxJsApiParam);
                //在页面上显示订单信息
                alertMsg.IsSuccess = true;
                alertMsg.Message = ("订单详情：" + unifiedOrderResult.ToPrintStr());
                ViewBag.WxJsApiParam = wxJsApiParam;
            }
            catch (Exception ex)
            {
                alertMsg.Message = $"下单失败，请返回重试，错误信息:{ex.Message}";
            }
            return View(alertMsg);
        }
        #endregion
        #region // 刷卡支付
        public ActionResult MicroPay()
        {
            WxPayLog.Info(this.GetType().ToString(), "page load");
            return View();
        }

        [HttpPost]
        public ActionResult MicroPayPage(string auth_code, string body, string fee)
        {
            var alertMsg = new AlertMsg(true);
            if (string.IsNullOrEmpty(auth_code))
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message += "请输入授权码！\n";
            }
            if (string.IsNullOrEmpty(body))
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message += "请输入商品描述！\n";
            }
            if (string.IsNullOrEmpty(fee))
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message += "请输入商品总金额！\n";
            }
            if (!alertMsg.IsSuccess)
            {
                return Json(alertMsg);
            }
            //调用刷卡支付,如果内部出现异常则在页面上显示异常原因
            try
            {
                alertMsg.Message = WxPayApiBiz.MicroPay(body, fee, auth_code);
            }
            catch (WxPayException ex)
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message = ex.ToString();
            }
            catch (Exception ex)
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message = ex.ToString();
            }
            return Json(alertMsg);
        }
        #endregion
        #region // 扫码支付
        public ActionResult NativePay()
        {
            WxPayLog.Info(this.GetType().ToString(), "page load");

            //生成扫码支付模式一url
            ViewBag.QRCode1 = WxPayApiBiz.GetNativePrePayUrl("123456789");

            //生成扫码支付模式二url
            ViewBag.QRCode2 = WxPayApiBiz.GetNativePayUrl("123456789");

            return View();
        }

        public ActionResult NativeNotify()
        {
            WxPayApiBiz.ProcessNativeNotify(HttpContext);
            return View();
        }
        #endregion
        #region // 订单查询
        public ActionResult OrderQuery()
        {
            WxPayLog.Info(this.GetType().ToString(), "page load");
            return View();
        }

        public ActionResult OrderQueryPage(string transaction_id, string out_trade_no)
        {
            if (string.IsNullOrEmpty(transaction_id) && string.IsNullOrEmpty(out_trade_no))
            {
                return Json(new AlertMsg("微信订单号和商户订单号至少填写一个,微信订单号优先！"));
            }

            var alertMsg = new AlertMsg();
            //调用订单查询接口,如果内部出现异常则在页面上显示异常原因
            try
            {
                string result = WxPayApiBiz.OrderQuery(transaction_id, out_trade_no);//调用订单查询业务逻辑
                alertMsg.IsSuccess = true;
                alertMsg.Message = result;
            }
            catch (WxPayException ex)
            {
                alertMsg.Message = ex.Message;
            }
            catch (Exception ex)
            {
                alertMsg.Message = ex.Message;
            }
            return Json(alertMsg);
        }
        #endregion
        #region // 订单退款
        public ActionResult Refund()
        {
            return View();
        }

        public ActionResult RefundPage(string transaction_id, string out_trade_no, string total_fee, string refund_fee)
        {
            var alertMsg = new AlertMsg(true);
            if (string.IsNullOrEmpty(transaction_id) && string.IsNullOrEmpty(out_trade_no))
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message += "微信订单号和商户订单号至少填一个！\n";
            }
            if (string.IsNullOrEmpty(total_fee))
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message += "订单总金额必填！\n";
            }
            if (string.IsNullOrEmpty(refund_fee))
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message += "退款金额必填！\n";
            }

            if (!alertMsg.IsSuccess)
            {
                return Json(alertMsg);
            }

            //调用订单退款接口,如果内部出现异常则在页面上显示异常原因
            try
            {
                string result = WxPayApiBiz.Refund(transaction_id, out_trade_no, total_fee, refund_fee);
                alertMsg.Message = result;
            }
            catch (WxPayException ex)
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message = ex.Message;
            }
            catch (Exception ex)
            {
                alertMsg.IsSuccess = false;
                alertMsg.Message = ex.Message;
            }
            return Json(alertMsg);
        }

        public ActionResult ResultNotify()
        {
            WxPayApiBiz.ProcessResultNotify(HttpContext);
            return View();
        }
        #endregion
        #region // 退款查询
        public ActionResult RefundQuery()
        {
            WxPayLog.Debug(this.GetType().ToString(), "page load");
            return View();
        }

        public ActionResult RefundQueryPage(string refund_id, string out_refund_no, string transaction_id, string out_trade_no)
        {
            if (string.IsNullOrEmpty(refund_id) && string.IsNullOrEmpty(out_refund_no) &&
                string.IsNullOrEmpty(transaction_id) && string.IsNullOrEmpty(out_trade_no))
            {
                return Json(new AlertMsg("微信订单号、商户订单号、商户退款单号、微信退款单号选填至少一个，微信退款单号优先！"));
            }

            var alertMsg = new AlertMsg();
            //调用退款查询接口,如果内部出现异常则在页面上显示异常原因
            try
            {
                string result = WxPayApiBiz.RefundQuery(refund_id, out_refund_no, transaction_id, out_trade_no);
                alertMsg.IsSuccess = true;
                alertMsg.Message = result;
            }
            catch (WxPayException ex)
            {
                alertMsg.Message = ex.Message;
            }
            catch (Exception ex)
            {
                alertMsg.Message = ex.Message;
            }
            return Json(alertMsg);
        }
        #endregion
    }
}