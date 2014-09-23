
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
    public class EmployeeBannerModule :IModule
    {
        IKernel kernel;
        IRegionManager regionManager;

        public EmployeeBannerModule(IKernel InKernel, IRegionManager InRegManager)
        {
            kernel = InKernel;
            regionManager = InRegManager;
        }            
        public void Initialize()
        {
            kernel.Bind<object>().To<EmployeeBannerView>().Named("EmployeeBannerView");
            kernel.Bind<IEmployeeBannerViewModel>().To<EmployeeBannerViewModel>();

            regionManager.RequestNavigate("EmployeeBannerRegion", "EmployeeBannerView");
            regionManager.RegisterViewWithRegion("EmployeeBannerView", typeof(EmployeeBannerView));
        }                 
    }
    }

