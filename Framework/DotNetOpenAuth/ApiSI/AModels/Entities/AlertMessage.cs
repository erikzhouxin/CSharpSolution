using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EZOper.TechTester.OAuth2ApiSI
{
    /// <summary>
    /// 返回结果及信息列表
    /// </summary>
    public class AlertMessage
    {
        public AlertMessage()
        {
            IsSuccess = false;
            Details = new List<string>();
        }
        public AlertMessage(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Details = new List<string>();
        }
        public AlertMessage(bool result, string message)
        {
            IsSuccess = result;
            Details = new List<string>() { message };
        }
        public AlertMessage(bool result, IEnumerable<string> messageList)
        {
            IsSuccess = result;
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
    }
}
