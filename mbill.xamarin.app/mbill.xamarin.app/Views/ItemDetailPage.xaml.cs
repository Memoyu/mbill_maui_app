using mbill.xamarin.app.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace mbill.xamarin.app.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}