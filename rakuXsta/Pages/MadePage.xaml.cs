using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class MadePage : ContentPage
    {
        public MadePage()
        {
            InitializeComponent();
            //起動時所持カード読み取り処理(仮)
            string token = "eyJhbGciOiJIUzI1NiJ9.bWlob21pZG8.T3GHHpZVlaDNiiF9RglE39Mo5U7O55OUbtu5CqN2XUg";
            HttpPostGetCardsList obj = new HttpPostGetCardsList(token);
            List<Item> items = obj.Exe();

            // ListViewにデータソースをセット
            cardList.ItemsSource = items;
            //押したときのデータ
            cardList.ItemSelected += (sender, e) =>
            {
                Navigation.PushAsync(new DetailPage2((Item)e.SelectedItem));
            };
        }
    }
}
