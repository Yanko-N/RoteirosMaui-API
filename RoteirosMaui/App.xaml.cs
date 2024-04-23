using RoteirosMaui.Abstractions;
using RoteirosMaui.Classes;
using RoteirosMaui.MVVM.Models;
using RoteirosMaui.MVVM.Views;

namespace RoteirosMaui
{
    public partial class App : Application
    {
        //LOCAL REPOSITORIES - LOCAL DATABASE
        public static BaseRepository<Trip> TripRepository { get; private set; }
        public static BaseRepository<Spot> SpotRepository { get; private set; }

        //CONNECTION TO THE API
        public static ConnectionApi ConnectionApi { get; private set; }

        //SINGLETOON THAT CONTROLLES APP LOGGED USER
        public static UserController UserManager { get; private set; }

        public App(BaseRepository<Trip> tripRepo,BaseRepository<Spot> spotRepo,ConnectionApi api,UserController controller)
        {
            InitializeComponent();
            
            //local DB
            TripRepository = tripRepo;
            SpotRepository = spotRepo;

            //api
            ConnectionApi = api;

            //User Controller to manage Logged User
            UserManager = controller;

            MainPage = new AppShell();
        }
    }
}
