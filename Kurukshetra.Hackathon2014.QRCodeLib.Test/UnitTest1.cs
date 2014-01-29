using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Design;
using ZXing.Common;
using ZXing.QrCode;
using ZXing;

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

        //[TestMethod]
        //public void TestMethod2()
        //{
        //    Bitmap bmap = new Bitmap(Image.FromFile("text.png"));
        //    QRCodeReader qrRead = new QRCodeReader();
            



        //    //BitMatrix bmat = new BitMatrix(350, 350);

        //    //for (int i = 0; i < bmap.Height; i++)
        //    //{
        //    //    for (int j = 0; j < bmap.Width; j++)
        //    //    {
        //    //        bmat[j][i] = bmap.GetPixel(j, i);
        //    //    }
        //    //}

            
        //}

    
    }
}
