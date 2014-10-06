using System.Windows.Input;
using KeeperRichClient.Modules.Benefits.Services;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class ReportingViewModel
    {
        public ICommand ShowHealthcareReportsCommand
        {
            get { return new RelayCommand(action => this.showHealthcareReportsCommand()); }
        }





        private void showHealthcareReportsCommand() 
        {
                
        }


    }
}
