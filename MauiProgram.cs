using Lab3.Model;
using Microsoft.Extensions.Logging;
namespace Lab3;

/**
 * Name: Alexsa Walczak
 * Description: Lab 3
 * Date: 10/01/23
 * Bugs: I couldn't get the FetchPassword() method to work, so I had to put my
 *       username and password as Strings in the Database file.
 * Reflection: I spent a lot of time trying to get my connection string to correct,
 *             but I found out that it was due to trying to fetch the password from
 *             the user secrets, so I gave up on that. The SQL part of the lab went
 *             smoothly, as well as fixing some of my previous mistakes from Lab 2.
 */
public static class MauiProgram
{
    public static IBusinessLogic BusinessLogic = new BusinessLogic();

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}