using System;
using System.ComponentModel;
using Xamarin.Forms;
using ATXBSAPP.ViewModels;
using Xamarin.Essentials;
using System.Windows.Input;
using ATXAPP;
using System.Collections.Generic;
using static ATXBSAPP.ViewModels.NewsViewModel;

namespace ATXBSAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        public List<ValueN> weatherData = new List<ValueN>();
        public List<ValueN> weatherData2 = new List<ValueN>();

        RestService _restService;
        public ItemsPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        protected override async void OnAppearing()
        {
            if (weatherData.Count == 0)
            {
                weatherData = await _restService.GetWeatherDataAsync();
                BindingContext = weatherData;
                OnAppearing();
            }
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            //await Browser.OpenAsync("https://atxbot.azurewebsites.net/bot.html");

            await RootPage.NavigateFromMenu(9);
        }
        async void Webinar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Webinar()));
        }
        
        






        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void noticias(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(2);
        }

        //private void noticias(object sender, EventArgs e) 
        //{
        //    ((NavigationPage)this.Parent).PushAsync(new PostRestPage());
        //}

        async void webinars(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(5);
        }

        async void soluciones(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(3);
        }

        async void ebooks(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(6);
        }

        async void videos(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(7);
        }

        async void acercade(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(1);
        }






    }
}