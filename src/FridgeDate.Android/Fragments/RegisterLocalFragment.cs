using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FridgeDate.Android.Layouts;
using FridgeDate.Android.Activities;
using FridgeDate.Core.Requests;

namespace FridgeDate.Android.Fragments
{
    public class RegisterLocalFragment : Fragment
    {
        private EditText _txEmail;
        private EditText _txPassword;
        private LoginActivity _activity;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _activity = (LoginActivity)Activity;
            var view = inflater.Inflate(Resource.Layout.RegisterLocal, container, false);
            var btnRegister = view.FindViewById<Button>(Resource.Id.btnRegisterLocal);
            _txEmail = view.FindViewById<EditText>(Resource.Id.tbEmail);
            _txEmail.Text = "arnstej@gmail.com";
            _txPassword = view.FindViewById<EditText>(Resource.Id.tbPassword);
            btnRegister.Click += async (sender, e) => { await Register(); };
            return view;
        }

        private async Task Register()
        {
            var registerRequest = new RegisterRequest
            {
                Email = _txEmail.Text,
                Password = _txPassword.Text,
                ConfirmPassword = _txPassword.Text
            };
            await _activity.RegisterLocal(registerRequest);
        }
    }
}