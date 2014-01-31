using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Kurukshetra.Hackathon2014.PaymentGateway.Store;
using Base32;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services
{
    public class DefaultCryptoService : ICryptoService
    {
        public byte[] GenerateRandomByte(int bits)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[bits/8];
                rng.GetBytes(key);
                return key;
            }
        }


        public string CalculateHmac(string key, string input)
        {
            //TODO: actual implementation
            return "testing";
        }
    }
}