using PropertyChanged;
using RoteirosMaui.Classes;
using RoteirosMaui.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RoteirosMaui.MVVM.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        public string Email { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string MessageStatus { get; set; } = String.Empty;
        public bool IsValidationErrorVisible { get; set; } = false;

        public ICommand CloseValidationStatusWindowCommand => new Command(async () =>
        {
            IsValidationErrorVisible = false;
        });

       
        public ICommand LogInCommand => new Command(async () =>
        {
            //Temos de verificar na DB da API se realmente existe alguem com esse email 
            var userApiList = await App.ConnectionApi.utilizadorConnectionApi.GetItems("Email", this.Email);


            if (userApiList != null)
            {
                if (userApiList.Count == 1)
                {
                    var user = userApiList.First();
                    if (EncripterWrapper.CheckHashAndPassword(Password,user.Password) )
                    {
                        App.UserManager.SetUser(user);
                        await Shell.Current.GoToAsync($"///MainPage");

                    }
                }
            }
        });

        
    }
}
