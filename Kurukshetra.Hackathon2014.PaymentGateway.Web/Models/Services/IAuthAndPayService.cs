﻿using Kurukshetra.Hackathon2014.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services
{
    public interface IAuthAndPayService
    {

        string GetSecretOfUser(string username);

        string GenerateAuthChallenge(string userName,out long epochTime);

        string GetAuthChallenge(string username, long epochTime);

        void AuthenticateUser(string username, long epochTime);

        bool IsUserAuthenticated(string username, long epochTime);

        void InvalidateAuthToken(string username, long epochTime);

        bool IsValidChallengeResponse(ChallengeResponse challengeResponse);

        bool IsValidPaymentToken(long merchantId, long orderReferenceNo, long epochTime, string token);

        bool IsPaymentComplete(long merchantId, long orderReferenceNo, long epochTime);
    }
}
