using System;
namespace GW.Weixin.OAuths.Weixinmps.Models
{
    /// <summary>
    /// 错误代码说明
    /// </summary>
    [Serializable]
    public class WeixinMError
    {
        /// <summary>
        /// 错误的内部编号
        /// </summary>
        public int errcode { set; get; }

        /// <summary>
        /// 错误的错误信息
        /// </summary>
        public string errmsg { set; get; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string request { set; get; }
    }
}
/*
 * Author: xusion
 * Created: 2012.04.10
 * Support: http://wobumang.com
 */