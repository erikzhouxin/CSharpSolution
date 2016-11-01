using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EZOper.TechTester.SQLiteApiSI.IDL
{
    public class LogOnViewModel
    {
        [RegularExpression("^[A-Za-z0-9]{5,12}", ErrorMessage = "{0}限制5-12位字母或数字")]
        [Required(ErrorMessage = "请输入{0}")]
        [Display(Name = "用户名")]
        public string Account { get; set; }

        [RegularExpression("^.{5,20}", ErrorMessage = "{0}限制5-20位字符")]
        [Required(ErrorMessage = "请输入{0}")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [RegularExpression("^[A-Za-z0-9]{4}", ErrorMessage = "{0}限制4位字母或数字")]
        [Required(ErrorMessage = "请输入{0}")]
        [Display(Name = "验证码")]
        public string AuthCode { get; set; }
    }
}