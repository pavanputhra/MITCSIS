using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Design;
using ZXing.Common;
using ZXing.QrCode;
using ZXing;
using System.IO;
using System.Drawing.Imaging;

namespace Kurukshetra.Hackathon2014.QRCodeLib.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            QRConverter converter = new QRConverter();
            BitMatrix imgMatrix = converter.GetQR("Hello World!");

            using (Bitmap bm = new Bitmap(350,350))
            {
                    for (int i = 0; i < imgMatrix.Height; i++)
                    {
                        for (int j = 0; j < imgMatrix.Width; j++)
                        {
                            if (imgMatrix[j, i])
                                bm.SetPixel(j, i, Color.Black);
                            else
                                bm.SetPixel(j, i, Color.White);
                        }
                    }
                    bm.Save("text.png");
            }
            
        }

        [TestMethod]
        public void Decode()
        {
            Bitmap bitmap = new Bitmap(@"text.png");
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                bitmap.Save(memoryStream, ImageFormat.Bmp);

                byte[] byteArray = memoryStream.GetBuffer();

                ZXing.LuminanceSource source = new RGBLuminanceSource(byteArray, bitmap.Width, bitmap.Height);
                var binarizer = new HybridBinarizer(source);
                var binBitmap = new BinaryBitmap(binarizer);
                QRCodeReader qrCodeReader = new QRCodeReader();

                Result str = qrCodeReader.decode(binBitmap);
                Assert.AreEqual(str, "Hello World!");

            }
            catch { }

        }

            
        //}

    
    }
}
