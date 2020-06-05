
using ATXAPP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        RestServiceFrecuency _restService;
        public List<ViewModels.FrecuencyViewModel.ValueF> weatherData = new List<ViewModels.FrecuencyViewModel.ValueF>();
        public Frecuency()
        {
            InitializeComponent();
            _restService = new RestServiceFrecuency();
            //BindingContext = this;
            const int RefreshDuration = 2;

            Prueba();
            get_noticias.RefreshCommand = new Command(async () => {
                get_noticias.IsRefreshing = true;
                await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
                Prueba();
                get_noticias.IsRefreshing = false;
            });

        }
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void home_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }



        public async void Prueba()
        {
            weatherData = await _restService.GetWeatherDataAsync();
            ObservableCollection<ValueF> lista_noticias = new ObservableCollection<ValueF>(weatherData);
            get_noticias.ItemsSource = lista_noticias;
        }

        async void Mas_info_Clicked(object sender, EventArgs e)
        {
            var billId = (sender as Button).CommandParameter;

            await Browser.OpenAsync(billId.ToString());

        }

        //protected override async void OnAppearing()
        //{
        //    weatherData = await _restService.GetWeatherDataAsync();
        //    BindingContext = weatherData;
        //}













        async void Chat_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(9);
        }


        async void Link1_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data1 = weatherData[0].new_url;
            await Browser.OpenAsync(data1);
        }

        async void Link2_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data2 = weatherData[1].new_url;
            await Browser.OpenAsync(data2);
        }

        async void Link3_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data3 = weatherData[2].new_url;
            await Browser.OpenAsync(data3);
        }

        async void Link4_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data4 = weatherData[3].new_url;
            await Browser.OpenAsync(data4);
        }

        async void Link5_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data5 = weatherData[4].new_url;
            await Browser.OpenAsync(data5);
        }

        async void Link6_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data6 = weatherData[5].new_url;
            await Browser.OpenAsync(data6);
        }
    }
}