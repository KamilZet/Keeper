using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using KeeperRichClient.Modules.Benefits;
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees;

using Ninject;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.PubSubEvents;


namespace KeeperRichClient.Appl
{
    class BootStrapper : NinjectBootstrapper
    {

        public BootStrapper(){ }

        protected override DependencyObject CreateShell()
        {
            return Kernel.Resolve<ShellWindow>();
        }

        protected override void InitializeShell(){

            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        
            IRegionManager irm = ServiceLocator.Current.GetInstance<IRegionManager>();
            

            //irm.RegisterViewWithRegion("MainContentRegion",typeof(HealthcareView));
            //irm.RegisterViewWithRegion("ListerRegion", typeof(HealthcareView));
            //irm.RegisterViewWithRegion("CommandsRegion", typeof(HealthcareView));
            //irm.RegisterViewWithRegion("TitleRegion", typeof(HealthcareView));
            //irm.RegisterViewWithRegion("NavigationRegion", typeof(HealthcareView));
        }
        protected override void ConfigureModuleCatalog()
        {
            Type EmployeeViewModel = typeof(EmployeeModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = EmployeeViewModel.Name,
                ModuleType = EmployeeViewModel.AssemblyQualifiedName
            });

            
            Type HealthcareModule = typeof(HealthcareModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
                {
                    ModuleName = HealthcareModule.Name,
                    ModuleType = HealthcareModule.AssemblyQualifiedName
                });


            Type MultisportViewModel = typeof(MultiSportModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = MultisportViewModel.Name,
                ModuleType = MultisportViewModel.AssemblyQualifiedName
            });


            Type ParkingViewModel = typeof(ParkingModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = ParkingViewModel.Name,
                ModuleType = ParkingViewModel.AssemblyQualifiedName
            });


            Type NavigationPanelViewModel = typeof(NavigationPanelModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = NavigationPanelViewModel.Name,
                ModuleType = NavigationPanelViewModel.AssemblyQualifiedName
            });


            Type EmployeeBannerViewModel = typeof(EmployeeBannerModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = EmployeeBannerViewModel.Name,
                ModuleType = EmployeeBannerViewModel.AssemblyQualifiedName
            });
            
             
        }
    }
}
