using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ScheduleManagement.Ui.ViewModels;

namespace ScheduleManagement.Ui.Modules
{
    public class MainModule : IModule
    {
        private readonly IUnityContainer _container;

        public MainModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType(typeof(MainPageViewModel), typeof(MainPageViewModel), null, null);
        }
    }
}
