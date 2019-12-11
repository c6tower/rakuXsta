using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Card card)
        {
            InitializeComponent();

            nameValue.Text = card.Name;
            categoryValue.Text = card.Category;
            pointValue.Text = card.Point;

        }
    }
}
