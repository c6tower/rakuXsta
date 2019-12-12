using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Item items)
        {
            InitializeComponent();

            nameValue.Text = items.name;
            categoryValue.Text = items.info;
            pointValue.Text = items.point;

        }
    }
}
