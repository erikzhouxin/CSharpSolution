using EZOper.NetSiteUtilities.Alipayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EZOper.CSharpSolution.WebUI.WebForm.Alipayment
{
    /// <summary>
    /// 功能：统一下单并支付接口接入页
    /// 日期：2016-12-27
    /// 说明：
    /// /////////////////注意///////////////////////////////////////////////////////////////
    /// 如果您在接口集成过程中遇到问题，可以按照下面的途径来解决
    /// 1、支持中心（https://support.open.alipay.com/alipay/support/index.htm），提交申请集成协助，我们会有专业的技术工程师主动联系您协助解决
    /// 2、开发者论坛（https://openclub.alipay.com/）
    /// </summary>
    public partial class barcodepay : System.Web.UI.Page
    {
        IAlipayTradeService serviceClient = AlipayF2FBiz.GetTradeImpl();

        string result = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 提交支付请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Alipay_RSA_Submit(object sender, EventArgs e)
        {

            AlipayTradePayContentBuilder builder = BuildPayContent();
            string out_trade_no = builder.out_trade_no;

            AlipayF2FPayResult payResult = serviceClient.tradePay(builder);

            switch (payResult.Status)
            {
                case AlipayResultEnum.SUCCESS:
                    DoSuccessProcess(payResult);
                    break;
                case AlipayResultEnum.FAILED:
                    DoFailedProcess(payResult);
                    break;
                case AlipayResultEnum.UNKNOWN:
                    result = "网络异常，请检查网络配置后，更换外部订单号重试";
                    break;
            }
            Response.Redirect("result.aspx?Text=" + result);
        }

        /// <summary>
        /// 构造支付请求数据
        /// </summary>
        /// <returns>请求数据集</returns>
        private AlipayTradePayContentBuilder BuildPayContent()
        {
            //线上联调时，请输入真实的外部订单号。
            string out_trade_no = "";
            if (String.IsNullOrEmpty(WIDout_request_no.Text.Trim()))
            {
                out_trade_no = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "0000" + (new Random()).Next(1, 10000).ToString();
            }
            else
            {
                out_trade_no = WIDout_request_no.Text.Trim();
            }

            //扫码枪扫描到的用户手机钱包中的付款条码
            AlipayTradePayContentBuilder builder = new AlipayTradePayContentBuilder();

            //收款账号
            builder.seller_id = AlipayConfig.pid;
            //订单编号
            builder.out_trade_no = out_trade_no;
            //支付场景，无需修改
            builder.scene = "bar_code";
            //支付授权码,付款码
            builder.auth_code = WIDdynamic_id.Text.Trim();
            //订单总金额
            builder.total_amount = WIDtotal_fee.Text.Trim();
            //参与优惠计算的金额
            //builder.discountable_amount = "";
            //不参与优惠计算的金额
            //builder.undiscountable_amount = "";
            //订单名称
            builder.subject = WIDsubject.Text.Trim();
            //自定义超时时间
            builder.timeout_express = "2m";
            //订单描述
            builder.body = "";
            //门店编号，很重要的参数，可以用作之后的营销
            builder.store_id = "test store id";
            //操作员编号，很重要的参数，可以用作之后的营销
            builder.operator_id = "test";


            //传入商品信息详情
            List<AlipayGoodsInfo> gList = new List<AlipayGoodsInfo>();

            AlipayGoodsInfo goods = new AlipayGoodsInfo();
            goods.goods_id = "304";
            goods.goods_name = "goods#name";
            goods.price = "0.01";
            goods.quantity = "1";
            gList.Add(goods);
            builder.goods_detail = gList;

            //系统商接入可以填此参数用作返佣
            //ExtendParams exParam = new ExtendParams();
            //exParam.sysServiceProviderId = "20880000000000";
            //builder.extendParams = exParam;

            return builder;

        }


        /// <summary>
        /// 请添加支付成功后的处理
        /// </summary>
        private void DoSuccessProcess(AlipayF2FPayResult payResult)
        {

            //请添加支付成功后的处理
            System.Console.WriteLine("支付成功");
            result = payResult.response.Body;
        }

        /// <summary>
        /// 请添加支付失败后的处理
        /// </summary>
        private void DoFailedProcess(AlipayF2FPayResult payResult)
        {
            //请添加支付失败后的处理
            System.Console.WriteLine("支付失败");
            result = payResult.response.Body;
        }

    }
}