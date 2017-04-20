using System;
namespace GW.Weixin.OAuths.Weixinmps.Models
{
    /// <summary>
    /// 实体类MUsers 。
    /// </summary>
    [Serializable]
    public class WeixinMOpenIds : WeixinMError
    {
        /// <summary>
        /// 关注该公众账号的总用户数 
        /// </summary>
        public string total { set; get; }
        /// <summary>
        /// 拉取的OPENID个数，最大值为10000
        /// </summary>
        public int count { set; get; }
        /// 列表数据，OPENID的列表
        /// </summary>
        public WeixinMOpenId data { set; get; }
        /// <summary>
        /// 拉取列表的后一个用户的OPENID
        /// </summary>
        public string next_openid { set; get; }
    }

    [Serializable]
    public class WeixinMOpenId
    {
        public string[] openid { get; set; }
    }
}
/*
 * Author: xusion
 * Created: 2012.04.10
 * Support: http://wobumang.com
 */