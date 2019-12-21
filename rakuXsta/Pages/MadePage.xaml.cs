using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rakuXsta.Pages
{
    public partial class MadePage : ContentPage
    {
        private ObservableCollection<CreatedItems> items = new ObservableCollection<CreatedItems>();
        public MadePage()
        {
            InitializeComponent();
            //起動時所持カード読み取り処理(仮)
            ITokenInfo tokenInfo = DependencyService.Get<ITokenInfo>(DependencyFetchTarget.GlobalInstance);
            HttpPostGetCreatedCardsList obj = new HttpPostGetCreatedCardsList(tokenInfo.TOKEN);
            items = obj.Exe();

            // ListViewにデータソースをセット
            cardList.ItemsSource = items;
            //押したときのデータ
            cardList.ItemSelected += (sender, e) =>
            {
                Navigation.PushAsync(new DetailPage2((CreatedItems)e.SelectedItem));
            };
        }
        private async void madecardList_Refreshing(object sender, EventArgs e)
        {
            await Task.Run(() => System.Threading.Thread.Sleep(3000));
            items.Clear();
            ITokenInfo tokenInfo = DependencyService.Get<ITokenInfo>(DependencyFetchTarget.GlobalInstance);
            HttpPostGetCreatedCardsList obj = new HttpPostGetCreatedCardsList(tokenInfo.TOKEN);
            foreach (var item in obj.Exe())
            {
                items.Add(item);
            }
            cardList.EndRefresh();
        }
        public string cache;
    }
}
