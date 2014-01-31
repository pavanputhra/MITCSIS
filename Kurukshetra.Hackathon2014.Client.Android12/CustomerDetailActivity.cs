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

namespace Kurukshetra.Hackathon2014.Client.Android12
{
    [Activity(Label = "My Activity")]
    public class CustomerDetailActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.CustomerDetail);

            authenticateButton = FindViewById<Button>(Resource.Id.authenticateButton);
            makePaymentButton = FindViewById<Button>(Resource.Id.makePaymentButton);
            deleteButton = FindViewById<Button>(Resource.Id.deleteCustomerButton);
        }

        private Button authenticateButton;
        private Button makePaymentButton;
        private Button deleteButton;
    }
}