using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ATXBSAPP.Services;
using ATXBSAPP.Views;
using AndroidSpecific = Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace ATXBSAPP
{
    public partial class App : Application
    {        

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //MainPage = new NavigationPage(new Menu_II());     

            AndroidSpecific.Application.SetWindowSoftInputModeAdjust(this, AndroidSpecific.WindowSoftInputModeAdjust.Resize);

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
