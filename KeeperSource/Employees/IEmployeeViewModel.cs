using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeeperRichClient.Infrastructure;
using System.Collections.ObjectModel;

namespace KeeperRichClient.Modules.Employees
{
    public interface IEmployeeViewModel : IViewModel
    {
        ObservableCollection<GetEmployeesResult> EmployeeList { get; }
       
    }
}
