namespace RoteirosMaui.MVVM.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        
        if (App.UserManager.IsLoggedIn)
        {
            if (String.IsNullOrWhiteSpace(App.UserManager.LoggedEmail))
            {
                App.UserManager.ClearUser();
                await Shell.Current.GoToAsync($"///Authentication/Login");
            }

            var user = await App.ConnectionApi.utilizadorConnectionApi.GetItem("Email", App.UserManager.LoggedEmail);
            if (user == null)
            {
                App.UserManager.ClearUser();
                await Shell.Current.GoToAsync($"///Authentication/Login");
            }

            App.UserManager.SetUser(user);
            await Shell.Current.GoToAsync($"///MainPage");

        }
        else
        {
            await Shell.Current.GoToAsync($"///Authentication/Login");

        }

    }

  
}