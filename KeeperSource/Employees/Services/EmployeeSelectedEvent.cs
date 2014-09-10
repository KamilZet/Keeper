using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using KeeperRichClient.Modules.Employees.Models;

namespace KeeperRichClient.Modules.Employees.Services
{
    public class EmployeeSelectedEvent : PubSubEvent<GetEmployeesResult>
    {
          
    }
}
