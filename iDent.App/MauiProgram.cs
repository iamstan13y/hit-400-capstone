using CommunityToolkit.Maui;
using iDent.App.Data;
using iDent.App.Services;

namespace iDent.App
{
	public static partial class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder.UseMauiApp<App>()
				   .UseMauiCommunityToolkit()
				   .UseMauiCommunityToolkitMarkup()
				   .ConfigureFonts(fonts =>
				   {
					   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					   fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
				   });

			builder.Services.AddSingleton<MainViewModel>();
			builder.Services.AddSingleton<MainPage>();

            builder.Services.AddHttpClient<IIDentService, IDentService>(c =>
                c.BaseAddress = new Uri("https://localhost:7080"));

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
			builder.Services.AddSingleton(AppInfo.Current);
			builder.Services.AddSingleton<WeatherForecastService>();

			return builder.Build();
		}
	}
}
