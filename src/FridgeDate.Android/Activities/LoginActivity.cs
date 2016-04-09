
using Android.App;
using Android.OS;
using FridgeDate.Android.Fragments;
using FridgeDate.Core.Interfaces;
using FridgeDate.Core.Responses;
using Refit;
using System.Linq;
using System.Threading.Tasks;
using FridgeDate.Core.Resources;

namespace FridgeDate.Android.Activities
{
    [Activity(Label = "FridgeDate.Android", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Material.Light")]
    public class LoginActivity : BaseActivity
    {
        private IAccountApi _accountApi;
        private ExternalLogin _facebookLogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            _accountApi = RestService.For<IAccountApi>(Core.Settings.Values.BASE_URL);
            Task.Run(async () =>
            {
                await SetupExternalProviders();
            });
            
            ShowLogin();
        }


        private void ShowLogin()
        {
            ChangeFragment(new LoginFragment());
        }
        private async Task SetupExternalProviders()
        {
            var externalLogins = await _accountApi.GetExternalLogins(Core.Settings.Values.BASE_URL + "/api/Account/ExternalLogin");
            _facebookLogin = externalLogins.ToList()[0];
        }

        public void ShowRegisterLocal()
        {
            ChangeFragment(new RegisterLocalFragment());
        }

        private void ChangeFragment(Fragment fragment)
        {
            var transaction = base.FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.flLogin, fragment);
            transaction.Commit();
        }

        public async Task RegisterLocal(Core.Requests.RegisterRequest request)
        {
            var result = await _accountApi.Register(request);
            if (result.IsSuccessStatusCode)
            {
                GoToMain();
            }
            else
            {
                ShowErrorDialog(GlobalApp.ErrorTitle, "Registration failed");
            }
        }

        public async Task LoginWithFacebook()
        {
            var t = await _accountApi.GetExternalLogin(_facebookLogin.Name);
            if (t.IsSuccessStatusCode)
            {
                GoToMain();
            }
            else
            {
                ShowErrorDialog(GlobalApp.ErrorTitle, "Login failed");
            }
        }

        private void GoToMain()
        {
            
        }
    }
}