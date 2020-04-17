using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class youtube_view : ContentPage
    {
        public youtube_view()
        {
            Title = "YouTube";
            InitializeComponent();
            var browser = new WebView();
            browser.Source = "https://www.youtube.com/user/atxbusiness";
            this.Content = browser;
        }
        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }
    }
}