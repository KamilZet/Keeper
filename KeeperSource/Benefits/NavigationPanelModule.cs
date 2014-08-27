using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Ninject;

namespace KeeperRichClient.Modules.Benefits
{
    public class NavigationPanelModule : IModule
    {
        IKernel _ninkernel;
        IRegionManager _regmanager;

        public NavigationPanelModule(IKernel InKernel, IRegionManager InRegManager)
        {
            _ninkernel = InKernel;
            _regmanager = InRegManager;
        }  

        public void Initialize()
        {
            _ninkernel.Bind<object>().To<NavigationPanelView>().Named("NavigationPanelView");
            _ninkernel.Bind<INavigationViewModel>().To<NavigationPanelViewModel>();
            _regmanager.RequestNavigate("NavigationRegion", "NavigationPanelView");
            _regmanager.RegisterViewWithRegion("NavigationPanelView", typeof(NavigationPanelView));
        }
    }
}
