using System;
using System.Collections.Generic;
using System.Text;

namespace GW.Weixin.Entitys
{
    /// <summary>
    /// 接口令牌
    /// </summary>
    [Serializable]
    public class ApiToken : ApiError
    {
        /// <summary>
        /// 访问令牌 
        /// </summary>
        public string access_token { set; get; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expires_in { set; get; }
        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string refresh_token { set; get; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string response { set; get; }
    }
}
/*
 * Author: xusion
 * Created: 2012.07.25
 * Support: http://wobumang.com
 */