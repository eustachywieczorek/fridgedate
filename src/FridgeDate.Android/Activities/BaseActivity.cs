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

namespace FridgeDate.Android.Activities
{
    [Activity(Label = "BaseActivity")]
    public class BaseActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected void ShowErrorDialog(string title, string message)
        {
            var alertBuilder = new AlertDialog.Builder(this);
            var dialog = alertBuilder.Create();
            dialog.SetTitle(title);
            dialog.SetMessage(message);
            dialog.Show();
        }
    }
}