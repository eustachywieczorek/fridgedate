
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
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var loginActivity = (LoginActivity)this.Activity;


            var linearLayout = new CommonLinearLayout(Activity);
            var btnLoginExternal = new Button(Activity);
            btnLoginExternal.Click += async (sender, e) => { await loginActivity.LoginWithFacebook(); };
            btnLoginExternal.Text = "Login with Facebook";
            var txtRegister = new TextView(Activity) {Text = "or sign up with email"};
            txtRegister.Click += (sender, e) => { loginActivity.ShowRegisterLocal(); };
            linearLayout.AddView(btnLoginExternal);
            linearLayout.AddView(txtRegister);
            return linearLayout;
        }
    }
}