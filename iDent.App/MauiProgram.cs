using CommunityToolkit.Maui;
using iDent.App.Data;

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
