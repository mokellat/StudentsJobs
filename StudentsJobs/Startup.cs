using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
//using StudentsJobs.Library;
using iTextSharp.text.pdf.parser;
using StudentsJobs.Models;
using StudentsJobs.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace StudentsJobs
{
    public class Startup
    {
        /// <summary>
        /// Configuration du projet
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Méthode principale
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Service de configuration
        /// Cette méthode est appelée par le runtime. Utilisez cette méthode pour ajouter des services au conteneur. 
        /// </summary>
        /// <param name="services">Collection de services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                //----------------------------------------
                // Specifier le context pour l'auto migration
                //----------------------------------------
                services.AddDbContext<StudentJobContext>(options =>
                          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

                //services.AddDbContext<StudentJobContext>(options =>
                //            options.UseSqlServer(Configuration.GetConnectionString("NewConnection")));

                // On ajoute les controleurs
                //services.AddControllers().AddNewtonsoftJson(options =>
                //        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

                services.AddSwaggerGen();

                //services.AddJwtTokenAuthentication(Configuration);

                // On ajoute les paramètres d'authentification avec azure
                //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAdB2C"));

                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
                //        .AddJwtBearer(options =>
                //        {
                //            // configure the options for JWT authentication
                //        });

                services.AddCors();

                // On ajoute signalr
                services.AddSignalR();

                services.AddMvc();

                services.AddScoped<SignInService>();
                services.AddScoped<SignUpService>();
                services.AddScoped<StudentProfileService>();
                services.AddScoped<JobPostingService>();
                services.AddScoped<ApplicationService>();

                //services.AddScoped<IServiceProvider, ServiceProvider> ();

                IdentityModelEventSource.ShowPII = true;

                //services.AddSingleton<SponsoringManager>();
            }
            catch (Exception ex)
            {
                throw new Exception("1st method : " + ex.Message);
            }
        }

        /// <summary>
        /// Méthode appelée pour le runtime. On l'utilise pour paramétrer le pipeline HTTP.
        /// </summary>
        /// <param name="app">Application</param>
        /// <param name="env">Environnement</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                // On active la redirection https

                // On active l'accès vers les fichiers dans le dossier wwwroot
                app.UseStaticFiles();

                // On active les web sockets
                app.UseWebSockets();


                // global cors policy - On autorise tous les cors. Origin gérées par la Web App
                app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials

                app.UseHttpsRedirection();

                app.UseAuthentication();

                // On active le routing
                app.UseRouting();

                app.UseAuthorization();


                // On définit les endpoints
                app.UseEndpoints(endpoints =>
                {
                    // Controleurs
                    endpoints.MapControllers();

                    // Chathub
                    //endpoints.MapHub<ChatHub>("/ChatHub");
                });
            }
            catch (Exception ex)
            {
                throw new Exception("2nd method : " + ex.Message);
            }
        }
    }
}
