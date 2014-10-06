
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees.Models;
using KeeperRichClient.Modules.Employees.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace KeeperRichClient.Modules.Employees
{
    public class EmployeeViewModel : INotifyPropertyChanged,IEmployeeViewModel
    {
        
        #region Construction
        public EmployeeViewModel()
        {
            dataContext = new EmployeeLINQClassDataContext();
            employees = (from emps in dataContext.GetEmployees() select emps).ToObservableCollection();
            this.eventAggr = ApplicationService.Instance.EventAggregator;
        }
        #endregion

        #region Interface
        public event PropertyChangedEventHandler PropertyChanged;

        public void EmployeeRefresh()
        {
            employees.Clear();
            employees = (from emps in dataContext.GetEmployees() select emps).ToObservableCollection();
            RaisePropertyChanged("Employee");
        }

        public ObservableCollection<GetEmployeesResult> Employees
        {
            get { return employees; }
        }

        public GetEmployeesResult SelectedEmployee
        {
            get { return employee; }
            set
            {
                employee = value;
                selectedEmployeeChanged();
            }
        }

        public ObservableCollection<GetEmployeesResult> Employee
        {
            get { return employees; }
        }
        #endregion

        private IEventAggregator eventAggr;

        private EmployeeLINQClassDataContext dataContext;

        private GetEmployeesResult employee;

        private ObservableCollection<GetEmployeesResult> employees;

        private void selectedEmployeeChanged()
        {
            GetEmployeesResult employee = this.SelectedEmployee as GetEmployeesResult;
            if (employee != null)
            {
                ActiveEmployee.Employee = employee;
                this.eventAggr.GetEvent<EmployeeSelectedEvent>().Publish(employee); 
            }

        }

        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }



    }
}
