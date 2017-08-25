using EZOper.PaymentUtilities.Alipayment.AopApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EZOper.PaymentUtilities.Alipayment.F2FPayDll
{
    /// <summary>
    /// AlipayF2FMonitorResult 的摘要说明
    /// </summary>
    public class AlipayF2FMonitorResult
    {
        public AlipayF2FMonitorResult()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public MonitorHeartbeatSynResponse response { get; set; }

        public ResultEnum Status
        {
            get
            {

                if (response != null)
                {
                    if (response.Code == ResultCode.SUCCESS)
                    {
                        return ResultEnum.SUCCESS;
                    }
                    else
                        return ResultEnum.FAILED;
                }
                else
                {
                    return ResultEnum.UNKNOWN;
                }
            }

        }


    }
}