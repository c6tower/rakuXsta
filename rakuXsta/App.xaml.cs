using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace rakuXsta
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            //
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
