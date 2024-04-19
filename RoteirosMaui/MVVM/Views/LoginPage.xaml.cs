using RoteirosMaui.MVVM.ViewsModels;

namespace RoteirosMaui.MVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
}