using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using System.Windows;

namespace ScheduleManagement.Ui
{
    public class AppBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return (DependencyObject)Container.Resolve(typeof(MainPage), null);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType(typeof(MainPage), typeof(MainPage), null, null);
            Container.RegisterType(typeof(ViewModels.MainPageViewModel), typeof(ViewModels.MainPageViewModel), null, null);
        }

        protected override void InitializeShell()
        {
            Application.Current.RootVisual = (UIElement)Shell;
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(Modules.MainModule));
        }
    }
}
