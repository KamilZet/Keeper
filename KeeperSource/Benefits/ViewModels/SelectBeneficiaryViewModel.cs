
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Models;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public interface ISelectBeneficiaryViewModel : IViewModel { }

    public class SelectBeneficiaryViewModel : ViewModelBase, ISelectBeneficiaryViewModel,IAddBeneficiary
    {
        public SelectBeneficiaryViewModel() { beneficiary = new Beneficiary(); }

        Beneficiary beneficiary;
        public Beneficiary Beneficiary{
            get { return beneficiary; }
            set { beneficiary = value; }}


        public void AddBeneficiary() { System.Windows.MessageBox.Show("Selected saved!"); }
    }
}
