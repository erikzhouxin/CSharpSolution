using System;
namespace GW.Weixin.OAuths.Weixinmps.Models
{
    /// <summary>
    /// 实体类MUsers 。
    /// </summary>
    [Serializable]
    public class WeixinMToken : WeixinMError
    {
        /// <summary>
        /// 访问令牌 
        /// </summary>
        public string access_token { set; get; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expires_in { set; get; }
    }
}
/*
 * Author: xusion
 * Created: 2012.04.10
 * Support: http://wobumang.com
 */