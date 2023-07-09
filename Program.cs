using Microsoft.Extensions.Hosting;
using System;


namespace DbApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args) 
        { 
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
        //При создании миграций механизм EF  найдет данный класс, так как он имеет статическую функцию CreateHostBuilder, выполнит ее и из сервисов 
        //хоста попытается извлечь контекст базы данных
        public IHostBuilder CreateHostBuilder(string[] args, App app)
        {
            return Host.
            CreateDefaultBuilder(args)
            .ConfigureServices(app.ConfigureServices);
        }
    }


}
