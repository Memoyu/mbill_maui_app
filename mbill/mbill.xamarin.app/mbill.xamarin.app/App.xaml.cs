using mbill.xamarin.app.Services;
using mbill.xamarin.app.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mbill.xamarin.app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
