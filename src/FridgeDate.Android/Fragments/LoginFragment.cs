
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using FridgeDate.Android.Activities;
using FridgeDate.Android.Layouts;

namespace FridgeDate.Android.Fragments
{
    public class LoginFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.LoginFragment, container, false);
            var loginActivity = (LoginActivity)this.Activity;
            var btnLoginFacebook = view.FindViewById<Button>(Resource.Id.btnFacebook);
            btnLoginFacebook.Click += async (sender, e) => { await loginActivity.LoginWithFacebook(); };
            var txtRegister = view.FindViewById<TextView>(Resource.Id.txtRegister);
            txtRegister.Click += (sender, e) => { loginActivity.ShowRegisterLocal(); };
            return view;
        }
    }
}