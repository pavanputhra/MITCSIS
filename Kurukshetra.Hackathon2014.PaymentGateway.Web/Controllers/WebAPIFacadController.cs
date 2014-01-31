using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kurukshetra.Hackathon2014.PaymentGateway.Web.Models.Services;
using Kurukshetra.Hackathon2014.Dto;

namespace Kurukshetra.Hackathon2014.PaymentGateway.Web.Api
{
    public class WebAPIFacadController : ApiController
    {

        private IAuthAndPayService authAndPayService;

        //public WebAPIFacadController() : base() { }

        public WebAPIFacadController(IAuthAndPayService authAndPayService)
        {
            this.authAndPayService = authAndPayService;
        }

        [Route("api/Customer/{customerId}/Auth/{time}")]
        [HttpGet]
        public bool IsCustomerAuthenticated(string customerId,long time)
        {
            var result = authAndPayService.IsUserAuthenticated(customerId, time) ;
            if (result)
            {
                authAndPayService.InvalidateAuthToken(customerId, time);
            }
            return result;
        }

        [Route("api/Customer/{customerId}/Authenticate")]
        [HttpPost]
        public bool AuthenticateUser(ChallengeResponse challengeResponse)
        {
            if (authAndPayService.IsValidChallengeResponse(challengeResponse))
            {
                authAndPayService.AuthenticateUser(challengeResponse.UserName, challengeResponse.EpochTime);
                return true;
            }
            return false;
        }
    }
}