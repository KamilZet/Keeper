using System.Windows.Controls;
using KeeperRichClient.Modules.Benefits.ViewModels;

namespace KeeperRichClient.Modules.Benefits.Views
{
    /// <summary>
    /// Interaction logic for ReportingControl.xaml
    /// </summary>
    public partial class ReportingControlView : UserControl
    {
        public ReportingControlView()
        {
            InitializeComponent();
            this.DataContext = new ReportingViewModel();
        }
    }
}
