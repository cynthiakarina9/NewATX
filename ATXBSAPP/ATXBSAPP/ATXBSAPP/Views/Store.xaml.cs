using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Store : ContentPage
    {
        public Store()
        {
            Title = "Tienda";
            InitializeComponent();
            var browser = new WebView();
            browser.Source = "https://atx.mx/tienda/";
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