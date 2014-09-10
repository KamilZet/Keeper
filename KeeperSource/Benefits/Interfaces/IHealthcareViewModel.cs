using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KeeperRichClient.Infrastructure;

namespace KeeperRichClient.Modules.Benefits
{
    public interface IHealthcareViewModel : IViewModel
    {
        ObservableCollection<MedicalPacketType> MedicalPacketTypes { get; }
    }
}
