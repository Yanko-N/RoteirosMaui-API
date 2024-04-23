using PropertyChanged;
using RoteirosMaui.Classes;
using RoteirosMaui.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RoteirosMaui.MVVM.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProfileViewModel
    {
        //PARA ALERTA///////
        public string MessageStatus { get; set; } = String.Empty;
        public bool IsValidationErrorVisible { get; set; } = false;
        ////////////////////


        public Utilizador User { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }

        public ProfileViewModel()
        {
            EventsController.UserProfileNavigated += ChangeUser;
        }

        public ICommand LogOutCommand => new Command(async () =>
        {
            App.UserManager.ClearUser();
            await Shell.Current.GoToAsync("///Loading");

        });
        public ICommand CloseValidationStatusWindowCommand => new Command(async () =>
        {
            CloseValidationStatusWindow();
        });
        public ICommand UpdatePassword => new Command(async () =>
        {

            if(String.IsNullOrWhiteSpace(NewPassword) || String.IsNullOrWhiteSpace(ConfirmNewPassword))
            {
                ShowAlert($"There are empty Fields to be finished");
                return;
            }

            if (!NewPassword.Equals(ConfirmNewPassword))
            {
                ShowAlert($"The Passwords Don't Match");
                return;

            }

            User.Password = EncripterWrapper.HashPassword(NewPassword);
            var updateState = await App.ConnectionApi.utilizadorConnectionApi.PutItem(User);

            if (updateState)
            {
                App.UserManager.SetUser(User);

            }
            else
            {
                User = App.UserManager.CurrentUtilizador;
                ShowAlert($"There was an error updating the user info of {User.Name}");

                return;

            }

        });
        public ICommand UpdateInfoCommand => new Command(async () =>
        {
            var updateState = await App.ConnectionApi.utilizadorConnectionApi.PutItem(User);

            if (updateState)
            {
                App.UserManager.SetUser(User);

            }
            else
            {
                User = App.UserManager.CurrentUtilizador;

                ShowAlert($"There was an error updating the user info of {User.Name}");

                
            }

        });

        void ShowAlert(string message)
        {
            MessageStatus = message;
            IsValidationErrorVisible = true;

        }
        void CloseValidationStatusWindow()
        {
            IsValidationErrorVisible = false;

        }
        
        public void ChangeUser(object sender, EventArgs e)
        {
            User = App.UserManager.CurrentUtilizador;
        }
    }
}
