
using ATXAPP;
using ATXBSAPP.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.NewsViewModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Promotions : ContentPage
    {
        public List<ValueN> weatherData = new List<ValueN>();
        RestServicePromo _restService;
        public Promotions()
        {
            InitializeComponent();
            _restService = new RestServicePromo();
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://atxbot.azurewebsites.net/bot.html");
        }

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void home_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }

        protected override async void OnAppearing()
        {
            if (weatherData.Count < 1)
            {
                weatherData = await _restService.GetWeatherData2Async();
                BindingContext = weatherData;
                OnAppearing();
            }                   
        }
    }
}