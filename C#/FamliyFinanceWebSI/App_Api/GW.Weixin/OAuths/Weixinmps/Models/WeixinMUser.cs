using System;
namespace GW.Weixin.OAuths.Weixinmps.Models
{
    /// <summary>
    /// 实体类MUsers 。
    /// </summary>
    [Serializable]
    public class WeixinMUser : WeixinMError
    {
        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        public int subscribe { set; get; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string openid { set; get; }
        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string nickname { set; get; }
        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public int sex { set; get; }
        /// <summary>
        /// 用户的语言，简体中文为zh_CN
        /// </summary>
        public string language { set; get; }
        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city { set; get; }
        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string province { set; get; }
        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string country { set; get; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </summary>
        public string headimgurl { set; get; }
        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        public long subscribe_time { set; get; }
    }
}
/*
 * Author: xusion
 * Created: 2012.04.10
 * Support: http://wobumang.com
 */