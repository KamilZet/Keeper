
using KeeperRichClient.Modules.Employees;
using KeeperRichClient.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;


namespace KeeperRichClient.Modules.Benefits.Services
{
    public static class CurrentEmployee
    {
        static CurrentEmployee()
        {   
            eventAggr = ApplicationService.Instance.EventAggregator;
            eventAggr.GetEvent<EmployeeSelectedEvent>().Subscribe(activeEmployeeChanged, true);
        }

        static IEventAggregator eventAggr = null;
        
        static GetEmployeesResult activeEmployee = null;
        public static GetEmployeesResult ActiveEmployee { get { return activeEmployee; } set { activeEmployee = value; } }

        static void activeEmployeeChanged(GetEmployeesResult employee)
        {
            ActiveEmployee = employee;
        }

    }
}