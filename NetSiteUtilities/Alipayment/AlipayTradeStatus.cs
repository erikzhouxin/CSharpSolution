using System;
using System.Collections.Generic;
using System.Web;


namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// TradeStatusEnum 的摘要说明
    /// 历史:
    /// 2017-8-27|TradeStatus->AlipayTradeStatus
    /// </summary>
    public class AlipayTradeStatus
    {
        public const string TRADE_SUCCESS = "TRADE_SUCCESS";
        public const string TRADE_FINISHED = "TRADE_FINISHED";
        public const string TRADE_CLOSED = "TRADE_CLOSED";
        public const string WAIT_BUYER_PAY = "WAIT_BUYER_PAY";
    }
}