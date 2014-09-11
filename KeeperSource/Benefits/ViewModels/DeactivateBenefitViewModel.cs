
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Models;

namespace KeeperRichClient.Modules.Benefits
{
    public class DeactivateBenefitViewModel : INotifyPropertyChanged
    {
        private IViewModel _ViewModel;
        public DeactivateBenefitViewModel(IViewModel ArgViewModel)     
        {
            _ViewModel = ArgViewModel;
        }


        public ObservableCollection<TakingReasonType> TakingReasonTypeList
        {
            get
            {
                using (DbContext dc = new DbContext())
                {
                    return new ObservableCollection<TakingReasonType>(dc.TakingReasonTypes);
                }
                   
            }
        }

        public TakingReasonType SelectedTakeType
        {
            get;
            set;
        }

        private DateTime _EndDate = HelperFuncs.ThisMonthEnd(DateTime.Now);
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }


        private string _TakingNote;
        public string TakingNote
        {
            get { return _TakingNote; }
            set { _TakingNote = value; }
        }

        private ICommand _CallDeactivateBenefit;
        public ICommand CallDeactivateBenefit
        {
            get
            {
                if (_CallDeactivateBenefit == null) _CallDeactivateBenefit = new RelayCommand(param => this._DeactivateBenefit(), null);
                return _CallDeactivateBenefit;
            }
        }

        private void _DeactivateBenefit()
        {
            using (DbContext dc = new DbContext())
            {
                if (_ViewModel.GetType() == typeof(HealthcareViewModel))
                    dc.spRemoveMedicalPacketFromEmployee(((HealthcareViewModel)_ViewModel).SelectedMedicalPacket.ConfiguredMedicalPacketID,
                                                    this.EndDate,
                                                    this.SelectedTakeType.TakingReasonID,
                                                    this.TakingNote);
                else if (_ViewModel.GetType() == typeof(MultiSportViewModel))
                    dc.spTakeConfiguredMultiSportCard(((MultiSportViewModel)_ViewModel).SelectedMultiSportOwner.ConfiguredBenefitPacketID);

                RequestClose(null, EventArgs.Empty);
            }
        }


        public event EventHandler RequestClose;
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}

