using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Views;
using Ninject;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class NewBeneficiaryDetailsMainViewModel  : ViewModelBase
    {
        public NewBeneficiaryDetailsMainViewModel() {
            ServLocator.Bind<INewBeneficiaryViewModel>().To<NewBeneficiaryDetailsViewModel>().InSingletonScope();
            ServLocator.Bind<ISelectBeneficiaryViewModel>().To<SelectBeneficiaryViewModel>().InSingletonScope();
        }

        IKernel ServLocator = new StandardKernel();

        object content;
        public object Content{
            get { return content; }
            set {if (content != value){
                    content = value;
                    RaisePropertyChanged("Content");}}}

        public ICommand ChangeContentCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    if (Content != null)
                    {
                        if (Content is NewBeneficiaryDetailsViewModel)
                        { Content = ServLocator.Get<SelectBeneficiaryViewModel>(); }
                        else
                        { Content = ServLocator.Get<NewBeneficiaryDetailsViewModel>(); }
                    }
                    else
                    { Content = ServLocator.Get<SelectBeneficiaryView>(); }
                });
            }
        }
    
    
    
    
    }
}
