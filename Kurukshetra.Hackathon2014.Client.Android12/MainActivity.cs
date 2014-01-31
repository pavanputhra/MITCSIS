using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Kurukshetra.Hackathon2014.Client.Android12
{
    [Activity(Label = "Kurukshetra.Hackathon2014.Client.Android12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            createCustomerButton = FindViewById<Button>(Resource.Id.addCustomerButton);
            settingButton = FindViewById<Button>(Resource.Id.settingButton);
            listOfCustomer = FindViewById<ListView>(Resource.Id.cusomerList);
            createCustomerButton.Touch += (object sender, View.TouchEventArgs e) =>
            {
                StartActivity(typeof(AddCustomerActivity));
            };
        }
        private Button createCustomerButton;
        private Button settingButton;
        private ListView listOfCustomer;
    }
}

