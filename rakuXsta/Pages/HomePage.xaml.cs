using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class HomePage : ContentPage
    {
        private ObservableCollection<Item> items = new ObservableCollection<Item>();
        public HomePage(string token)
        {
            InitializeComponent();
            
            HttpPostGetCardsList obj = new HttpPostGetCardsList(token);
            items = obj.Exe();

            // ListViewにデータソースをセット
            cardList.ItemsSource = items;
            //押したときのデータ
            cardList.ItemSelected += (sender, e) =>
            {
                Navigation.PushAsync(new DetailPage((Item)e.SelectedItem));
            };
        }


        //起動時にカードデータ取得
        /*
        private void HomePage_Appearing(object sender, EventArgs e)
        {
            string token = "eyJhbGciOiJIUzI1NiJ9.bWlob21pZG8.T3GHHpZVlaDNiiF9RglE39Mo5U7O55OUbtu5CqN2XUg";
            HttpPostGetCardsList obj = new HttpPostGetCardsList(token);
            items = obj.Exe();
        }*/

        private void cardList_Refreshing(object sender, EventArgs e)
        {
            Task.Run(() => System.Threading.Thread.Sleep(3000));
            string token = "eyJhbGciOiJIUzI1NiJ9.bWlob21pZG8.T3GHHpZVlaDNiiF9RglE39Mo5U7O55OUbtu5CqN2XUg";
            HttpPostGetCardsList obj = new HttpPostGetCardsList(token);
            items = obj.Exe();
            System.Diagnostics.Trace.WriteLine(items[0].Point);
            cardList.EndRefresh();
        }
        public string cache;

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
