
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Employees.Models;
using KeeperRichClient.Modules.Employees.Services;

using Microsoft.Practices.Prism.PubSubEvents;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

using System.Linq;
using KeeperRichClient.Modules.Benefits.Services;

//Concerns:

//How to show record with info about employee multisport card? Normally there are owners selected from beneficiaries, but employee is selected from
//different table

namespace KeeperRichClient.Modules.Benefits
{
    public class MultiSportViewModel : IMultiSportViewModel, INotifyPropertyChanged
    {

        #region Construction
        public MultiSportViewModel()
        {
            
            ApplicationService.Instance.EventAggregator.GetEvent<EmployeeSelectedEvent>().Subscribe(this.employeeSelected, true);
            NewMultiSportPacket = new ConfMultisportPackToEmp();
            ValidFrom = HelperFuncs.NextMonthStart();
            IsPaidByEmployee = true;
        }
        #endregion
        
        public ConfMultisportPackToEmp NewMultiSportPacket
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


        public fBeneficiariesToEmployeeResult MultisportOwner
        {
            get {return _MultisportOwner;}
            set {_MultisportOwner = value;}
        }

        public fGetMultisUsersToEmployeeResult SelectedMultiSportOwner
        {
            get { return _SelectedMultiSportOwner; }
            set { _SelectedMultiSportOwner = value; }
        }


        public ObservableCollection<fGetMultisUsersToEmployeeResult> MultiSportOwnerToEmployee
        {
            get 
            {
            if (selectedEmployee != null)
                return new ObservableCollection<fGetMultisUsersToEmployeeResult>(dataContext.fGetMultisUsersToEmployee(selectedEmployee.EmpId));
            else
                return null;
            }
        }

        public ObservableCollection<MultisportPackType> MultiSportPacketTypes
        {
            get
            {
                return (dataContext.MultisportPackTypes.Where(x => x.IsActive == true)).ToObservableCollection();
            }
        }
        
        public ObservableCollection<Beneficiary> Beneficiaries
        {
            get 
            {
                return (dataContext.Beneficiaries.OrderBy(x => x.BeneficiaryLName)).ToObservableCollection();
            }
        }

        public ICommand CallSaveNewMultiSportPacket
        {
            get
            {
                if (_CallSaveNewMultiSportPacket == null)
                {   //my first usefull delegate application..(+ its applied through lambda expression, which produces +100 to c# coding skills :)
                    _CallSaveNewMultiSportPacket = new RelayCommand(action => this.saveNewMultiSportPacket(), predicate => NewMultiSportPacket.MultiSportPacketTypeID != 0 &&
                                                                                                                           NewMultiSportPacket.ValidFrom != null);
                }
                return _CallSaveNewMultiSportPacket;
            }
        }
        
        public ICommand CallDeactivateMultiSportPacket
        {
            get
            {
                if (callDeactivateMultiSportPacket==null)
                {
                    callDeactivateMultiSportPacket = new RelayCommand(action => this.deactivateMultiSportPacket(), predicate => SelectedMultiSportOwner != null);//
                }
                return callDeactivateMultiSportPacket;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void deactivateMultiSportPacket()
        {
            try
            {
                // reuse DeactivateBenefit{ View | ViewModel }

                DeactivateBenefitView deactivateView = new DeactivateBenefitView(this);
                deactivateView.ShowDialog();

                //method raised also when user cancel operation - implement handling for this case
                RaisePropertyChanged("MedicalPacketsLinkedToEmployee");


                //previous code
                dataContext.spTakeConfiguredMultiSportCard(configuredMultiSportCardId: SelectedMultiSportOwner.ConfiguredBenefitPacketID);
                RaisePropertyChanged("MultiSportOwnerToEmployee");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void employeeSelected(GetEmployeesResult Employee)
        {
            selectedEmployee = Employee;
            RaisePropertyChanged("MultiSportOwnerToEmployee");
            RaisePropertyChanged("BeneficiariesToEmployee");
        }


        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }

        private ICommand callDeactivateMultiSportPacket;

        private DbContext dataContext = new DbContext(ServerChanger.ConnStr);
        private GetEmployeesResult selectedEmployee;

        private ConfMultisportPackToEmp _NewMultiSportPacket;
        private fBeneficiariesToEmployeeResult _MultisportOwner;
        private fGetMultisUsersToEmployeeResult _SelectedMultiSportOwner;
        private ICommand _CallSaveNewMultiSportPacket;
        private void saveNewMultiSportPacket()
        {
            try
            {
                dataContext.spAddConfigutedMultiSportCard(cardTypeId: MultiSportPacketTypeId,
                                                                employeeId: selectedEmployee.EmpId,
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


    }
}
