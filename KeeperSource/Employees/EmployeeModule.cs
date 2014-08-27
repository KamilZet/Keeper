using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Modularity;
using Ninject;
using Ninject.Modules;


namespace KeeperRichClient.Modules.Employees
{
        public class EmployeeModule : IModule
        {
            IKernel _ninkernel;
            IRegionManager _regmanager;

            public EmployeeModule(IKernel InKernel, IRegionManager InRegManager)
            {
                _ninkernel = InKernel;
                _regmanager = InRegManager;
            }
            public void Initialize()
            {
                _ninkernel.Bind<object>().To<EmployeeView>().Named("EmployeeView");
                _ninkernel.Bind<IEmployeeViewModel>().To<EmployeeViewModel>();
                _regmanager.RequestNavigate("ListerRegion", "EmployeeView");
                //this._regmanager.RegisterViewWithRegion("ListerRegion", () => this._ninkernel.Resolve<EmployeeView>());   
            }
        }
}   

