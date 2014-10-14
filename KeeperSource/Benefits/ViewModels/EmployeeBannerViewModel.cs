
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Microsoft.Practices.Prism.PubSubEvents;
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees.Models;
using KeeperRichClient.Modules.Employees.Services;

namespace KeeperRichClient.Modules.Benefits
{
    public class EmployeeBannerViewModel : IEmployeeBannerViewModel,INotifyPropertyChanged
    {
        public EmployeeBannerViewModel()
        {
            EmpFirstName = "Jan"; EmpLastName = "Kowalski"; EmpCoopType = "Kontrakt"; EmpPosition = "Junior Specialist";

            eventAggr = ApplicationService.Instance.EventAggregator;
            eventAggr.GetEvent<EmployeeSelectedEvent>().Subscribe(EmployeeSelected, true);
        }

        string empFirstName;
        public string EmpFirstName
        {
            get { return empFirstName; }
            private set
            {
                empFirstName = value; RaisePropertyChanged("EmpFirstName");
            }
        }
        string empLastName;
        public string EmpLastName 
        {
            get { return empLastName; }
            private set
            {
                empLastName = value; RaisePropertyChanged("EmpLastName");
            } 
        }
        string empCoopType;
        public string EmpCoopType
        {
            get { return empCoopType; }
            private set
            {
                empCoopType = value; RaisePropertyChanged("EmpCoopType");
            }
        }
        string empPosition;
        public string EmpPosition 
        { 
            get {return empPosition;} 
            private set
            {
                empPosition = value; RaisePropertyChanged("EmpPosition");
            }
        }
        readonly IEventAggregator eventAggr;
        readonly EmployeeLINQClassDataContext empDc;

        void EmployeeSelected(GetEmployeesResult Employee)
        {

            EmpFirstName = Employee.EmpFName;
            EmpLastName = Employee.EmpLName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }
    }


}


