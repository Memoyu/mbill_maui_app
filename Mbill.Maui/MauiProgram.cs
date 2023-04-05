using CommunityToolkit.Maui;
using Mbill.Maui.Extensions;
using Microsoft.Extensions.Logging;

namespace Mbill.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("iconfont.ttf", "iconfont");
            });
        //        .UseMaterialComponents(new List<string>
        //        {
        //            "OpenSans-Regular.ttf",
        //"OpenSans-Semibold.ttf", 
        //            "iconfont.ttf"
        //        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddViewModels();
        builder.Services.AddServices();

        return builder.Build();
	}
}
