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
            loginButton.Clicked += async (sender, e) =>
            {
                HttpPostLogin regster = new HttpPostLogin(Username.Text, Password.Text);
                var token = new Token
                {
                    CachedToken = regster.Exe().Token
                };
                await BlobCache.LocalMachine.InsertObject("cache", token);
                Username.Text = "finish";
                Password.Text = "***";
            };

            signupButton.Clicked += async (sender, e) =>
            {
                try
                {
                    //Akavacheで読み出し
                    var loaded = await BlobCache.LocalMachine.GetObject<Token>("cache");
                    Username.Text = loaded.CachedToken;
                    Password.Text = "aaaa";
                }
                catch (Exception)
                {
                    Username.Text = "There is no cached";
                }
            };
        }
    }
}