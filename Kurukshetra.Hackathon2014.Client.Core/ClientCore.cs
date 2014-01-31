using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurukshetra.Hackathon2014.Dto;

namespace Kurukshetra.Hackathon2014.Client.Core
{
    public class ClientCore
    {
        public string InputCheck(String input)
        {
            char[] seps={'/'};
            String [] values = input.Split(seps);
            switch(values[0])
            {
                case "00":
                    return CodeType.Secret;
                case "01":
                    return CodeType.Challenge;
                case "02":
                    return CodeType.OnlinePay;
                case "03":
                    return CodeType.COD;
                default:
                    return CodeType.Invalid;
            }
        }
    }
}
