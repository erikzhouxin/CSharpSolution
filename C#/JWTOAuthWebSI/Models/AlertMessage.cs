using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.JWTOAuthWebSI
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
        public AlertMessage()
        {
            IsSuccess = false;
            Details = new List<string>();
        }
        /// <summary>
        /// 结果构造
        /// {结果:空}
        /// </summary>
        /// <param name="isSuccess">处理结果</param>
        public AlertMessage(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Details = new List<string>();
        }
        /// <summary>
        /// 结果信息构造
        /// </summary>
        /// <param name="isSuccess">处理结果</param>
        /// <param name="message">提示信息</param>
        public AlertMessage(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Details = new List<string>() { message };
        }
        /// <summary>
        /// 信息构造
        /// {结果:失败}
        /// </summary>
        /// <param name="message">提示信息</param>
        public AlertMessage(string message)
        {
            IsSuccess = false;
            Details = new List<string>() { message };
        }
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

        /// <summary>
        /// 处理结果
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public List<string> Details { get; set; }

        public void AddMsg(string msg)
        {
            Details.Add(msg);
        }

        public void ClearMsg()
        {
            Details.Clear();
        }

        public string First()
        {
            return Details.FirstOrDefault() ?? string.Empty;
        }
    }
}
