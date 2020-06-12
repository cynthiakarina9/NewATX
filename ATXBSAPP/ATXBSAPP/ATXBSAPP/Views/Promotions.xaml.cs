
using ATXAPP;
using ATXBSAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.NewsViewModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Promotions : ContentPage
    {      
        public List<ViewModels.NewsViewModel.ValueN> weatherData = new List<ViewModels.NewsViewModel.ValueN>();
        RestServicePromo _restService;

        public Promotions()
        {
            InitializeComponent();
            _restService = new RestServicePromo();

            const int RefreshDuration = 2;

            Prueba();
            get_soluciones.RefreshCommand = new Command(async () => {
                get_soluciones.IsRefreshing = true;
                await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
                Prueba();
                get_soluciones.IsRefreshing = false;
            });
        }

        public async void Prueba()
        {
            weatherData = await _restService.GetWeatherData2Async();
            ObservableCollection<ValueN> lista_noticias = new ObservableCollection<ValueN>(weatherData);
            get_soluciones.ItemsSource = lista_noticias;
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

        async void Mas_info_Clicked(object sender, EventArgs e)
        {
            var billId = (sender as Button).CommandParameter;

            await Browser.OpenAsync(billId.ToString());

        }

        //protected override async void OnAppearing()
        //{
        //    weatherData = await _restService.GetWeatherData2Async();
        //    BindingContext = weatherData;                   
        //}
    }
}