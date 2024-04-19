using RoteirosMaui.MVVM.ViewsModels;

namespace RoteirosMaui.MVVM.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel();
	}
}