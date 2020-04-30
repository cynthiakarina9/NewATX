using ATXAPP;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.NewsViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.Collections.ObjectModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostRestPage : ContentPage
    {
        public RestService _restService;
        public List<ViewModels.NewsViewModel.ValueN> weatherData = new List<ViewModels.NewsViewModel.ValueN>();

        public PostRestPage()
        {
            InitializeComponent();
            _restService = new RestService();
            const int RefreshDuration = 2;

            Prueba();
            get_noticias.RefreshCommand = new Command(async () => {
                get_noticias.IsRefreshing = true;
                await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
                Prueba();
                get_noticias.IsRefreshing = false;
            });
        }

        public async void Prueba()
        {
            weatherData = await _restService.GetWeatherDataAsync();
            ObservableCollection<ValueN> lista_noticias = new ObservableCollection<ValueN>(weatherData);
            get_noticias.ItemsSource = lista_noticias;
        }   

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void home_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(9);
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

        async void Link4_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data4 = weatherData[3].new_linkpost;
            await Browser.OpenAsync(data4);
        }              
    }
}