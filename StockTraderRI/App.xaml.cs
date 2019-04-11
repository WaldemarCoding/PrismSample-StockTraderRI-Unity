using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Windows;

namespace StockTraderRI
{
    public partial class App
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    StockTraderRIBootstrapper bootstrapper = new StockTraderRIBootstrapper();
        //    bootstrapper.Run();
        //    this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        //}
        protected override Window CreateShell()
        {
            // Use the container to create an instance of the shell.
            Shell view = this.Container.Resolve<Shell>();
            view.DataContext = new ShellViewModel();
            return view;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule(typeof(Modules.Market.MarketModule));
            moduleCatalog.AddModule(typeof(Modules.Position.PositionModule));
            moduleCatalog.AddModule(typeof(Modules.Watch.WatchModule));
            moduleCatalog.AddModule(typeof(Modules.News.NewsModule));
        }
    }
}
