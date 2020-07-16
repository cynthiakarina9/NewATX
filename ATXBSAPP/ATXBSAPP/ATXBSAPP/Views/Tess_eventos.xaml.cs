using ATXAPP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.WebinarVewModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tess_eventos : ContentPage
    {
        public List<ViewModels.WebinarVewModel.ValueW> weatherData3 = new List<ViewModels.WebinarVewModel.ValueW>();
        RestServiceWebinar _restService;
        public Tess_eventos()
        {
            InitializeComponent();
            _restService = new RestServiceWebinar();


            const int RefreshDuration = 2;

            Prueba();
            get_webinar.RefreshCommand = new Command(async () => {
                get_webinar.IsRefreshing = true;
                await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
                Prueba();
                get_webinar.IsRefreshing = false;
            });
        }
        public async void Prueba()
        {
            weatherData3 = await _restService.GetWeatherData3Async();
            ObservableCollection<ValueW> lista_noticias = new ObservableCollection<ValueW>(weatherData3);
            get_webinar.ItemsSource = lista_noticias;
        }

        async void Mas_info_Clicked(object sender, EventArgs e)
        {
            var billId = (sender as Button).CommandParameter;
            await Browser.OpenAsync(billId.ToString());
        }

        protected override async void OnAppearing()
        {
            weatherData3 = await _restService.GetWeatherData3Async();
            BindingContext = weatherData3;
        }
        async void Chat_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(9);
        }
        async void Link1_Clicked(object sender, EventArgs e)
        {
            weatherData3 = await _restService.GetWeatherData3Async();
            string data1 = weatherData3[0].atx_linkderegistro;
            await Browser.OpenAsync(data1);
        }
        async void Link2_Clicked(object sender, EventArgs e)
        {
            weatherData3 = await _restService.GetWeatherData3Async();
            string data2 = weatherData3[1].atx_linkderegistro;
            await Browser.OpenAsync(data2);
        }
        async void Link3_Clicked(object sender, EventArgs e)
        {
            weatherData3 = await _restService.GetWeatherData3Async();
            string data3 = weatherData3[1].atx_linkderegistro;
            await Browser.OpenAsync(data3);
        }
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void home_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }
    }
}