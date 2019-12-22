using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Akavache;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace rakuXsta
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        
        protected override  void OnStart()
        {
            var startButton = new Button { Text = "スタート" };

            ITokenInfo tokenInfo = DependencyService.Get<ITokenInfo>(DependencyFetchTarget.GlobalInstance);
            startButton.Clicked += async (sender, e) =>
            {
                try
                {
                    var loaded = await BlobCache.LocalMachine.GetObject<Token>("cache");
                    tokenInfo.TOKEN = loaded.CachedToken;
                    MainPage = new NavigationPage(new Pages.MainPage());
                }
                catch
                {
                    //飛ばない
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