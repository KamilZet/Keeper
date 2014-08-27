
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Practices.Prism.PubSubEvents;
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees;

using System.Windows.Forms;

//Concerns:

//How to show record with info about employee multisport card? Normally there are owners selected from beneficiaries, but employee is selected from
//different table

namespace KeeperRichClient.Modules.Benefits
{
    public class MultiSportViewModel : IMultiSportViewModel, INotifyPropertyChanged
    {
        DbContext _DbContext = new DbContext();
        IEventAggregator _EventAggregator;
        int _SelectedEmployeeId;


        public MultiSportViewModel()
        {
            _EventAggregator = ApplicationService.Instance.EventAggregator;
            _EventAggregator.GetEvent<EmployeeSelectedEvent>().Subscribe(this._EmployeeSelected, true);
            //placeholder for configuring new multisport packets. 
            NewMultiSportPacket = new ConfiguredMultisportPacketsToEmployee();
            ValidFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
            IsPaidByEmployee = true;
        }

        void _EmployeeSelected(GetEmployeesResult Employee)
        {
            _SelectedEmployeeId = Employee.EmployeeID;
            RaisePropertyChanged("MultiSportOwnerToEmployee");
            RaisePropertyChanged("BeneficiariesToEmployee");

        }

        private ConfiguredMultisportPacketsToEmployee _NewMultiSportPacket;
        public ConfiguredMultisportPacketsToEmployee NewMultiSportPacket
        {
            get { return _NewMultiSportPacket; }
            set { _NewMultiSportPacket = value; }
        }

        public int MultiSportPacketTypeId
        {
            get { return _NewMultiSportPacket.MultiSportPacketTypeID;}
            set { _NewMultiSportPacket.MultiSportPacketTypeID = value; }
        }

        public DateTime ValidFrom
        {
            get { return _NewMultiSportPacket.ValidFrom; }
            set { _NewMultiSportPacket.ValidFrom = value; }
        }

        public DateTime? ValidTo
        {
            get { return _NewMultiSportPacket.ValidTo; }
            set { _NewMultiSportPacket.ValidTo = value; }
        }

        public bool IsPaidByEmployee
        {
            get { return _NewMultiSportPacket.IsPayedByEmployee; }
            set { _NewMultiSportPacket.IsPayedByEmployee = value; }
        }

        public bool IsIncludedInEmployeeLimit
        {
            get { return _NewMultiSportPacket.IsPayedByEmployee; }
            set { _NewMultiSportPacket.IsPayedByEmployee = value; }
        }

        private fBeneficiariesToEmployeeResult _MultisportOwner;
        public fBeneficiariesToEmployeeResult MultisportOwner
        {
            get {return _MultisportOwner;}
            set {_MultisportOwner = value;}
        }



        private fMultisportOwnerToEmployeeResult _SelectedMultiSportOwner;
        public fMultisportOwnerToEmployeeResult SelectedMultiSportOwner
        {
            get { return _SelectedMultiSportOwner; }
            set { _SelectedMultiSportOwner = value; }
        }

        public ObservableCollection<fMultisportOwnerToEmployeeResult> MultiSportOwnerToEmployee
        {
            get { return new ObservableCollection<fMultisportOwnerToEmployeeResult>(_DbContext.fMultisportOwnerToEmployee(_SelectedEmployeeId)); }
        }


        public ObservableCollection<fMultisportCardTypesResult> MultiSportCardType
        {
            get { return new ObservableCollection<fMultisportCardTypesResult>(_DbContext.fMultisportCardTypes()); }
        }
        
        public ObservableCollection<fBeneficiariesToEmployeeResult> BeneficiariesToEmployee
        {
            get { return new ObservableCollection<fBeneficiariesToEmployeeResult>(_DbContext.fBeneficiariesToEmployee(_SelectedEmployeeId)); }
        }

        private bool IsMultiSportPacketConfigured()
        {
            return (NewMultiSportPacket.MultiSportPacketTypeID != 0 &&
                    NewMultiSportPacket.ValidFrom != null);
        }

        private ICommand _CallSaveNewMultiSportPacket;
        public ICommand CallSaveNewMultiSportPacket
        {
            get
            {
                if (_CallSaveNewMultiSportPacket == null)
                {   //my first usefull delegate application..(+ its applied through lambda expression, which produces +100 to c# coding skills :)
                    _CallSaveNewMultiSportPacket = new RelayCommand(action => this.SaveNewMultiSportPacket(), predicate => this.IsMultiSportPacketConfigured());
                }
                return _CallSaveNewMultiSportPacket;
            }
        }

        private void SaveNewMultiSportPacket()
        {
            try
            {
                _DbContext.spAddConfigutedMultiSportCard(cardTypeId: MultiSportPacketTypeId,
                                                                employeeId: _SelectedEmployeeId,
                                                                beneficiaryId: (MultisportOwner == null) ? (int?)null : MultisportOwner.BeneficiaryID,
                                                                validFrom: ValidFrom,
                                                                validTo: ValidTo,
                                                                isIncludedInLimit: IsIncludedInEmployeeLimit,
                                                                isPayedByEmployee: IsPaidByEmployee
                                                                );

                RaisePropertyChanged("MultiSportOwnerToEmployee");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private ICommand _CallDeactivateMultiSportPacket;
        public ICommand CallDeactivateMultiSportPacket
        {
            get
            {
                if (_CallDeactivateMultiSportPacket==null)
                {
                    _CallDeactivateMultiSportPacket = new RelayCommand(action => this.DeactivateMultiSportPacket(),predicate => this.IsDeactivateCallable());//
                }
                return _CallDeactivateMultiSportPacket;
            }

        }

        private void DeactivateMultiSportPacket()
        {
            try
            {
                _DbContext.spTakeConfiguredMultiSportCard(configuredMultiSportCardId: SelectedMultiSportOwner.ConfiguredBenefitPacketID);
                RaisePropertyChanged("MultiSportOwnerToEmployee");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        bool IsDeactivateCallable()
        {
            return (SelectedMultiSportOwner != null);
        }

        void _ClearNewSaveData()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }


    }
}
