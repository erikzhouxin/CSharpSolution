using System;
namespace GW.Weixin.OAuths.Weixinmps.Models
{
    /// <summary>
    /// 分组实体类 。
    /// </summary>
    [Serializable]
    public class WeixinMGroup : WeixinMError
    {
        /// <summary>
        /// 公众平台分组信息
        /// </summary>
        public WeixinMGroupItem group { set; get; }
    }

    /// <summary>
    /// 分组实体类 。
    /// </summary>
    [Serializable]
    public class WeixinMGroups : WeixinMError
    {
        /// <summary>
        /// 公众平台分组信息列表
        /// </summary>
        public WeixinMGroupItem[] groups { set; get; }
    }

    /// <summary>
    /// 分组实体ID类 。
    /// </summary>
    [Serializable]
    public class WeixinMGroupId : WeixinMError
    {
        /// <summary>
        /// 公众平台分组信息
        /// </summary>
        public string groupid { set; get; }
    }

    /// <summary>
    /// 分组项实体类
    /// </summary>
    [Serializable]
    public class WeixinMGroupItem
    {
        /// <summary>
        /// 分组id，由微信分配
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 分组名字，UTF8编码
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 分组内用户数量
        /// </summary>
        public int count { get; set; }
    }
}
/*
 * Author: xusion
 * Created: 2012.04.10
 * Support: http://wobumang.com
 */