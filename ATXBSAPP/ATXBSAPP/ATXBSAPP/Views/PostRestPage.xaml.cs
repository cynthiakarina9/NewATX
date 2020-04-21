﻿using ATXAPP;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.NewsViewModel;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostRestPage : ContentPage
    {      
        public List<ValueN> weatherData = new List<ValueN>();
       
        RestService _restService; 
        public PostRestPage()
        {
            InitializeComponent();
            _restService = new RestService();           
        }

        protected override async void OnAppearing()
        {
            if (weatherData.Count < 1)
            {
                weatherData = await _restService.GetWeatherDataAsync();
                BindingContext = weatherData;
                OnAppearing();
            }
        }
        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://atxbot.azurewebsites.net/bot.html");
        }
        async void Link0_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://atx.mx/news/");
        }
        async void Link1_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data1 = weatherData[0].new_linkpost;
            await Browser.OpenAsync(data1);
        }

        async void Link2_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data2 = weatherData[1].new_linkpost;
            await Browser.OpenAsync(data2);
        }

        async void Link3_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data3 = weatherData[2].new_linkpost;
            await Browser.OpenAsync(data3);
        }

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void home_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }

        async void Link4_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data4 = weatherData[3].new_linkpost;
            await Browser.OpenAsync(data4);
        }


        const int RefreshDuration = 2;
        int itemNumber = 1;
        readonly Random random;
        bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }    

        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());   

        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            weatherData = await _restService.GetWeatherDataAsync();
            IsRefreshing = false;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}      