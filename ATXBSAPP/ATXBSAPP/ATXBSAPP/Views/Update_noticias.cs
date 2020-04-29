using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ATXAPP;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using ObjCRuntime;
using static ATXBSAPP.ViewModels.NewsViewModel;
using ATXBSAPP.ViewModels;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class Update_noticias : INotifyPropertyChanged
    {
        public RestService _restService;
        public List<ViewModels.NewsViewModel.ValueN> weatherData = new List<ViewModels.NewsViewModel.ValueN>();    
                   
        const int RefreshDuration = 2;
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
     
        public Update_noticias()
        {
            _restService = new RestService();
            Prueba();
            //ObservableCollection<ValueN> lista_noticias = new ObservableCollection<ValueN>(new RootObject().value());
            //get_noticias
        }

        public async void Prueba()
        {
            try
            {
                weatherData = await _restService.GetWeatherDataAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }
        }

        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            Prueba();
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