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
            createCustomerButton.Click += (sender, e) =>
            {
                StartActivity(typeof(AddCustomerActivity));
            };

            settingButton.Click += (s, e) =>
            {
                StartActivity(typeof(SettingActivity));
            };

            listOfCustomer.ItemClick += listOfCustomer_ItemClick;
            
        }

        void listOfCustomer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string userName = users[e.Position];
            string secreteKey = new DataSaverHelper().GetSecretForCustomer(userName);
            Intent i = new Intent(this,typeof(CustomerDetailActivity));
            i.PutExtra("UserName", userName);
            i.PutExtra("SecretKey", secreteKey);
            StartActivity(i);
        }

        protected override void OnResume()
        {
            base.OnResume();

            users = new DataSaverHelper().GetCustomerAccouts();
            if (users != null)
            {
                listOfCustomer.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, users);
            }
        }
        private string[] users;
        private Button createCustomerButton;
        private Button settingButton;
        private ListView listOfCustomer;
    }
}

