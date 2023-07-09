using Microsoft.Extensions.DependencyInjection;

namespace DbApp.ViewModels
{
    class ViewModelLocator
    {
        App app = new App();
        public MainWindowViewModel MainWindowModel => app.Services.GetRequiredService<MainWindowViewModel>();
    }
}
