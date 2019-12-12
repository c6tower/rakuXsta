using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var usernameEntry = new Entry { Placeholder = "Username" };
            var passwordEntry = new Entry { Placeholder = "Password" , IsPassword = true};
            var loginButton = new Button { Text = "Login", TextColor = Color.White, BackgroundColor = Color.FromHex("77D065") };
            var signupButton = new Button { Text = "Sign Up" };

            loginButton.Clicked += async (sender, e) =>
            {
                // usernameEntry.Text
            };

            // signupButton.Clicked += async (sender, e) =>



            Content = new StackLayout
            {
                Spacing = 20, Padding = 50,
                VerticalOptions = LayoutOptions.Center,
                Children =
                    {
                    new Label {Text = "welcome to rakuXsta", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.FillAndExpand},
                        usernameEntry,
                        passwordEntry,
                        loginButton,
                        signupButton
                    }
            };
        }
    }
}