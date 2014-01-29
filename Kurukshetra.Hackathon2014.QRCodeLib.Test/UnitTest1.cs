using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using ZXing.Common;

namespace Kurukshetra.Hackathon2014.QRCodeLib.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            QRConverter converter = new QRConverter();
            BitMatrix imgMatrix = converter.getQR("Hello World!");

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
    }
}
