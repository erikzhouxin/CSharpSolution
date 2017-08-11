using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZOper.CSharpSolution.WebUI.Payment.AlipayCode
{
    /// <summary>
    /// 支付宝返回视图
    /// </summary>
    public class AlipayReturnViewModel
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string trade_no { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string trade_status { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string message { get; set; }
    }
}