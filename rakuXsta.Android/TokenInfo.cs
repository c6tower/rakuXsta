﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(rakuXsta.Droid.TokenInfo))]

namespace rakuXsta.Droid
{
    class TokenInfo : ITokenInfo
    {
        public string TOKEN { get; set; }

        public List<string> IMAGE { get; set; }
    }
}