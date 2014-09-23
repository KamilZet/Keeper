using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Models;
using System.Collections.ObjectModel;

namespace KeeperRichClient.Modules.Benefits
{
    public interface IHealthcareViewModel : IViewModel
    {
        ObservableCollection<MedicalPacketType> MedicalPacketTypes { get; }
    }
}
