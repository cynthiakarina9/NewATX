using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            browser.Visual.IsMaterial();
            browser.Source = "https://www.youtube.com/user/atxbusiness";
            this.Content = browser;
        }
        async void Chat_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(9);
        }
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void home_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }       
    }
}