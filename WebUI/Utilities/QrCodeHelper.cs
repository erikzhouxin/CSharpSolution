using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using ThoughtWorks.QRCode.Codec;

namespace EZOper.CSharpSolution.WebUI.Utilities
{
    /// <summary>
    /// 二维码帮助类
    /// </summary>
    public class QrCodeHelper
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="data">待转换的数据</param>
        /// <returns>@"image/jpeg"</returns>
        public static byte[] GetQrCodeByte(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }
            //初始化二维码生成工具
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 4;

            //将字符串生成二维码图片
            Bitmap image = qrCodeEncoder.Encode(data, Encoding.Default);

            //保存为Jpeg到内存流  
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);

            //输出二维码图片
            return ms.GetBuffer();
        }

        /// <summary>
        /// 生成带中心图标的二维码
        /// </summary>
        /// <param name="data">待转换的数据</param>
        /// <param name="iconPath">内嵌图标路径</param>
        /// <returns>image/png</returns>
        public static byte[] GetQrCodeByte(string data, string iconPath)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 4;

            Image image = qrCodeEncoder.Encode(data, Encoding.Default);

            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);

            var msResult = new MemoryStream();
            CombinImage(image, iconPath).Save(msResult, ImageFormat.Png);

            return msResult.GetBuffer();
        }

        /// <summary>
        /// 调用此函数后使此两种图片合并，类似相册，有个
        /// 背景图，中间贴自己的目标图片
        /// </summary>
        /// <param name="imgBack">粘贴的源图片</param>
        /// <param name="destImg">粘贴的目标图片</param>
        private static Image CombinImage(Image imgBack, string destImg)
        {
            var iconWidth = imgBack.Width / 4;
            Image img = Image.FromFile(destImg); // 嵌入图图片
            if (img.Height != iconWidth || img.Width != iconWidth) // Resize图片
            {
                Image icon = new Bitmap(iconWidth, iconWidth);
                Graphics gIcon = Graphics.FromImage(icon);
                // 插值算法的质量
                gIcon.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gIcon.DrawImage(img, new Rectangle(0, 0, iconWidth, iconWidth), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                gIcon.Dispose();
                img = icon;
            }
            Graphics gNew = Graphics.FromImage(imgBack);
            gNew.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);
            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框
            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
            gNew.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }
    }
}