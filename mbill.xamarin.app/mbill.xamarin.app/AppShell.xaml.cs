using mbill.xamarin.app.ViewModels;
using mbill.xamarin.app.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace mbill.xamarin.app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
