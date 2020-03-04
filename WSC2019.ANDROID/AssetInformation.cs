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

namespace WSC2019
{
    [Activity(Label = "AssetInformation")]
    public class AssetInformation : Activity
    {
        bool user = true;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_asset_information);
            // Create your application here
            var expiredWarratnty = FindViewById<EditText>(Resource.Id.ExpiredWarratnty);
            expiredWarratnty.TextChanged += new EventHandler<Android.Text.TextChangedEventArgs>(AlterDayText);
            expiredWarratnty.Click += new EventHandler(AlterUser);
        }
        private void AlterUser(object sender, EventArgs e)
        {
            user = true;
        }
        private void AlterDayText(object sender, EventArgs e)
        {
            if (user)
            {
                var edit = (EditText)sender;
                string text = edit.Text;
                var newChar = new char[text.Length + 2];
                string numbers = "1234567890";
                int legth = 0;
                if (text.Length > 3)
                {
                    foreach (char letter in text)
                    {
                        bool isNumber = false;
                        foreach (char number in numbers)
                        {
                            if (letter == number) isNumber = true;
                        }
                        if (isNumber && legth < 2) { newChar[legth] = letter; }
                        if (isNumber && legth > 2 && legth < 4)
                        {
                            newChar[legth + 1] = letter;
                            newChar[2] = '/';
                        }
                        if (isNumber && legth > 4) { newChar[legth + 2] = letter; newChar[6] = '/'; }
                        legth++;
                    }
                    string newText = string.Concat(newChar);
                    edit.Text = newText;
                    user = false;
                }
            }
        }
    }
}