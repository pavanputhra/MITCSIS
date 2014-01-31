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
using Kurukshetra.Hackathon2014.Client.Core;
using Kurukshetra.Hackathon2014.Dto;

namespace Kurukshetra.Hackathon2014.Client.Android12
{
	[Activity (Label = "AddCustomerActivity")]			
	public class AddCustomerActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.AddCustomer);

            userNameText = FindViewById<EditText>(Resource.Id.enteredUserNameText);
            secretKeyText = FindViewById<EditText>(Resource.Id.scanedSecretText);
            scanQRCode = FindViewById<Button>(Resource.Id.scanSecretQRButton);
            doneButton = FindViewById<Button>(Resource.Id.newCustomerDone);

            scanQRCode.Click += async (s, e) =>
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner(this);
                scanner.UseCustomOverlay = false;

                //We can customize the top and bottom text of the default overlay
                scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
                scanner.BottomText = "Wait for the barcode to automatically scan!";

                //Start scanning
                var result = await scanner.Scan();

                if (result != null)
                    processQRCode(result.Text);
            };

            doneButton.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(userNameText.Text) && !string.IsNullOrEmpty(secretKeyText.Text))
                {
                    new DataSaverHelper().AddNewCustomer(userNameText.Text, secretKeyText.Text);
                    base.OnBackPressed();
                }
            };
		}

        private void processQRCode(string text)
        {
            var type = CodeType.Invalid;
            try
            {
                type = new ClientCore().InputCheck(text);
            }
            catch
            {
                Toast.MakeText(this, "Not a valid QR code", ToastLength.Long);
            }
            if (type == CodeType.Secret)
            {
                secretKeyText.Text = text;
                Toast.MakeText(this, "Got you secret key", ToastLength.Long);
            }
            else
            {
                Toast.MakeText(this, "Not a valid QR code",ToastLength.Long);
            }
        }

        private EditText userNameText;
        private EditText secretKeyText;
        private Button scanQRCode;
        private Button doneButton;
	}
}

