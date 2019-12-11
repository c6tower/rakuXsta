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

            //初期データ
            CardListData.Add(new Card("らくらくスタンプ", "レストラン", "３ポイント"));
            CardListData.Add(new Card("楽々スタンプ", "コンビニ", "２ポイント"));
            CardListData.Add(new Card("ラクラクスタンプ", "カフェ", "7ポイント"));
            CardListData.Add(new Card("楽スタ", "ファストフード", "8ポイント"));
            CardListData.Add(new Card("スタンプ", "本屋", "2ポイント"));

            // ListViewにデータソースをセット
            cardList.ItemsSource = CardListData;

            cardList.ItemSelected += (sender, e) =>
            {
                Navigation.PushAsync(new DetailPage((Card)e.SelectedItem));
            };
        }

        public void AppendNewData(object sender, EventArgs e)
        {
            CardListData.Add(new Card("追加スタンプ", "追加店", "追加ポイント"));
            CardListData.Add(new Card("追加２スタンプ", "追加２店", "追加２ポイント"));
        }

        public void Camera_Change(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QRScanPage());
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
