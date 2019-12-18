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
    public partial class DetailPage2 : ContentPage
    {
        public DetailPage2(CreatedItems items)
        {
            InitializeComponent();

            nameValue.Text = items.Name;
            infoValue.Text = items.Info;
            imgValue.Text = items.Img;
            idValue.Text = items.Id;
        }
    }
}