using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KeeperRichClient.Infrastructure;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public interface ISelectBeneficiaryViewModel { }

    public class SelectBeneficiaryViewModel : ViewModelBase, ISelectBeneficiaryViewModel
    {
        public SelectBeneficiaryViewModel() { beneficiary = new Beneficiary(); }

        Beneficiary beneficiary;
        public Beneficiary Beneficiary{
            get { return beneficiary; }
            set { beneficiary = value; }}



    }
}
