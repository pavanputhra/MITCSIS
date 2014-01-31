using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.Net.Http;
using Kurukshetra.Hackathon2014.Client.Core;
using Kurukshetra.Hackathon2014.Dto;
using Newtonsoft.Json;

namespace Kurukshetra.Hackathon2014.Client.Android12
{
    [Activity(Label = "My Activity")]
    public class CustomerDetailActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.CustomerDetail);

            userName = this.Intent.GetStringExtra("UserName");
            secretKey = this.Intent.GetStringExtra("SecretKey");
            authenticateButton = FindViewById<Button>(Resource.Id.authenticateButton);
            makePaymentButton = FindViewById<Button>(Resource.Id.makePaymentButton);
            deleteButton = FindViewById<Button>(Resource.Id.deleteCustomerButton);

            authenticateButton.Click += async (s, e) =>
            {
                var result = await Utility.ReadQRCode(this);
                if (result != null)
                {
                    SendAuthResponse(result);
                }
            };

            makePaymentButton.Click += async (s, e) =>
            {
                var result = await Utility.ReadQRCode(this);
                if (result != null)
                {
                    SendMakePaymentReq(result);
                }
            };

            deleteButton.Click += (s, e) =>
            {
                new DataSaverHelper().DeleteCustomer(userName);
                base.OnBackPressed();
            };
        }

        private void SendMakePaymentReq(string result)
        {
            try
            {
                var postData = new AuthenticatePayment().ParsePaymentChallenge(result, userName, secretKey);
                string address = String.Format("{0}/{1}{2}{3}", new DataSaverHelper().GetUrlBase(), "api/Customer/", userName, "/Auth/",postData.EpochTime);
                string jsonReq = JsonConvert.SerializeObject(postData);
                string response = Utility.HttpPost(address, jsonReq);
                if ("true".Equals(response))
                {
                    Utility.ShowToastLong(this, "Successfull Payment.");
                }
                else
                {
                    Utility.ShowToastLong(this, "Payment Failed");
                }
            }
            catch
            {
                Utility.ShowToastLong(this, "Network Failure");
            }
        }

        private void SendAuthResponse(string result)
        {
            try
            {
                string address = String.Format("{0}/{1}{2}{3}",new DataSaverHelper().GetUrlBase(),"api/Customer/",userName,"/Authenticate");
                var postData = new AuthenticateChallenge().ParseAuthChallenge(result,userName,secretKey);
                string jsonReq = JsonConvert.SerializeObject(postData);
                string response = Utility.HttpPost(address, jsonReq);
                if ("true".Equals(response))
                {
                    Utility.ShowToastLong(this, "Successfull Authenticaton.");
                }
                else
                {
                    Utility.ShowToastLong(this, "Failure");
                }
            }
            catch
            {
                Utility.ShowToastLong(this, "Network Failure");
            }
        }


        private string userName;
        private string secretKey;
        private Button authenticateButton;
        private Button makePaymentButton;
        private Button deleteButton;
    }
}