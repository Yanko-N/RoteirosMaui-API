using RoteirosMaui.Classes;
using RoteirosMaui.MVVM.ViewsModels;

namespace RoteirosMaui.MVVM.Views;

public partial class UserProfilePage : ContentPage
{
    
	public UserProfilePage()
	{
		InitializeComponent();
		BindingContext = new ProfileViewModel();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        EventsController.Raise_UserProfileNavigated();

        if (!App.UserManager.IsLoggedIn)
        {
            await Shell.Current.GoToAsync("///Loading");
        }
    }
}