using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using static ATXBSAPP.ViewModels.NewsViewModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ATXAPP;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;

namespace ATXBSAPP.Views
{
    public partial class Update_noticias
    {
        const int RefreshDuration = 10;
        readonly Random random;
        bool isRefreshing;
        //PostRestPage nuevo = new PostRestPage();
        

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
            //nuevo.Prueba2();
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