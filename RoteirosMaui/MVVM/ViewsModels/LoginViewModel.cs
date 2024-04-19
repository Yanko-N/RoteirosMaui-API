using PropertyChanged;
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

        
        public ICommand ChangeToRegisterCommand => new Command(async () =>
        {

        });

        public ICommand LogInCommand => new Command(async () =>
        {
            

        });
    }
}
