using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using StudentsJobs;

namespace StudentsJobs
{
    /// <summary>
    /// Classe program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// M�thode principale
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Constructeur d'h�te
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
