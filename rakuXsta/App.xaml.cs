using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Akavache;
using System.Reactive.Linq;

namespace rakuXsta
{
    public partial class App : Application
    {
        public string MYTOKEN;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Pages.MainPage());
        }

        
        protected override void OnStart()
        {
            var startButton = new Button { Text = "スタート" };
            startButton.Clicked += async (object sender, EventArgs e) =>
            {
                try
                {
                    //Akavacheで読み出し
                    var loaded = await BlobCache.LocalMachine.GetObject<Token>("cache");
                    MainPage = new NavigationPage(new Pages.MainPage());
                }
                catch (Exception)
                {
                    MainPage = new NavigationPage(new Pages.LoginPage());
                }
            };
            MainPage = new ContentPage
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        startButton,
                    }
                }
            };
        }

        protected override void OnSleep()
        {
            //改行 conflict
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}