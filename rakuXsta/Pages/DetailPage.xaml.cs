using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(List<Item> items)
        {
            InitializeComponent();

            nameValue.Text = items[0].name;
            categoryValue.Text = items[0].info;
            pointValue.Text = items[0].point;

        }
    }
}
