using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using KeeperRichClient.Modules.Benefits;
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees;
using KeeperRichClient.Modules.Benefits.Reporting;

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

        }
        protected override void ConfigureModuleCatalog()
        {
            Type EmployeeModule = typeof(EmployeeModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = EmployeeModule.Name,
                ModuleType = EmployeeModule.AssemblyQualifiedName
            });

            
            Type HealthcareModule = typeof(HealthcareModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
                {
                    ModuleName = HealthcareModule.Name,
                    ModuleType = HealthcareModule.AssemblyQualifiedName
                });


            Type MultisportModule = typeof(MultiSportModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = MultisportModule.Name,
                ModuleType = MultisportModule.AssemblyQualifiedName
            });


            Type ParkingModule = typeof(ParkingModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = ParkingModule.Name,
                ModuleType = ParkingModule.AssemblyQualifiedName
            });


            Type NavigationPanelModule = typeof(NavigationPanelModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = NavigationPanelModule.Name,
                ModuleType = NavigationPanelModule.AssemblyQualifiedName
            });


            Type EmployeeBannerModule = typeof(EmployeeBannerModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = EmployeeBannerModule.Name,
                ModuleType = EmployeeBannerModule.AssemblyQualifiedName
            });

            Type LanguageCourseModule = typeof(LanguageCourseModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = LanguageCourseModule.Name,
                ModuleType = LanguageCourseModule.AssemblyQualifiedName
            });

            Type HealthcareReportsModule = typeof(HealthcareReportsModule);
            this.ModuleCatalog.AddModule(new ModuleInfo(){ModuleName = HealthcareReportsModule.Name,ModuleType = HealthcareReportsModule.AssemblyQualifiedName});
        }
    }
}
