using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services
{
    public interface ICryptoService
    {
        byte[] GenerateRandomByte(int bits);

        string CalculateHmac(string key, string input);
    }
}
