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
    public class RegisterViewModel
    {
        public string MessageStatus { get; set; } = String.Empty;
        public bool IsValidationErrorVisible { get; set; } = false;
        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; } = DateTime.Now;

        public string Password { get; set; } = String.Empty;
        public string ConfirmPassword { get; set; } = String.Empty;


        public RegisterViewModel()
        {

            //construtor

        }
        public ICommand CloseValidationStatusWindowCommand => new Command(async () =>
        {
            IsValidationErrorVisible = false;
        });

        public ICommand RegisterCommand => new Command(async () =>
        {
            await RegisterAsync();
        });

        private async Task RegisterAsync()
        {
            IsValidationErrorVisible = false;
            List<string> errors = new List<string>();
            bool isValid = true;

            if (String.IsNullOrWhiteSpace(Name))
            {
                isValid = false;
                errors.Add("Name is empty");
            }

            if (String.IsNullOrWhiteSpace(Email))
            {
                isValid = false;
                errors.Add("Email is empty");
            }

            if (String.IsNullOrWhiteSpace(Password))
            {
                isValid = false;
                errors.Add("Password is empty");
            }

            if (String.IsNullOrWhiteSpace(ConfirmPassword))
            {
                isValid = false;
                errors.Add("Confirm Password is empty");
            }

            //Temos de verificar na DB da API se realmente existe alguem com esse email 
            var userApiList = await App.ConnectionApi.utilizadorConnectionApi.GetItems("Email", this.Email);


            if (userApiList != null)
            {
                if (userApiList.Count == 0)
                {
                    if (Password == ConfirmPassword)
                    {
                        //A password terá de ser codificada antes de ser guardada
                        var hashedPassword = EncripterWrapper.HashPassword(this.Password);

                        //AGORA POR TERMOS DE DEBUG VAMOS SÓ CRIAR UM USER
                        var newUser = new Utilizador
                        {
                            Name = this.Name,
                            Email = this.Email,
                            BirthDate = this.BirthDate,
                            Password = hashedPassword
                        };

                        if (isValid)
                        {
                            //AQUI IREMOS CRIAR O UTILIZADOR

                        }
                    }
                    else
                    {
                        isValid = false;
                        errors.Add("The Passwords don't match");
                    }
                }
                else
                {

                    isValid = false;
                    errors.Add("There is already an account with the same Email please try with another one");
                }

            }
            else
            {
                isValid = false;
                errors.Add("There was a connection Error please try again!");
            }


            StringBuilder stringBuilder = new StringBuilder();
            foreach (var s in errors)
            {
                stringBuilder.Append($"\n{s}");
            }

            MessageStatus = stringBuilder.ToString();
            if (!isValid)
            {
                IsValidationErrorVisible = true;
            }
        }

    }
}
