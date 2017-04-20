using System;
using System.Collections.Generic;
using System.Text;

namespace GW.Weixin.Entitys
{
    /// <summary>
    /// 协议实体
    /// </summary>
    [Serializable]
    public class OAuthEntity
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string desc { set; get; }
    }

}
/*
 * Author: xusion
 * Created: 2012.07.25
 * Support: http://wobumang.com
 */