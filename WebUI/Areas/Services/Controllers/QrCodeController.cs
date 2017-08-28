using EZOper.CSharpSolution.WebUI.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ThoughtWorks.QRCode.Codec;

namespace EZOper.CSharpSolution.WebUI.Areas.Services.Controllers
{
    /// <summary>
    /// 二维码控制器
    /// GET: Services/QrCode
    /// </summary>
    public class QrCodeController : Controller
    {
        public ActionResult GetJpeg(string data)
        {
            return File(QrCodeHelper.GetQrCodeByte(data), @"image/jpeg");
        }

        public ActionResult GetPng(string data)
        {
            return File(QrCodeHelper.GetQrCodeByte(data,Server.MapPath(@"~\Content\Images\favicon.ico")), @"image/png");
        }
    }
}