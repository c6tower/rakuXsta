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
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            ToolbarItem tItem = new ToolbarItem
            {
                IconImageSource = "camera4.png",
                Text = "カメラ",
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new QRScanPage());
                }),
            };
            this.ToolbarItems.Add(tItem);
        }
    }
}
