using Microsoft.Extensions.Logging;
using RoteirosMaui.Abstractions;
using RoteirosMaui.Classes;
using RoteirosMaui.MVVM.Models;

namespace RoteirosMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<BaseRepository<Trip>>();
            builder.Services.AddSingleton<BaseRepository<Spot>>();
            builder.Services.AddSingleton<ConnectionApi>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
