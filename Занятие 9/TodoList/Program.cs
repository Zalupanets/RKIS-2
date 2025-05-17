using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.EntityFrameworkCore;
using TodoList.UI;
using Splat;
using Microsoft.Extensions.Configuration;

namespace TodoList
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI()
                .AfterSetup(_ => RegisterServices());
        }

        private static void RegisterServices()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Locator.CurrentMutable.Register(() =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=TodoList.db";
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlite(connectionString);
                return new AppDbContext(optionsBuilder.Options);
            });

            Locator.CurrentMutable.Register(() =>
            {
                {
                    var dbContext = Locator.Current.GetService<AppDbContext>()!;
                    return new TodoService(dbContext);
                }
            });
        }
    }
}
