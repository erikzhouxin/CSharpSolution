using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZOper.CSharpSolution.WebUI.EntitiesModels
{

    /// <summary>
    /// 返回结果及信息列表
    /// </summary>
    public class AlertMessage
    {
        /// <summary>
        /// 默认构造
        /// {结果:失败,信息:空}
        /// </summary>
        public AlertMessage() : this(false)
        { }
        /// <summary>
        /// 结果构造
        /// {结果:空}
        /// </summary>
        /// <param name="isSuccess">处理结果</param>
        public AlertMessage(bool isSuccess) : this(isSuccess, new List<string>())
        { }
        /// <summary>
        /// 信息构造
        /// {结果:失败}
        /// </summary>
        /// <param name="message">提示信息</param>
        public AlertMessage(string message) : this(false, message)
        { }
        /// <summary>
        /// 结果信息构造
        /// </summary>
        /// <param name="isSuccess">处理结果</param>
        /// <param name="message">提示信息</param>
        public AlertMessage(bool isSuccess, string message) : this(isSuccess, new List<string> { message })
        { }
        /// <summary>
        /// 结果信息构造
        /// </summary>
        /// <param name="isSuccess">处理结果</param>
        /// <param name="messageList">提示信息</param>
        public AlertMessage(bool isSuccess, IEnumerable<string> messageList)
        {
            IsSuccess = isSuccess;
            Details = messageList == null ? new List<string>() : messageList.ToList();
        }
        private AlertMessage(bool isSuccess, List<string> messageList)
        {
            IsSuccess = isSuccess;
            Details = messageList;
        }

        /// <summary>
        /// 处理结果
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public List<string> Details { get; set; }

        public void Add(string msg)
        {
            Details.Add(msg);
        }

        public void Clear()
        {
            Details.Clear();
        }
    }

    public class AlertMsg
    {
        public AlertMsg(bool isSuccess = false) : this(isSuccess, string.Empty)
        { }
        public AlertMsg(string message) : this(false, message)
        { }
        public AlertMsg(bool result, string message)
        {
            IsSuccess = result;
            Message = message;
        }

        /// <summary>
        /// 处理结果
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }

    }
}