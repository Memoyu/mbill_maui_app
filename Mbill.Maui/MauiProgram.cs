using Material.Components.Maui.Extensions;
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
            .UseMaterialComponents(new List<string>
            {
                "OpenSans-Regular.ttf",
				"OpenSans-Semibold.ttf", 
                "iconfont.ttf"
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddViewModels();

		return builder.Build();
	}
}
