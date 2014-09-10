using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using KeeperRichClient.Infrastructure;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.PubSubEvents;
using KeeperRichClient.Modules.Employees.Services;

namespace KeeperRichClient.Modules.Employees
{
    public class EmployeeViewModel : INotifyPropertyChanged,IEmployeeViewModel
    {
        private IEventAggregator _eventAggr;
        
        private EmployeeDataModelContext _empDC;
        private GetEmployeesResult _emp;

        private ObservableCollection<GetEmployeesResult> _EmployeeList;
        public ObservableCollection<GetEmployeesResult> EmployeeList
        {
            get {return _EmployeeList;}
        }

        public EmployeeViewModel()
        {
            _empDC = new EmployeeDataModelContext();
            _EmployeeList = (from emps in _empDC.GetEmployees() where emps.LevelID != null select emps).ToObservableCollection();
            this._eventAggr = ApplicationService.Instance.EventAggregator;
        }

        public GetEmployeesResult SelectedEmployee
        {
            get { return _emp; }
            set
            {
                _emp = value;
                SelectedEmployeeChanged();
            }
        }

        public ObservableCollection<GetEmployeesResult> Employee
        {
            get { return _EmployeeList; }
        }

        private void SelectedEmployeeChanged()
        {
            GetEmployeesResult employee = this.SelectedEmployee as GetEmployeesResult;
            if (employee != null)
            {
                ActiveEmployee.Employee = employee;
                this._eventAggr.GetEvent<EmployeeSelectedEvent>().Publish(employee); 
            }

        }
        
        public void EmployeeRefresh()
        {
            _EmployeeList.Clear();
            _EmployeeList = (from emps in _empDC.GetEmployees() where emps.LevelID != null select emps).ToObservableCollection();
            RaisePropertyChanged("Employee");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }



    }
}
