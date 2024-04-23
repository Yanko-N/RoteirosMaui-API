namespace RoteirosMaui.MVVM.Views;

public partial class MainMenuPage : ContentPage
{
	public MainMenuPage()
	{
		InitializeComponent();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);


        if (!App.UserManager.IsLoggedIn)
        {
            await Shell.Current.GoToAsync("///Loading");
        }
    }
}