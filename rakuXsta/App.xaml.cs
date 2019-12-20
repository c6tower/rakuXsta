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

        
        protected override async void OnStart()
        {
            try
            {
                //インターフェイスを利用してトークンを保存する
                ITokenInfo tokenInfo = DependencyService.Get<ITokenInfo>(DependencyFetchTarget.GlobalInstance);
                //Akavacheで読み出し
                
                // try catch うまくいかない、tryではmainpageに飛ぶけど、catchではloginpageに飛ばない
                var loaded = await BlobCache.LocalMachine.GetObject<Token>("cache");
                tokenInfo.TOKEN = loaded.CachedToken;
                
                //tokenInfo.TOKEN = "eyJhbGciOiJIUzI1NiJ9.bWlob21pZG8.T3GHHpZVlaDNiiF9RglE39Mo5U7O55OUbtu5CqN2XUg";
                MainPage = new NavigationPage(new Pages.MainPage());
            }
            catch
            {
                //飛ばない
                MainPage = new NavigationPage(new Pages.LoginPage());
            }
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