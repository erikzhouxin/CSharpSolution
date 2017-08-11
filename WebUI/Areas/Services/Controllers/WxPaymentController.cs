using EZOper.CSharpSolution.WebUI.EntitiesModels;
using EZOper.CSharpSolution.WebUI.Payment.WxPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                string result = WxPayHelper.DownloadBill(dateStr, bill_type);
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
        
        public ActionResult JsApiPay(string openid, string total_fee)
        {
            WxPayLog.Info(this.GetType().ToString(), "JsApiPayPage load");
            //检测是否给当前页面传递了相关参数
            if (string.IsNullOrEmpty(openid) || string.IsNullOrEmpty(total_fee))
            {
                WxPayLog.Error(this.GetType().ToString(), "This page have not get params, cannot be inited, exit...");
                return Json(new AlertMsg("页面传参出错, 请返回重试"));
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
                alertMsg.Message = ("<span>订单详情：</span><br/><span>" + unifiedOrderResult.ToPrintStr() + "</span>");
            }
            catch (Exception ex)
            {
                alertMsg.Message = $"下单失败，请返回重试，错误信息:{ex.Message}";
            }
            return View();
        }
    }
}