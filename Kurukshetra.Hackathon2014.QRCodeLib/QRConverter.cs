﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.QrCode.Internal;//bytematrix
using System.Collections;


namespace Kurukshetra.Hackathon2014.QRCodeLib
{
    public class QRConverter
    {
        public BitMatrix GetQR(string message)
        {
            QRCodeWriter qrCode = new QRCodeWriter();
            BitMatrix imgBitmap = qrCode.encode(message, ZXing.BarcodeFormat.QR_CODE, 350, 350);
            return imgBitmap;
        }
        
    }
}
