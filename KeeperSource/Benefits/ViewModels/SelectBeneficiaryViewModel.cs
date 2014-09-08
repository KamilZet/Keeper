
using System.Linq;
using System.Collections.ObjectModel;

using KeeperRichClient.Infrastructure ;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Benefits.Services;
using KeeperRichClient.Modules.Employees.Services;

using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    
    public class SelectBeneficiaryViewModel : BindableBase, ISelectBeneficiaryViewModel, IAddBeneficiary
    {
        KeeperRichClient.Infrastructure.IView activeView = (KeeperRichClient.Infrastructure.IView)ServiceLocator.Current.GetInstance<IRegionManager>().Regions["MainContentRegion"].ActiveViews.FirstOrDefault();    
        public SelectBeneficiaryViewModel() 
        {
            
        }

        Beneficiary selectedBeneficiary = null;
        public Beneficiary SelectedBeneficiary
        {
            get { return this.selectedBeneficiary; }
            set { SetProperty(ref this.selectedBeneficiary, value); } // bindable base
        }

        public void AddBeneficiary()
        {
            using (DbContext db = new DbContext())
            {
                //db.spAddBeneficiaryToMedicalPacket(SelectedBeneficiary.BeneficiaryID,
                //                                   (activeView.DataContext as HealthcareViewModel).SelectedMedicalPacket.ConfiguredMedicalPacketID
                //                                   );
                SelectedBeneficiary = new Beneficiary();

            }
        }

        public ObservableCollection<Beneficiary> Beneficiaries
        {
            get
            {
                using (DbContext db = new DbContext())
                {
                    var result = from beneficiaries in db.Beneficiaries
                                 where beneficiaries.BeneficiaryParentEmployeeId == ActiveEmployee.Employee.EmployeeID
                                 select beneficiaries;
                    return new ObservableCollection<Beneficiary>(result);
                }
            }
        }


        public bool CanBeAdded()
        {
            return (this.SelectedBeneficiary != null);
        }
    }
}
