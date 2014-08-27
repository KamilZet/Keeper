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
    public class ParkingModule : IModule
    {
        IKernel _ninkernel;
        IRegionManager _regmanager;

        public ParkingModule(IKernel InKernel, IRegionManager InRegManager)
        {
            _ninkernel = InKernel;
            _regmanager = InRegManager;
        }

        public void Initialize()
        {
            _ninkernel.Bind<object>().To<ParkingView>().Named("ParkingView");
            _ninkernel.Bind<IParkingViewModel>().To<ParkingViewModel>();

        }
    }
}
