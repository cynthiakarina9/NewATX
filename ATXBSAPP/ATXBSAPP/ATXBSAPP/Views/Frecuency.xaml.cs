﻿
using ATXAPP;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.FrecuencyViewModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frecuency : ContentPage
    {
        public List<ValueF> weatherData = new List<ValueF>();
        RestServiceFrecuency _restService;
        public Frecuency()
        {
            InitializeComponent();
            _restService = new RestServiceFrecuency();
        }

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void home_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://atxbot.azurewebsites.net/bot.html"); 
        }
        protected override async void OnAppearing()
        {
            weatherData = await _restService.GetWeatherDataAsync();
            BindingContext = weatherData;
        }
    }
}