using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KeeperRichClient.Modules.Benefits
{
    public class AddNewBeneficiaryViewModel : INotifyPropertyChanged
    {
        private DbContext _healthcareDc;
        private HealthcareViewModel _healthcareVm;
        private Window _parentWnd;
        public bool CanEdit {get; private set;}

        private fBeneficiariesToEmployeeResult _beneficiary;
        public fBeneficiariesToEmployeeResult Beneficiary
        {
            get { return _beneficiary; }
            set
            {
                _beneficiary.BeneficiaryFName = value.BeneficiaryFName; RaisePropertyChanged("FirstName");
                _beneficiary.BeneficiaryLName = value.BeneficiaryLName; RaisePropertyChanged("LastName");
                _beneficiary.BeneficiaryPesel = value.BeneficiaryPesel; RaisePropertyChanged("Pesel");
                RaisePropertyChanged("YearFromPesel"); RaisePropertyChanged("MonthFromPesel"); RaisePropertyChanged("DayFromPesel");
                RaisePropertyChanged("SexFromPesel");
                _beneficiary.BeneficiaryCitizenship = value.BeneficiaryCitizenship; RaisePropertyChanged("CitizenShip");
                _beneficiary.BeneficiaryPhoneNumber = value.BeneficiaryPhoneNumber; RaisePropertyChanged("PhoneNumber");
                _beneficiary.BeneficiaryEmailAddress = value.BeneficiaryEmailAddress; RaisePropertyChanged("EmailAddress");
            }
        }   

        public AddNewBeneficiaryViewModel(HealthcareViewModel InVm,Window ArgParentWnd)
        {
            _parentWnd = ArgParentWnd;
            _healthcareVm = InVm;
            _healthcareDc = InVm.HealthDataContext;
            _beneficiary = new fBeneficiariesToEmployeeResult();
            //_beneficiary.BeneficiaryParentEmployeeID = _healthcareVm.SelectedEmployeeId;
        }

        public AddNewBeneficiaryViewModel(DbContext InDc)
        {
            _healthcareDc = InDc;
            _beneficiary = new fBeneficiariesToEmployeeResult();
        }

        public IQueryable<fBeneficiariesToEmployeeResult> GetBeneficiaries
        {
            get { return (IQueryable<fBeneficiariesToEmployeeResult>)_healthcareDc.fBeneficiariesToEmployee(_healthcareVm.SelectedEmployeeId); }
        }

        public string FirstName 
        {
            get{return _beneficiary.BeneficiaryFName;}
            set { _beneficiary.BeneficiaryFName = value; } 
        }
        public string LastName 
        {
            get { return _beneficiary.BeneficiaryLName; }
            set { _beneficiary.BeneficiaryLName = value; } 
        }
        public string Pesel
        {
            get { return _beneficiary.BeneficiaryPesel; }
            set 
            { 
                _beneficiary.BeneficiaryPesel = value;
                RaisePropertyChanged("YearFromPesel");
                RaisePropertyChanged("MonthFromPesel");
                RaisePropertyChanged("DayFromPesel");
                RaisePropertyChanged("SexFromPesel");
            }
        }

        public DateTime DateOfBirth
        {
            get { return _beneficiary.BeneficiaryBirthDate; }
            set { _beneficiary.BeneficiaryBirthDate = value; }
        }

        public string CitizenShip
        {
            get { return _beneficiary.BeneficiaryCitizenship; }
            set { _beneficiary.BeneficiaryCitizenship = value; }
        }

        public string Sex
        {
            get { return _beneficiary.BeneficiarySex; }
            set { _beneficiary.BeneficiarySex = value; }
        }

        public string PhoneNumber
        {
            get { return _beneficiary.BeneficiaryPhoneNumber; }
            set { _beneficiary.BeneficiaryPhoneNumber = value; }
        }

        public string EmailAddress 
        {
            get { return _beneficiary.BeneficiaryEmailAddress; }
            set { _beneficiary.BeneficiaryEmailAddress = value; } 
        }

        public int ParentEmployeeID 
        {
            get { return _beneficiary.BeneficiaryParentEmployeeId; }
            private set { _beneficiary.BeneficiaryParentEmployeeId = value; }
        }
        
        private ICommand _saveNewBenef;
        public ICommand SaveNewBenef
        {
            get
            {
                if (_saveNewBenef == null)
                {
                    _saveNewBenef = new RelayCommand(param => this.SaveNewBeneficiary(), null);
                }
                return _saveNewBenef;
            }
        }


        public void SaveNewBeneficiary()
        {
            try
            {   
                _beneficiary.BeneficiaryID = _healthcareDc.spCreateBeneficiary(
                                                    beneficiaryFName: _beneficiary.BeneficiaryFName,
                                                    beneficiaryLName: _beneficiary.BeneficiaryLName,
                                                    beneficiaryPesel: _beneficiary.BeneficiaryPesel,
                                                    beneficiaryBirthDate : _beneficiary.BeneficiaryBirthDate,
                                                    beneficiaryCitizenship : _beneficiary.BeneficiaryCitizenship,
                                                    beneficiarySex : _beneficiary.BeneficiarySex,
                                                    beneficiaryPhoneNumber: _beneficiary.BeneficiaryPhoneNumber,
                                                    beneficiaryEmailAddress: _beneficiary.BeneficiaryEmailAddress,
                                                    beneficiaryParentEmployeeId: _healthcareVm.SelectedEmployeeId
                                                    );
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally
            {
                // close window, which holds view AddNewBeneficiaryView
                // need to obtain reference 
                
                //Window parentWindow = Window.GetWindow(user control ref)
                _parentWnd.Close();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler hand = PropertyChanged;
            if (hand != null) hand(this, new PropertyChangedEventArgs(PropertyName));
        }

        // Beneficiary Sex Setting
        private Dictionary<int, string> _SexList = new Dictionary<int, string>(){{1,"Male"},{2,"Female"}};
        public Dictionary<int, string> SexList
        {
            get{return _SexList;}
        }

        private int _SelectedSex;
        public int SelectedSex
        {
            get { return _SelectedSex; }
            set { _SelectedSex = value; System.Windows.MessageBox.Show(value.ToString()); }
        }
        //Beneficiary Sex Setting

        public string YearFromPesel
        {
            get { return HelperFuncs.GetYearFromPesel(Pesel); }
        }
        public string MonthFromPesel
        {
            get { return HelperFuncs.GetMonthFromPesel(Pesel); }
        }
        public string DayFromPesel
        {
            get { return HelperFuncs.GetDayFromPesel(Pesel); }
        }

        public string SexFromPesel
        {
            get { return HelperFuncs.GetSexFromPesel(Pesel); }
        }

    }
}
