using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Commands;

using KeeperRichClient.Infrastructure;

namespace KeeperRichClient.Modules.Benefits
{
    public class NavigationPanelViewModel : INavigationViewModel
    {

        IRegionManager _RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

        public NavigationPanelViewModel()
        {
            this.NavigateToHealthcare = new DelegateCommand<object>(this._NavToHealthcare, this._CanNavigate);
            this.NavigateToMultiSport = new DelegateCommand<object>(this._NavToMultiSport, this._CanNavigate); ;
            this.NavigateToParking = new DelegateCommand<object>(this._NavToParking, this._CanNavigate);
        }

        public DelegateCommand<object> NavigateToHealthcare { get; private set; }
        public DelegateCommand<object> NavigateToMultiSport { get; private set; }
        public DelegateCommand<object> NavigateToParking { get; private set; }
        
        public void NavigateToTarget(string targetName, string region)
        {
            Uri target = FindNavigationTarget(targetName);
            _RegionManager.RequestNavigate(region, target);
        }
        public void DeactivateView(string region)
        {
            IRegion _region = _RegionManager.Regions[region];
            if (_region.ActiveViews.Count() > 0)
            {
                _region.Deactivate(_region.ActiveViews.FirstOrDefault());
            }
        }
        public Uri FindNavigationTarget(string targetName)
        {
            return new Uri(targetName, UriKind.Relative);
        }

        bool _CanNavigate(object arg)
        {
            return true;
            //ICurrentEmpolyee emp = ServiceLocator.Current.GetInstance<ICurrentEmpolyee>();
            //return emp.CanAccess((string)arg);
        }
        void _NavToHealthcare(object arg)
        {
            this.DeactivateView(RegionNames.MainContentRegion);
            this.NavigateToTarget("HealthcareView", RegionNames.MainContentRegion);
        }
        void _NavToMultiSport(object arg)
        {
            this.DeactivateView(RegionNames.MainContentRegion);
            this.NavigateToTarget("MultiSportView", RegionNames.MainContentRegion);
        }

        void _NavToParking(object arg)
        {
            this.DeactivateView(RegionNames.MainContentRegion);
            this.NavigateToTarget("ParkingView", RegionNames.MainContentRegion);
        }
    }
}
