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
    public class HealthcareModule : IModule
    {
        IKernel _ninkernel;
        IRegionManager _regmanager;

        public HealthcareModule(IKernel InKernel,IRegionManager InRegManager)
        {
            _ninkernel = InKernel;
            _regmanager = InRegManager;
        }            
        public void Initialize()
        {
            _ninkernel.Bind<object>().To<HealthcareView>().Named("HealthcareView");
            _ninkernel.Bind<IHealthcareViewModel>().To<HealthcareViewModel>();


            _regmanager.RequestNavigate("MainContentRegion", "HealthcareView");
            _regmanager.RegisterViewWithRegion("HealthcareView",typeof(HealthcareView));
        }                 
    }
}
