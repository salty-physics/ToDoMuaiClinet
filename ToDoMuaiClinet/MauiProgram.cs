using ToDoMuaiClinet.DataServices;
using ToDoMuaiClinet.Pages;

namespace ToDoMuaiClinet;

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

        //builder.Services.AddSingleton<IRestDataService, RestDataService>();  //zalecany jest httpclientfactory
        builder.Services.AddHttpClient<IRestDataService, RestDataService>();

        builder.Services.AddSingleton<MainPage>(); //lifetime: ciagle
		builder.Services.AddTransient<ManageToDoPage>(); //dla stron on/off lifetime:request

		return builder.Build();
	}
}
