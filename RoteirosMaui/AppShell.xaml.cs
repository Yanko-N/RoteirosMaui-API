using RoteirosMaui.MVVM.Views;

namespace RoteirosMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            CreateRoutes();
            InitializeComponent();
        }

        void CreateRoutes()
        {
            Routing.RegisterRoute("registerPage", typeof(RegisterPage));
        }
    }
}
