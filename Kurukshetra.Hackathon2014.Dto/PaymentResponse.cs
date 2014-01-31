using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.Dto
{
    public class PaymentResponse
    {
        public long EpochTime { get; set; }
        public string MerchantID { get; set; }
        public long OrderID { get; set; }
        public string HMAC { get; set; }
    }
}
