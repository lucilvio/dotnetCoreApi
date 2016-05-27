using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Dominio.Repositorios;
using TodoApi.Infra;
using TodoApi.Models;
using TodoApi.Servicos;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup(typeof(Comecar))
            .UseContentRoot(Directory.GetCurrentDirectory())
            .Build();
            
            host.Run();
        }
    }
    
    public class Comecar {
        
        public Comecar(IHostingEnvironment env) {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        
        public IConfigurationRoot Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddDbContext<Contexto>((serviceProvider, options) => {
               options
               .UseSqlServer(this.Configuration["ConnectionStrings:Default"]);
            });
            
            services.AddScoped<IRepositorio<Usuario>, RepositorioDeUsuarios>();
            services.AddSingleton<ServicoDeListas, ServicoDeListas>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseDeveloperExceptionPage();
            
            app.UseMvc();
        }
    }
    
}
