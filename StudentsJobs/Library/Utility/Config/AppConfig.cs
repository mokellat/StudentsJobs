using Microsoft.Extensions.Configuration;

namespace StudentsJobs.Library.Utility.Config
{
    /// <summary>
    /// Classe qui gére la configuration
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public AppConfig()
        {
        }

        /// <summary>
        /// Méthode de récupération du fichier de config
        /// </summary>
        /// <returns></returns>
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.test.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
