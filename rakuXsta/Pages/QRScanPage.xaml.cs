using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class QRScanPage : ContentPage
    {
        public QRScanPage()
        {
            InitializeComponent();
        }

        void Handle_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string token = "eyJhbGciOiJIUzI1NiJ9.bWlob21pZG8.T3GHHpZVlaDNiiF9RglE39Mo5U7O55OUbtu5CqN2XUg";
                zxing.IsAnalyzing = false;  //読み取り停止
                HttpPostAddPoint obj = new HttpPostAddPoint(token, result.Text);
                string point = obj.Exe().Point;
                await DisplayAlert("通知", "次の値を読み取りました：" + point, "OK");
                zxing.IsAnalyzing = true;   //読み取り再開
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;
            base.OnDisappearing();
        }
    }
}
