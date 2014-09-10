//todo:
//row numbers for each data listview

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.ComponentModel;

using Microsoft.Practices.Prism.Mvvm;

namespace KeeperRichClient.Modules.Employees
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl,IView
    {

        public IViewModel ViewModel
        {
            get
            {
                return (IViewModel)DataContext;
            }
            set
            {
                DataContext = (IViewModel)value;
            }
        }

        public ICollectionView Employees { get; private set; }

        public EmployeeView(IEmployeeViewModel InVm)
        {
            ViewModel = InVm;
            InitializeComponent();
            //var emp = ((IEmployeeViewModel)ViewModel).GetEmployee.ToList();
            //Employees = new ListCollectionView((List<GetEmployeesResult>)emp);
            //this.EmployeeDataGrid.ItemsSource = this.Employees;
        }

        

        private void EmployeeDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
