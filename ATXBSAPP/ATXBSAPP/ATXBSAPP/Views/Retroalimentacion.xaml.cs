using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Retroalimentacion : ContentPage
    {
        public Retroalimentacion()
        {
            Title = "Retroalimentación";
            InitializeComponent();
            var browser = new WebView();
            browser.Source = "https://forms.office.com/Pages/ResponsePage.aspx?id=sfJeOsaGvEGjDJRwmo0FkCs_3-BCLNBOlJsrHLoD3WhUMTNUMFIzVTVDRFE2RDRUUlIyQlRFWlMzVS4u";
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