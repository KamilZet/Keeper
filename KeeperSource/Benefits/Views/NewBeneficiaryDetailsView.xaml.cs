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
    public partial class NewBeneficiaryDetailsView : UserControl
    {
        public NewBeneficiaryDetailsView(INewBeneficiaryViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
