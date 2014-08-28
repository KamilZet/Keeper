using System;
using System.Windows;
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Models;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class NewBeneficiaryDetailsViewModel : ViewModelBase, INewBeneficiaryViewModel,IAddBeneficiary
    {
        public NewBeneficiaryDetailsViewModel(){ }

        Beneficiary beneficiary;
        public Beneficiary Beneficiary
        {
            get
            {
                if (beneficiary == null) beneficiary = new Beneficiary();
                return beneficiary;
            }
        }
        
        public string FirstName{
            get { return Beneficiary.BeneficiaryFName; }
            set { Beneficiary.BeneficiaryFName = value; }}
        
        public string LastName{
            get { return Beneficiary.BeneficiaryLName; }
            set { Beneficiary.BeneficiaryLName = value; }}

        public string Pesel{
            get { return Beneficiary.BeneficiaryPesel; }
            set {Beneficiary.BeneficiaryPesel = value;
                RaisePropertyChanged("YearFromPesel");
                RaisePropertyChanged("MonthFromPesel");
                RaisePropertyChanged("DayFromPesel");
                RaisePropertyChanged("SexFromPesel");}}

        public DateTime DateOfBirth{
            get { return Beneficiary.BeneficiaryBirthDate; }
            set { Beneficiary.BeneficiaryBirthDate = value; }}

        public string Citizenship{
            get { return Beneficiary.BeneficiaryCitizenship; }
            set { Beneficiary.BeneficiaryCitizenship = value; }}

        public string Sex{
            get { return Beneficiary.BeneficiarySex; }
            set { Beneficiary.BeneficiarySex = value; }}

        public string PhoneNumber{
            get { return Beneficiary.BeneficiaryPhoneNumber; }
            set { Beneficiary.BeneficiaryPhoneNumber = value; }}

        public string EmailAddress{
            get { return Beneficiary.BeneficiaryEmailAddress; }
            set { Beneficiary.BeneficiaryEmailAddress = value; }}

        public int ParentEmployeeID{
            get { return Beneficiary.BeneficiaryParentEmployeeId; }
            private set { Beneficiary.BeneficiaryParentEmployeeId = value; }}

        public string YearFromPesel{
            get { return HelperFuncs.GetYearFromPesel(Pesel); }}

        public string MonthFromPesel{
            get { return HelperFuncs.GetMonthFromPesel(Pesel); }}

        public string DayFromPesel{
            get { return HelperFuncs.GetDayFromPesel(Pesel); }}

        public string SexFromPesel{
            get { return HelperFuncs.GetSexFromPesel(Pesel); }}

        public string ViewModelType{
            get{ return "Create New Beneficiary";}}

        public void AddBeneficiary() 
        {
            System.Windows.MessageBox.Show("New saved!");
        }

        public bool CanBeAdded()
        {
            return true;
        }

    }
}
