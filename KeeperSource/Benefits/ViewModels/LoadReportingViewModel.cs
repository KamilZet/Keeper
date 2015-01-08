using System.Windows.Input;
using System.Linq;
using KeeperRichClient.Modules.Benefits.Services;
using KeeperRichClient.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows;


namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class LoadReportingViewModel
    {
        public ICommand ShowHealthcareReportsCommand
        {
            get { return new RelayCommand(action => this.showHealthcareReportsCommand()); }
        }

        public ICommand ShowMultisportReportsCommand
        {
            get { return new RelayCommand(action => this.unImplAction()); }
        }

        public ICommand ShowLanguageReportsCommand
        {
            get { return new RelayCommand(action => this.unImplAction()); }
        }

        public ICommand ShowParkingReportsCommand
        {
            get { return new RelayCommand(action => this.unImplAction()); }
        }



        private void showHealthcareReportsCommand() 
        {
            IRegion region = ServiceLocator.Current.GetInstance<IRegionManager>().Regions[RegionNames.MainContentRegion];
            region.Deactivate(region.ActiveViews.FirstOrDefault());
            Uri source = new Uri("HealthcareReporsView", UriKind.Relative);
            ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainContentRegion, source);
        }

        private void unImplAction()
        {
            MessageBox.Show("To be implemented!", "", MessageBoxButton.OK);
        }

        //private void DeactivateView(string region)
        //{
        //    IRegion _region = _RegionManager.Regions[region];
        //    if (_region.ActiveViews.Count() > 0)
        //    {
        //        _region.Deactivate(_region.ActiveViews.FirstOrDefault());
        //    }
        //}


    }
}
