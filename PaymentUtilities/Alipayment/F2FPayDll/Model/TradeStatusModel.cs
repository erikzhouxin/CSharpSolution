using System;
using System.Collections.Generic;
using System.Web;


namespace EZOper.PaymentUtilities.Alipayment.F2FPayDll
{
    /// <summary>
    /// TradeStatusEnum 的摘要说明
    /// </summary>
    public class TradeStatus
    {
        public const string TRADE_SUCCESS = "TRADE_SUCCESS";
        public const string TRADE_FINISHED = "TRADE_FINISHED";
        public const string TRADE_CLOSED = "TRADE_CLOSED";
        public const string WAIT_BUYER_PAY = "WAIT_BUYER_PAY";

    }
}