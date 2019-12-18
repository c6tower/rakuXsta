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
        public DetailPage2(Item items)
        {
            InitializeComponent();

            nameValue.Text = items.Name;
            categoryValue.Text = items.Info;
            pointValue.Text = items.Point;
        }
    }
}