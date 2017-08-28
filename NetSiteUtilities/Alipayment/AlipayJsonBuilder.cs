using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// Class1 的摘要说明
    /// 历史:
    /// 2017-8-27|JsonBuilder->AlipayJsonBuilder
    /// </summary>
    public abstract class AlipayJsonBuilder
    {
        // 验证bizContent对象
        public abstract bool Validate();

        // 将bizContent对象转换为json字符串
        public string BuildJson()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(this);
            }
            catch (Exception ex)
            {

                throw new Exception("JSONHelper.ObjectToJSON(): " + ex.Message);
            }
        }
    }
}