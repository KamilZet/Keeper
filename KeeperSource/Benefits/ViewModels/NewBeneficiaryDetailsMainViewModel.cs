using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Views;
using KeeperRichClient.Modules.Benefits.Models;
using Ninject;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class NewBeneficiaryDetailsMainViewModel  : ViewModelBase
    {
        public NewBeneficiaryDetailsMainViewModel() {
            ServLocator.Bind<INewBeneficiaryViewModel>().To<NewBeneficiaryDetailsViewModel>().InSingletonScope();
            ServLocator.Bind<ISelectBeneficiaryViewModel>().To<SelectBeneficiaryViewModel>().InSingletonScope();}

        IKernel ServLocator = new StandardKernel();

        IView content;
        public IView Content
        {
            get { return content; }
            set {if (content != value){
                    content = value;
                    RaisePropertyChanged("Content");}}}

        public ICommand ChangeContentCommand{
            get{
                return new RelayCommand(param =>{
                    if (Content != null){
                        if (Content is NewBeneficiaryDetailsView)
                        { Content = ServLocator.Get<SelectBeneficiaryView>(); }
                        else
                        { Content = ServLocator.Get<NewBeneficiaryDetailsView>(); }}
                    else
                        { Content = ServLocator.Get<SelectBeneficiaryView>(); }
                });}}

        ICommand addBeneficiaryCommand;
        void addBeneficiary() 
        {
            (Content.ViewModel as IAddBeneficiary).AddBeneficiary();
        }
        
        public ICommand AddBeneficiaryCommand
        {
            get
            {
                if (addBeneficiaryCommand == null) addBeneficiaryCommand = new RelayCommand(param => this.addBeneficiary(), null);
                return addBeneficiaryCommand;
            }
        }

        }
        
        
    
    
    }

