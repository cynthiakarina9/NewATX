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

namespace ATXBSAPP.Views
{
    public partial class Update_noticias
    {
        RestService _restService;
        public ICommand RefreshCommand { protected set; get; }        

        bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }
        public Update_noticias()
        {
            RefreshCommand = new Command<string>((key) =>
            {
                _restService = new RestService();
                IsRefreshing = false;
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}    