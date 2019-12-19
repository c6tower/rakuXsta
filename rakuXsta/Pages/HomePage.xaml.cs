using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class HomePage : ContentPage
    {
        private ObservableCollection<Card> CardListData = new ObservableCollection<Card>();
        public HomePage()
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
                Navigation.PushAsync(new DetailPage((Item)e.SelectedItem));
            };
        }

        public void AppendNewData(object sender, EventArgs e)
        {
            CardListData.Add(new Card("追加スタンプ", "追加店", "追加ポイント"));
            CardListData.Add(new Card("追加２スタンプ", "追加２店", "追加２ポイント"));
        }

      

    }
    public class Card
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Point { get; set; }

        public Card(string Name, string Category, string Point)
        {

            this.Name = Name;
            this.Category = Category;
            this.Point = Point;
        }

    }
}
