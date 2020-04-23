﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using ATXAPP;
using ATXBSAPP.Models;

namespace ATXBSAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.News:
                        MenuPages.Add(id, new NavigationPage(new PostRestPage()));
                        break;
                    case (int)MenuItemType.Retro:
                        MenuPages.Add(id, new NavigationPage(new Retroalimentacion()));
                        break;
                    case (int)MenuItemType.Webinar:
                        MenuPages.Add(id, new NavigationPage(new Webinar()));
                        break;
                    case (int)MenuItemType.Promotions:
                        MenuPages.Add(id, new NavigationPage(new Promotions()));
                        break;
                    case (int)MenuItemType.Frecuency:
                        MenuPages.Add(id, new NavigationPage(new Frecuency()));
                        break;
                    case (int)MenuItemType.Youtube:
                        MenuPages.Add(id, new NavigationPage(new youtube_view()));
                        break;
                    case (int)MenuItemType.Chat:
                        MenuPages.Add(id, new NavigationPage(new WebPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}