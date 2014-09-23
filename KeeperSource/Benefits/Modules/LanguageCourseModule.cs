using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Modularity;
using Ninject;
using Ninject.Modules;

using KeeperRichClient.Modules.Benefits.Views;
using KeeperRichClient.Modules.Benefits.Interfaces;
using KeeperRichClient.Modules.Benefits.ViewModels;

namespace KeeperRichClient.Modules.Benefits
{
    public class LanguageCourseModule : IModule
    {
        IKernel _ninkernel;
        IRegionManager _regmanager;

        public LanguageCourseModule(IKernel InKernel, IRegionManager InRegManager)
        {
            _ninkernel = InKernel;
            _regmanager = InRegManager;
        }

        public void Initialize()
        {
            _ninkernel.Bind<object>().To<LanguageCourseView>().Named("LanguageCourseView");
            _ninkernel.Bind<ILanguageCourseViewModel>().To<LanguageCourseViewModel>();

        }
    }
}
