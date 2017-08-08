using System;
namespace GW.Weixin.OAuths.Weixinmps.Models
{
    /// <summary>
    /// 实体类MUsers 。
    /// </summary>
    [Serializable]
    public class WeixinMMedia : WeixinMError
    {
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb，主要用于视频与音乐格式的缩略图）
        /// </summary>
        public string type { set; get; }
        /// <summary>
        /// 媒体文件上传后，获取时的唯一标识
        /// </summary>
        public string media_id { set; get; }
        /// <summary>
        /// 媒体文件上传时间戳
        /// </summary>
        public long created_at { set; get; }
    }
}
/*
 * Author: xusion
 * Created: 2012.04.10
 * Support: http://wobumang.com
 */