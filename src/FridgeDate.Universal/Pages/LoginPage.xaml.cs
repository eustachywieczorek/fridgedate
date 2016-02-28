using FridgeDate.Core.Interfaces;
using Refit;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FridgeDate.Universal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private IAccountApi _accountApi;
        public LoginPage()
        {
            _accountApi = RestService.For<IAccountApi>(Core.Settings.Values.BASE_URL);
            Task.Run(async () =>
            {
                await SetupExternalProviders();
            });
            this.InitializeComponent();
        }

        private async Task SetupExternalProviders()
        {
            var externalLogins = await _accountApi.GetExternalLogins("login");
            var test = externalLogins;
        }
    }
}
