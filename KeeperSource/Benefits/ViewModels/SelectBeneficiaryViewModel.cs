
using System.Linq;
using System.Collections.ObjectModel;

using KeeperRichClient.Infrastructure ;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Employees.Services;

using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Forms;
using KeeperRichClient.Modules.Benefits.Services;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    
    public class SelectBeneficiaryViewModel : BindableBase, ISelectBeneficiaryViewModel, IAddBeneficiary
    {
        IView mainContentView = (IView)ServiceLocator.Current.GetInstance<IRegionManager>().Regions["MainContentRegion"].ActiveViews.FirstOrDefault();    
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
            using (DbContext db = new DbContext(ServerChanger.ConnStr))
            {
                int ExecRet;
                ExecRet = db.spAddBeneficiaryToMedicalPacket(SelectedBeneficiary.BeneficiaryID,
                                                   (mainContentView.DataContext as HealthcareViewModel).SelectedMedicalPacket.ConfiguredMedicalPacketID
                                                   );
                if (ExecRet != 0)
                {
                    MessageBox.Show("Some error occured.");
                }
                else
                {
                    MessageBox.Show("Beneficiary was assigned to the selected healthcare packet.");
                    SelectedBeneficiary = new Beneficiary();
                }
                //reload listview of beneficiaries
                //(activeView as HealthcareView).BeneficiariesLinkedToMedPack;
            }
        }

        public ObservableCollection<Beneficiary> Beneficiaries
        {
            get
            {
                using (DbContext db = new DbContext(ServerChanger.ConnStr))
                {
                    return (db.Beneficiaries.OrderBy(x => x.BeneficiaryLName)).ToObservableCollection();
                }
            }
        }


        public bool CanBeAdded()
        {
            return (this.SelectedBeneficiary != null);
        }
    }
}
