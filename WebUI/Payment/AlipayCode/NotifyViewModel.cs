using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.CSharpSolution.WebUI.Payment.AlipayCode
{
    /// <summary>
    /// responseTxt=true
    /// isSign=True
    /// </summary>
    public class NotifyViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// body=李家店小学办学条件监测管理系统服务租用费,总计:799元,其中包括2015-2016学年799元
        /// body=李家店小学办学条件监测管理系统服务租用费,总计:799元,其中包括2015-2016学年799元
        /// body=旺业甸小学办学条件监测管理系统服务租用费,总计:799元,其中包括2015-2016学年799元
        /// </remarks>
        public string body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// buyer_email=15548961822
        /// buyer_email=15548961822
        /// buyer_email=408402226@qq.com
        /// </remarks>
        public string buyer_email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// buyer_id=2088702280898385
        /// buyer_id=2088702280898385
        /// buyer_id=2088902333880648
        /// </remarks>
        public string buyer_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// discount=0.00
        /// discount=0.00
        /// </remarks>
        public double discount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// exterface=create_direct_pay_by_user
        /// </remarks>
        public string exterface { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// gmt_create=2016-03-22 07:27:42
        /// gmt_create=2016-03-22 10:03:52
        /// </remarks>
        public DateTime gmt_create { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// gmt_payment=2016-03-22 07:28:03
        /// gmt_payment=2016-03-22 10:25:46
        /// </remarks>
        public DateTime gmt_payment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// is_success=T
        /// </remarks>
        public string is_success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// is_total_fee_adjust=N
        /// is_total_fee_adjust=N
        /// </remarks>
        public string is_total_fee_adjust { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// notify_id=90ac83d2d291c7aaf9511c17e610db0ixm
        /// notify_id=RqPnCoPT3K9%2Fvwbh3InUHnsjCNqm%2BHSQOd0NGBMqTIju2QXw7wya1oTeq3CxSNGxFkrV
        /// notify_id=4c476fa8679d7043e8e6fba9b13b0fbkxu
        /// </remarks>
        public string notify_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// notify_time=2016-03-22 07:28:03
        /// notify_time=2016-03-22 07:28:13
        /// notify_time=2016-03-22 10:25:46
        /// </remarks>
        public DateTime notify_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// notify_type=trade_status_sync
        /// notify_type=trade_status_sync
        /// notify_type=trade_status_sync
        /// </remarks>
        public string notify_type { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// out_trade_no=1e9da378-5127-4117-b1f7-d6e87fa5df89
        /// out_trade_no=1e9da378-5127-4117-b1f7-d6e87fa5df89
        /// out_trade_no=c1a1197e-c88e-447d-aead-4143e6e478ec
        /// </remarks>
        public string out_trade_no { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// payment_type=1
        /// payment_type=1
        /// payment_type=1
        /// </remarks>
        public string payment_type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// price=799.00
        /// price=799.00
        /// </remarks>
        public decimal price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// quantity=1
        /// quantity=1
        /// </remarks>
        public int quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// seller_email=bjliangzuo@163.com
        /// seller_email=bjliangzuo@163.com
        /// seller_email=bjliangzuo@163.com
        /// </remarks>
        public string seller_email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// seller_id=2088611543403526
        /// seller_id=2088611543403526
        /// seller_id=2088611543403526
        /// </remarks>
        public string seller_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// subject=办学条件监测管理系统服务租用费
        /// subject=办学条件监测管理系统服务租用费
        /// subject=办学条件监测管理系统服务租用费
        /// </remarks>
        public string subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// total_fee=799.00
        /// total_fee=799.00
        /// total_fee=799.00
        /// </remarks>
        public decimal total_fee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// trade_no=2016032221001004380293350439
        /// trade_no=2016032221001004380293350439
        /// trade_no=2016032221001004640280942839
        /// </remarks>
        public string trade_no { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// trade_status=TRADE_SUCCESS
        /// trade_status=TRADE_SUCCESS
        /// trade_status=TRADE_SUCCESS
        /// </remarks>
        public string trade_status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// use_coupon=N
        /// use_coupon=N
        /// </remarks>
        public string use_coupon { get; set; }
    }
}
