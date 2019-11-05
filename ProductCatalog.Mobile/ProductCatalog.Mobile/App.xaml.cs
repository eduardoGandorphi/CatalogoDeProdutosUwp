using ProductCatalog.Mobile.DAO;
using ProductCatalog.Mobile.Models;
using ProductCatalog.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProductCatalog.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            
            var bancoInicial = new Connection();
            bancoInicial.StartDB();

            MainPage = new NavigationPage(new CatalogoView());
        }

        private void IniciaBanco()
        {
         
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
