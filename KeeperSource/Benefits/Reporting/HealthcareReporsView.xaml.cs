using System.Windows.Controls;

namespace KeeperRichClient.Modules.Benefits.Reporting
{
    /// <summary>
    /// Interaction logic for HealthcareReporsView.xaml
    /// </summary>
    public partial class HealthcareReporsView : UserControl
    {
        public HealthcareReporsView()
        {
            InitializeComponent();
            this.DataContext = new HealthcareReportsViewModel();
        }
    }
}
