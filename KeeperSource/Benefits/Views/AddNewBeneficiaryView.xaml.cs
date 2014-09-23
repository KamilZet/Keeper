using System;
using System.Windows;

using KeeperRichClient.Modules.Benefits.Models;



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
