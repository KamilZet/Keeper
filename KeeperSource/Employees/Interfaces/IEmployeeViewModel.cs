
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees.Models;
using System.Collections.ObjectModel;

namespace KeeperRichClient.Modules.Employees
{
    public interface IEmployeeViewModel : IViewModel
    {
        ObservableCollection<GetEmployeesResult> Employees { get; }
    }
}
