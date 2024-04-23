using RoteirosMaui.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteirosMaui.Classes
{
    public class UserController
    {
        public int UtilizadorId { 
            get { 
                return CurrentUtilizador.Id;
            }  
        }
        public Utilizador CurrentUtilizador { get; set; } = new Utilizador();

        public bool IsLoggedIn { get; set; } = false;

        public string LoggedEmail { get; set; } = " ";


        public const string Preference_IsLogged = "IsLoggedPreference";

        public const string Preference_LoggedUserEmail = "Email";


        public UserController() { 
            IsLoggedIn = Preferences.Get(Preference_IsLogged,false);
            LoggedEmail = Preferences.Get(Preference_LoggedUserEmail, " ");
        }

        public void SetUser(Utilizador utilizador)
        {
            CurrentUtilizador = utilizador;
            LoggedEmail = utilizador.Email;
            IsLoggedIn = true;

            SetPreferences();
        }

        public void ClearUser()
        {
            CurrentUtilizador = new Utilizador();
            IsLoggedIn = false;
            LoggedEmail = " ";

            SetPreferences();
        }

        public void SetPreferences()
        {
            Preferences.Set(Preference_IsLogged, IsLoggedIn);
            Preferences.Set(Preference_LoggedUserEmail, CurrentUtilizador.Email);
        }
    }
}
