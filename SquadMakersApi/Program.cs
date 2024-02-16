using SquadMakersApi;

namespace SquadMakersApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureLogging(options =>
                {
                    options.AddConsole();
                });
                webBuilder.UseStartup<Startup>();
            });
    }
}