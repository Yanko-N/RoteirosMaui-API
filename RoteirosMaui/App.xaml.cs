using RoteirosMaui.Abstractions;
using RoteirosMaui.Classes;
using RoteirosMaui.MVVM.Models;

namespace RoteirosMaui
{
    public partial class App : Application
    {
        public static BaseRepository<Trip> TripRepository { get; private set; }
        public static BaseRepository<Spot> SpotRepository { get; private set; }
        public static ConnectionApi ConnectionApi { get; private set; }
        public App(BaseRepository<Trip> tripRepo,BaseRepository<Spot> spotRepo,ConnectionApi api)
        {
            InitializeComponent();

            TripRepository = tripRepo;
            SpotRepository = spotRepo;
            ConnectionApi = api;

            MainPage = new AppShell();
        }
    }
}
