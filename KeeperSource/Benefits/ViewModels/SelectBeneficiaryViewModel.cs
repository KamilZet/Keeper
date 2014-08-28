
using System.Linq;
using System.Data.Linq;
using System.Collections.ObjectModel;

using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Benefits.Services;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{

    public class SelectBeneficiaryViewModel : ViewModelBase, ISelectBeneficiaryViewModel,IAddBeneficiary
    {
        public SelectBeneficiaryViewModel() 
        { 
         
        }

        Beneficiary beneficiary = null;
        public Beneficiary Beneficiary
        {
            get { return beneficiary; }
            set { beneficiary = value; }
        }

        public void AddBeneficiary()
        {
            using (DbContext db = new DbContext())
            {
                db.Beneficiaries.InsertOnSubmit(Beneficiary);
                db.SubmitChanges();
            }
        }

        public ObservableCollection<Beneficiary> Beneficiaries
        {
            get
            {
                using (DbContext db = new DbContext())
                {
                    var ret = from beneficiaries in db.Beneficiaries
                              where beneficiaries.BeneficiaryParentEmployeeId == CurrentEmployee.ActiveEmployee.EmployeeID
                              select beneficiaries;
                    return new ObservableCollection<Beneficiary>(ret);
                }
            }
        }


        public bool CanBeAdded()
        {
            return (Beneficiary != null);
        }
    }
}
