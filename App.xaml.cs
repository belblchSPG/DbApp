using DbApp.Data;
using DbApp.Services;
using DbApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace DbApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {

        private IHost __Host;

        public IHost Host
        {
            
            get
            {
                Program program = new Program();
                return __Host
            = program.CreateHostBuilder(Environment.GetCommandLineArgs(), this).Build();
            }
        }

        public IServiceProvider Services => Host.Services;

        internal void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
           .AddDatabase(host.Configuration.GetSection("Database"))
           .AddServices()
           .AddViewModels()
        ;

        protected override void OnStartup(StartupEventArgs e)
        {

            var host = Host;

                using (var scope = Services.CreateScope())
                     scope.ServiceProvider.GetRequiredService<DbInitializer>().Initialize();
                base.OnStartup(e);
                host.Start();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
