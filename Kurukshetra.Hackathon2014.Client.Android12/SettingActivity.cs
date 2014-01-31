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
    public class SettingActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.SettingView);

            urlTextBox = FindViewById<EditText>(Resource.Id.urlTextBox);
            setUrlButton = FindViewById<Button>(Resource.Id.setUrlButton);

            urlTextBox.Text = new DataSaverHelper().GetUrlBase();

            setUrlButton.Click += (s, e) =>
            {
                new DataSaverHelper().AddUrlBase(urlTextBox.Text);
                Utility.ShowToastLong(this, "UrlAdded");
            };
        }

        private EditText urlTextBox;
        private Button setUrlButton;
    }
}