using System;

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
            ITokenInfo tokenInfo = DependencyService.Get<ITokenInfo>(DependencyFetchTarget.GlobalInstance);

            HttpPostCreateCard obj = new HttpPostCreateCard(name, info, img, tokenInfo.TOKEN);
            var card_data = obj.Exe();

            var result = DisplayAlert(card_data.CardName, "が作成されたよ", "OK");

            card_name.Text = "";
            card_info.Text = "";
            card_img.Text = "";
        }
    }
}
