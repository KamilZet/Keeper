using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Employees;

using Microsoft.Practices.Prism.PubSubEvents;
using System.Reflection;
using System.Windows;


namespace KeeperRichClient.Modules.Benefits
{
    public class HealthcareViewModel : INotifyPropertyChanged, IHealthcareViewModel
    {
        DbContext _DbContext;
        ObservableCollection<MedicalPacketType> _medPackTypesColl;
        //todo odswiezanie listy po dodaniu, odjęciu beneficjenta
        ObservableCollection<Beneficiary> _benefLinkToMedPackColl;
        public HealthcareViewModel()//IEventAggregator eventAgr
        {
            _DbContext = new DbContext();
            _medPackTypesColl = (from packs in _DbContext.MedicalPacketTypes select packs).ToObservableCollection();//MedPackTypes.ToObservableCollection();
            //_eventAggr = eventAgr;
            _eventAggr = ApplicationService.Instance.EventAggregator;
            this._eventAggr.GetEvent<EmployeeSelectedEvent>().Subscribe(this.EmployeeSelected, true);
            NewMedPackPayByEmp = true;   
        }

        public ObservableCollection<vBeneficiaries2MedPackResult> BeneficiariesLinkedToMedPack
        {
            get
            {
                if (SelectedMedicalPacket != null) 
                    return new ObservableCollection<vBeneficiaries2MedPackResult>(_DbContext.vBeneficiaries2MedPack(SelectedMedicalPacket.ConfiguredMedicalPacketID));
                else 
                {
                    return null;
                }
            }
            set
            {
                BeneficiariesLinkedToMedPack = value; 
                RaisePropertyChanged("BeneficiariesLinkedToMedPack");
            }
        }


        // set selected item from the list
        private vMedicalPacketsToEmployeeResult _selectedMedicalPacket;
        public vMedicalPacketsToEmployeeResult SelectedMedicalPacket
        {
            get 
            { 
                return _selectedMedicalPacket; 
            }
            set 
            {
                _selectedMedicalPacket = value;
                RaisePropertyChanged("BeneficiariesLinkedToMedPack"); 
            }
        }

        // return results of svr function: all medical packets assigned to selected employee
        public ObservableCollection<vMedicalPacketsToEmployeeResult> MedicalPacketsLinkedToEmployee
        {
            get
            {
                return new ObservableCollection<vMedicalPacketsToEmployeeResult>(_DbContext.vMedicalPacketsToEmployee(_selectedEmpId));
            }
            set
            {
                MedicalPacketsLinkedToEmployee = value;
                RaisePropertyChanged("BeneficiariesLinkedToMedPack");
            }
        }


        private MedicalPacketType _selMedPackType;

        private readonly IEventAggregator _eventAggr;
        private int _selectedEmpId;
        private int _selectedMedPackId;



        public int SelectedEmployeeId { get { return _selectedEmpId; } }
        public int SelectedMedPackId { get { return _selectedMedPackId; } }
        

        public vBeneficiaries2MedPackResult SelectedBeneficiary
        {
            get;
            set;
        }

        public DbContext HealthDataContext { get { return _DbContext; } }

        


        public ObservableCollection<MedicalPacketType> MedicalPacketTypes
        {
            get { return _medPackTypesColl; }
        }


        // below properties collect info regarding new medical packet:
        public int? NewMedPackTypeId { get; set; }

        private DateTime _newMedPackValidFrom = HelperFuncs.NextMonthStart(DateTime.Now);
        public DateTime NewMedPackValidFrom { get { return _newMedPackValidFrom; } set { _newMedPackValidFrom = value; } }

        private DateTime? _newMedPackValidTo = null;
        public DateTime? NewMedPackValidTo { get { return _newMedPackValidTo; } set { _newMedPackValidTo = value; } }
        
        public bool NewMedPackPayByEmp { get; set; }
        public bool NewMedPackInclInLimit { get; set; }


        private void EmployeeSelected(GetEmployeesResult Employee)
        {
            _selectedEmpId = Employee.EmployeeID;
            RaisePropertyChanged("MedicalPacketsLinkedToEmployee");
        }


