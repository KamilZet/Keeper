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

using KeeperRichClient.Modules.Benefits.ViewModels;

namespace KeeperRichClient.Modules.Benefits.Views
{
    /// <summary>
    /// Interaction logic for NewBeneficiaryDetailsMainView.xaml
    /// </summary>
    public partial class NewBeneficiaryDetailsMainView : Window
    {
        public NewBeneficiaryDetailsMainView()
        {
            InitializeComponent();
            NewBeneficiaryDetailsMainViewModel vm = new NewBeneficiaryDetailsMainViewModel();
            this.DataContext = vm;
            vm.CancelCommand = new RelayCommand(action => this.Close());
        }

        
        
    }
}
