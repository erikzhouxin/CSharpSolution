using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.CSharpSolution.WebUI.Payment.AlipayCode
{
    /// <summary>
    /// 提交视图模板
    /// </summary>
    public class SumitViewModel
    {
        /// <summary>
        /// 字符编码
        /// </summary>
        public string _input_charset { get; set; }

        /// <summary>
        /// 提交主体
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// 默认银行
        /// </summary>
        public string defaultbank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string exter_invoke_ip { get; set; }

        /// <summary>
        /// 通知URL
        /// </summary>
        public string notify_url { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public string partner { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public string payment_type { get; set; }

        /// <summary>
        /// 返回URL
        /// </summary>
        public string return_url { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public string seller_email{get;set;}

        /// <summary>
        /// 服务
        /// </summary>
        public string service { get; set; }

        /// <summary>
        /// 展示URL
        /// </summary>
        public string show_url { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal total_fee { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string sign_type { get; set; }
    }
}
