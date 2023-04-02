using Mbill.Maui.ViewModels;

namespace Mbill.Maui.Views;

public partial class MainPage : ContentPage
{
	private MainPageViewModel _vm => BindingContext as MainPageViewModel;

	public MainPage()
	{
		InitializeComponent();

	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.InitializeAsync();
    }
}