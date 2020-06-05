using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class Menu_II : ContentPage
    {
        public Menu_II()
        {

            //var navigationPage = Application.Current.MainPage as NavigationPage;
            //navigationPage.BarBackgroundColor = Color.Red;

            InitializeComponent();           
        }


        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        async void noticias(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(2);
        }

        //private void noticias(object sender, EventArgs e) 
        //{
        //    ((NavigationPage)this.Parent).PushAsync(new PostRestPage());
        //}

        async void webinars(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(5);
        }

        async void soluciones(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(3);
        }

        async void ebooks(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(6);
        }

        async void videos(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(7);
        }

        async void acercade(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(1);
        }

    }
}