using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using StockTraderRI.Infrastructure;
using StockTraderRI.Infrastructure.Interfaces;
using StockTraderRI.Modules.Market.Services;
using StockTraderRI.Modules.Market.TrendLine;
using Unity;

namespace StockTraderRI.Modules.Market
{
    public class MarketModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //private MainRegionController _mainRegionController;

        public MarketModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.ResearchRegion, () => this.container.Resolve<TrendLineView>());
            //this._mainRegionController = this.container.Resolve<MainRegionController>();
            //this.regionManager.RegisterViewWithRegion(RegionNames.TabRegion,
            //                                           () => this.container.Resolve<EmployeeDetailsView>());
            //this.regionManager.RegisterViewWithRegion(RegionNames.TabRegion,
            //                                           () => this.container.Resolve<EmployeeProjectsView>());
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMarketFeedService, MarketFeedService>();
            containerRegistry.Register<IMarketHistoryService, MarketHistoryService>();
            containerRegistry.Register<TrendLineViewModel, TrendLineViewModel>();
        }
    }
}