        // callbacks for clicks on the user form
        private ICommand _addMedPackToEmp;
        public ICommand AddMedPackToEmp
        {
            get
            {
                if (_addMedPackToEmp == null) _addMedPackToEmp = new RelayCommand(param => this.AddMedicalPacketToEmployee(), null);
                return _addMedPackToEmp;
            }
        }
        public void AddMedicalPacketToEmployee()
        {
            try
            {
                if (_selectedEmpId == 0)
                {
                    MessageBox.Show("Please select employee from the most left navigation pane.");
                }
                else if (NewMedPackTypeId == null)
                {
                    MessageBox.Show("Please select medical packet type.");
                }
                else
                {
                    _DbContext.spAddMedicalPacketToEmployee(
                                                                employeeId: _selectedEmpId,
                                                                medicalPacketTypeId: NewMedPackTypeId,
                                                                beneficiaryGroupId: null,
                                                                validFrom: NewMedPackValidFrom,
                                                                validTo: NewMedPackValidTo,
                                                                includedInLimit: NewMedPackInclInLimit,
                                                                isPayedByEmployee: NewMedPackPayByEmp,
                                                                note: null
                                                                );
                    if (NewMedPackTypeId == 4)
                        _DbContext.spAddMedicalPacketToEmployee(employeeId: _selectedEmpId,
                                                                medicalPacketTypeId: 8,
                                                                beneficiaryGroupId: null,
                                                                validFrom: NewMedPackValidFrom,
                                                                validTo: NewMedPackValidTo,
                                                                includedInLimit: NewMedPackInclInLimit,
                                                                isPayedByEmployee: NewMedPackPayByEmp,
                                                                note: null);

                    RaisePropertyChanged("MedicalPacketsLinkedToEmployee");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _ShowAddNewBenefControl;
        public ICommand ShowAddNewBenefControl
        {
            get
            {
                if (_ShowAddNewBenefControl == null) _ShowAddNewBenefControl = new RelayCommand(param => this.ShowAddNewBeneficiaryControl(), null);
                return _ShowAddNewBenefControl;
            }
        }

        private void ShowAddNewBeneficiaryControl()
        {
            try
            {
                if (_selectedEmpId == 0)
                {
                    System.Windows.MessageBox.Show(messageBoxText: "No active employee was selected. \n\n Pleae select employee first.");
                    return;
                }

                if (SelectedMedicalPacket == null)
                {
                    System.Windows.MessageBox.Show(messageBoxText: "No medical packet for active employee was selected. \n\n Pleae select medical packet first.");
                    return;
                }

                //Modified User Control type to Window type, so no runtime created window is required
                using (AddNewBeneficiaryView wnd = new AddNewBeneficiaryView(this))
                {
                    wnd.ShowDialog();

                    //if insertion error occured on server side, provide handling mechanism

                    if (SelectedMedicalPacket.BeneficiaryGroupID == null)
                    {
                        _DbContext.spCreateBeneficiaryGroupForMedPack(medPackID: SelectedMedicalPacket.ConfiguredMedicalPacketID);
                    }
                    _DbContext.spAddBeneficiaryToMedicalPacket(
                                                                    beneficiaryID: wnd.Beneficiary.BeneficiaryID,
                                                                    medicalPacketID: SelectedMedicalPacket.ConfiguredMedicalPacketID
                                                                    );
                    RaisePropertyChanged("BeneficiariesLinkedToMedPack");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        private ICommand _RemoveMedPackFromEmp;
        private void __RemoveMedPackFromEmp()
        {
            try
            {
                if (SelectedMedicalPacket == null)
                    MessageBox.Show(messageBoxText: "No medical packet for active employee was selected. \n\n Pleae select medical packet first.");
                else
                {
                    DeactivateBenefitView _DeactView = new DeactivateBenefitView(this);
                    _DeactView.ShowDialog();
                    //method raised also when user cancel operation - implement handling for this case
                    RaisePropertyChanged("MedicalPacketsLinkedToEmployee");
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public ICommand RemoveMedPackFromEmployee
        {        
            get
            {
                //TODO: determine predicate for CanExecute. (for now it is null...)
                if (_RemoveMedPackFromEmp == null) _RemoveMedPackFromEmp = new RelayCommand(param => this.__RemoveMedPackFromEmp(), null);
                return _RemoveMedPackFromEmp;
            }
        }
        
        private bool CanExecuteAddNewBenef()
        {   //todo
            //programm some bulog {bu-sinness log-ic} here.
            return true;
        }


        private ICommand _removeBenef;
        public ICommand RemoveBenef
        {
            get { if (_removeBenef == null) _removeBenef = new RelayCommand(param => this.RemoveBeneficiary(),null);
                return _removeBenef;}
        }

        public void RemoveBeneficiary()
        {
        try 
	    {	        
		
            if (SelectedBeneficiary == null)
            {
                System.Windows.MessageBox.Show(messageBoxText: "No active beneficiary was selected. \n\n Pleae select beneficiary first.");
                return;
            }
            else
            {
                _DbContext.spRemoveBeneficiaryFromMedicalPacket(
                                                                    beneficiaryID: this.SelectedBeneficiary.BeneficiaryID,
                                                                    medicalPacketId: this.SelectedBeneficiary.ConfiguredMedicalPacketID);
                RaisePropertyChanged("BeneficiariesLinkedToMedPack");
                RaisePropertyChanged("SelectedBenefId");
            }
	}
	catch (Exception e)
	{
                MessageBox.Show(e.Message);
	}
        }
        
        
        public void SaveNewBeneficiary()
        {

        }

        private void AddNewBeneficiaryControl()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
