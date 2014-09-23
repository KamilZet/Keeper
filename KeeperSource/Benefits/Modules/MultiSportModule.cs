using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Modularity;
using Ninject;
using Ninject.Modules;

namespace KeeperRichClient.Modules.Benefits
{
    public class MultiSportModule : IModule
    {
        IKernel _ninkernel;
        IRegionManager _regmanager;

        public MultiSportModule(IKernel InKernel, IRegionManager InRegManager)
        {
            _ninkernel = InKernel;
            _regmanager = InRegManager;
        }            
        public void Initialize()
        {
            _ninkernel.Bind<object>().To<MultiSportView>().Named("MultiSportView");
            _ninkernel.Bind<IMultiSportViewModel>().To<MultiSportViewModel>();
            
            //need to load this dynamically as callback to na
            //_regmanager.RequestNavigate("MainContentRegion", "MultiSportView");
            //_regmanager.RegisterViewWithRegion("MultiSportView", typeof(MultiSportView));
        }            
      
    }
}
