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
    /// Interaction logic for MultiSportView.xaml
    /// </summary>
    public partial class MultiSportView : UserControl
    {
        public MultiSportView()
        {
            InitializeComponent();
            DataContext = new MultiSportViewModel();
        }


        
    }
}
