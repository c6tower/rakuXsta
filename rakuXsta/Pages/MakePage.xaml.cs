using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class MakePage : ContentPage
    {
        public MakePage()
        {
            InitializeComponent();

        }

        public void PostCreateCardData(object sender, EventArgs e)
        {
            string name = card_name.Text;
            string info = card_info.Text;
            string img = card_img.Text;
            string token = "eyJhbGciOiJIUzI1NiJ9.bWlob21pZG8.T3GHHpZVlaDNiiF9RglE39Mo5U7O55OUbtu5CqN2XUg";

            HttpPostCreateCard obj = new HttpPostCreateCard(name, info, img, token);
            var card_data = obj.Exe();
        }
    }
}
