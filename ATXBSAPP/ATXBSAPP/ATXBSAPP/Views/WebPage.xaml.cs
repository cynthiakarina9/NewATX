﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public WebPage()
        {
            Title = "ChatBot";
            InitializeComponent();
            var browser = new WebView();
            browser.Source = "https://atxbot.azurewebsites.net/bot.html";            
                   
            this.Content = browser;
        }
        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void home_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }
    }
}