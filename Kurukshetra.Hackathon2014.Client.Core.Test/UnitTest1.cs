using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kurukshetra.Hackathon2014.Client.Core;

namespace Kurukshetra.Hackathon2014.Client.Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestingReturningMethodofHMACSHA1()
        {
            AuthenticateChallenge ac = new AuthenticateChallenge();
            var r=  ac.ParseAuthChallenge(@"00/5678/abc", "sharath", "pavan");
            Assert.AreEqual(r.HMAC, "5ZDWKFKIJ2PWLEXMTNZZHE5FIDJHKQH6");
        }
    }
}
