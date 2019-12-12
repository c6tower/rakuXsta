using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Akavache;
using System.Reactive.Linq;

namespace rakuXsta
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Pages.MainPage());
        }

        
        protected override void OnStart()
        {
            /*
            var myToken = new Token();

            
            Token token = null;
            // Akavacheでtoken読み出し
            BlobCache.LocalMachine.GetObject<Token>("token").Subscribe(x => token = x);
            if (token == null) // キャッシュがなかったとき 
            {
                MainPage = new NavigationPage(new Pages.LoginPage());
            }
            else // キャッシュがあったとき
            {
                MainPage = new NavigationPage(new Pages.MainPage());
            }*/
                


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