using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KeeperRichClient.Infrastructure;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public interface INewBeneficiaryViewModel{}

    public class NewBeneficiaryDetailsViewModel : ViewModelBase, INewBeneficiaryViewModel
    {
        public NewBeneficiaryDetailsViewModel(){ 
            beneficiary = new Beneficiary();}

        Beneficiary beneficiary;
        
        public string FirstName{
            get { return beneficiary.BeneficiaryFName; }
            set { beneficiary.BeneficiaryFName = value; }}
        
        public string LastName{
            get { return beneficiary.BeneficiaryLName; }
            set { beneficiary.BeneficiaryLName = value; }}

        public string Pesel{
            get { return beneficiary.BeneficiaryPesel; }
            set {beneficiary.BeneficiaryPesel = value;
                RaisePropertyChanged("YearFromPesel");
                RaisePropertyChanged("MonthFromPesel");
                RaisePropertyChanged("DayFromPesel");
                RaisePropertyChanged("SexFromPesel");}}

        public DateTime DateOfBirth{
            get { return beneficiary.BeneficiaryBirthDate; }
            set { beneficiary.BeneficiaryBirthDate = value; }}

        public string Citizenship{
            get { return beneficiary.BeneficiaryCitizenship; }
            set { beneficiary.BeneficiaryCitizenship = value; }}

        public string Sex{
            get { return beneficiary.BeneficiarySex; }
            set { beneficiary.BeneficiarySex = value; }}

        public string PhoneNumber{
            get { return beneficiary.BeneficiaryPhoneNumber; }
            set { beneficiary.BeneficiaryPhoneNumber = value; }}

        public string EmailAddress{
            get { return beneficiary.BeneficiaryEmailAddress; }
            set { beneficiary.BeneficiaryEmailAddress = value; }}

        public int ParentEmployeeID{
            get { return beneficiary.BeneficiaryParentEmployeeId; }
            private set { beneficiary.BeneficiaryParentEmployeeId = value; }}

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
        
    }
}
