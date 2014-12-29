using System;
using System.Windows;
using System.Linq;
using KeeperRichClient.Infrastructure;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Employees.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Mvvm;
using KeeperRichClient.Modules.Benefits.Services;

namespace KeeperRichClient.Modules.Benefits.ViewModels
{
    public class NewBeneficiaryDetailsViewModel : ViewModelBase, INewBeneficiaryViewModel,IAddBeneficiary
    {
        IView activeView = (IView)ServiceLocator.Current.GetInstance<IRegionManager>().Regions["MainContentRegion"].ActiveViews.FirstOrDefault();
        public NewBeneficiaryDetailsViewModel()
        {
            if (activeView is HealthcareView)
                this.IsFieldEnabled = true;
            else
                this.IsFieldEnabled = false;
        }

        bool isFieldEnabled;
        public bool IsFieldEnabled 
        { 
            get {return isFieldEnabled;} 
            private set 
            {
                isFieldEnabled = value;
                RaisePropertyChanged("IsFieldDisabled"); 
            }
        }

        Beneficiary beneficiary;
        public Beneficiary Beneficiary
        {
            get
            {
                if (beneficiary == null) beneficiary = new Beneficiary();
                return beneficiary;
            }
            private set
            {
                beneficiary = value;
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

        public DateTime DateOfBirth
        {
            get { return new DateTime(Int32.Parse(YearFromPesel), Int32.Parse(MonthFromPesel), Int32.Parse(DayFromPesel)); }
        }


        public string Citizenship{
            get { return Beneficiary.BeneficiaryCitizenship; }
            set { Beneficiary.BeneficiaryCitizenship = value; }}

        public string Sex
        {
            get { return SexFromPesel; }
        }

        public string PhoneNumber{
            get { return Beneficiary.BeneficiaryPhoneNumber; }
            set { Beneficiary.BeneficiaryPhoneNumber = value; }}
            
        public string EmailAddress{
            get { return Beneficiary.BeneficiaryEmailAddress; }
            set { Beneficiary.BeneficiaryEmailAddress = value; }}

        public int ParentEmployeeID
        {
            get { return ActiveEmployee.Employee.EmpId; }
        }


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
            using (DbContext db = new DbContext(ServerChanger.ConnStr))
            {
                if (activeView is HealthcareView)
                {
                    int newBeneficiaryId = db.spCreateMedicalBeneficiary(FirstName, 
                                                  LastName, 
                                                  Pesel, 
                                                  DateOfBirth, 
                                                  Citizenship, 
                                                  Sex, 
                                                  PhoneNumber, 
                                                  EmailAddress, 
                                                  ParentEmployeeID);

                    if (newBeneficiaryId != 0)
                    {
                        db.spAddBeneficiaryToMedicalPacket(newBeneficiaryId,
                                                           (activeView.DataContext as HealthcareViewModel).SelectedMedicalPacket.ConfiguredMedicalPacketID
                                                           );
                        Beneficiary = new Beneficiary();
                        MessageBox.Show("Beneficiary created and assigned to the selected healthcare packet.");
                        RaisePropertyChanged(string.Empty);
                    }
                    else
                        MessageBox.Show("Error occured. Please");

                    
                }
                else
                {
                    //db.spCreateMultisportBeneficiary();
                }
                    
            }

        }

        public bool CanBeAdded()
        {
            return true;
        }




    }

    
}
