using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using KeeperRichClient.Infrastructure;

namespace KeeperRichClient.Modules.Benefits
{
    /// <summary>
    /// Interaction logic for AddNewBeneficiaryControl.xaml
    /// </summary>
    public partial class AddNewBeneficiaryView : Window,IDisposable
    {

        private AddNewBeneficiaryViewModel addNewBeneficiaryViewModel;
        public AddNewBeneficiaryView(HealthcareViewModel InVm)
        {
            InitializeComponent();
            addNewBeneficiaryViewModel = new AddNewBeneficiaryViewModel(InVm, ParentWindow);
            DataContext = addNewBeneficiaryViewModel;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        
        private Window ParentWindow
        {
            get { return this; }
        }



        public fBeneficiariesToEmployeeResult Beneficiary { get { return addNewBeneficiaryViewModel.Beneficiary; } }

        public void Dispose() 
        {
            addNewBeneficiaryViewModel = null;    
        }

    }


}
