using mbill.xamarin.app.Services;
using mbill.xamarin.app.Views.Index;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace mbill.xamarin.app
{
    public partial class App : PrismApplication
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
        }

        protected override async void OnInitialized()
        {
            await NavigationService.NavigateAsync("/NavigationPage/HomePage");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
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
