﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(ItemIncludeImages items)
        {
            InitializeComponent();

            nameValue.Text = items.Name;
            categoryValue.Text = items.Info;
            pointValue.Text = items.Point;

        }
    }
}
