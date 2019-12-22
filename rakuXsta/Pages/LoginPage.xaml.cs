using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Akavache;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace rakuXsta.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            ITokenInfo tokenInfo = DependencyService.Get<ITokenInfo>(DependencyFetchTarget.GlobalInstance);
            loginButton.Clicked += async (sender, e) =>
            {
                HttpPostLogin regster = new HttpPostLogin(Username.Text, Password.Text);
                var token = new Token
                {
                    CachedToken = regster.Exe().Token
                };
                await BlobCache.LocalMachine.InsertObject("cache", token);
                tokenInfo.TOKEN = token.CachedToken;
                await Navigation.PushAsync(new Pages.MainPage());
            };

            signupButton.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new Pages.SignUpPage());
            };
        }
    }
}