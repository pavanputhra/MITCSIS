using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing.Common;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Infrastructure
{
    public class QRImageResult : ActionResult
    {
        private BitMatrix qrMatrix;
        public QRImageResult(BitMatrix qrMatrix)
        {
            this.qrMatrix = qrMatrix;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            using (Bitmap bitmap = new Bitmap(qrMatrix.Width, qrMatrix.Height))
            {
                for (int i = 0; i < qrMatrix.Height; i++)
                {
                    for (int j = 0; j < qrMatrix.Width; j++)
                    {
                        if (qrMatrix[j, i])
                        {
                            bitmap.SetPixel(j, i, Color.Black);
                        }
                        else
                        {
                            bitmap.SetPixel(j, i, Color.White);
                        }
                    }
                }
                context.HttpContext.Response.ContentType = "image/png";
                bitmap.Save(context.HttpContext.Response.OutputStream, ImageFormat.Png);
            }
        }
    }
}