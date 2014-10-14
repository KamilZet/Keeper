using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Ninject;
using KeeperRichClient.Modules.Benefits.Reporting;

namespace KeeperRichClient.Modules.Benefits.Reporting
{
    public class HealthcareReportsModule : IModule
    {
        public HealthcareReportsModule(IKernel InKernel, IRegionManager InRegManager)
        {
            kernel = InKernel;
            regmanager = InRegManager;
        }

        public void Initialize()
        {
            kernel.Bind<object>().To<HealthcareReporsView>().Named("HealthcareReporsView");
            kernel.Bind<IHealthcareReportsViewModel>().To<HealthcareReportsViewModel>();

        }

        private IKernel kernel;
        private IRegionManager regmanager;


    }
}
