using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.ObjectModel;

using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Reflection;


namespace LinqKeeper
{

        [Database]
        public class KeeperContext : DataContext
        {
            public KeeperContext() : base("data source=WAR-SQL100;initial catalog=MCM_Keeper;integrated security=True") { }
            public Table<Beneficiary> Beneficiary;
            public Table<BeneficiaryIdentityCardType> IdCardTypes;
            public Table<BeneficiaryGroupID> BeneficiaryGroups;
            public Table<BeneficiaryGroupDetails> BeneficiaryGroupDetails;
            public Table<Employee> Employee;

            [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "Interface.GetEmployees")]
            public ISingleResult<Employee> GetEmployees()
            {
                IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
                return ((ISingleResult<Employee>)(result.ReturnValue));
            }

        }

        [Table(Name = "Benefits.Beneficiaries")]
        public class Beneficiary
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)] public int BeneficiaryID { get; set; }
            [Column] public string BeneficiaryFName { get; set; }
            [Column] public string BeneficiaryLName { get; set; }
            [Column] public string BeneficiaryPesel { get; set; }
            [Column] public string BeneficiaryAddress { get; set; }

            #region Foreign Key: BeneficiaryIdentityCardType
            [Column(Name = "BeneficiaryIdentityCardType")]
            private int _BeneficiaryIdentityCardType;
            private EntityRef<BeneficiaryIdentityCardType> _IdCardType = new EntityRef<BeneficiaryIdentityCardType>();
            [Association(Name = "FK_Beneficiaries_IdentityCardTypes", IsForeignKey = true, Storage = "_IdCardType", ThisKey = "_BeneficiaryIdentityCardType")]
            public BeneficiaryIdentityCardType IdCardType
            {
                get { return _IdCardType.Entity; }
                set { _IdCardType.Entity = value; }
            }
            #endregion

            [Column] public string BeneficiaryIdentityCardNumber { get; set; }
            
            //#region Foreign Key: BeneficiaryParentEmployeeID
            [Column(Name = "BeneficiaryParentEmployeeID")] public int _BeneficiaryParentEmployeeID;
            //private EntityRef<BeneficiaryParentEmployeeID>
            //public int BeneficiaryParentEmployeeID { get; set; }
            //#endregion

        }

        [Table(Name = "General.IdentityCardTypes")]
        public class BeneficiaryIdentityCardType
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "int not null")]
            public int IdentityCardTypeID { get; set; }

            [Column(DbType = "nvarchar(50) not null")]
            public string IdentityCardTypeName { get; set; }
        }

        [Table(Name = "Benefits.BeneficiaryGroupID")]
        public class BeneficiaryGroupID
        {
            [Column(IsPrimaryKey = true)] public int BeneficiaryGroupId;
            [Column] public bool IsActive;
        }

        [Table(Name = "Benefits.BeneficiaryGroupDetails")]
        public class BeneficiaryGroupDetails
        {
            [Column(Name = "BeneficiaryGroupID", IsPrimaryKey = true)]
            private int _beneficiaryGroupId;
            private EntityRef<BeneficiaryGroupID> _refBeneficiaryGroupId = new EntityRef<BeneficiaryGroupID>();
            [Association(Name = "FK_BeneficiaryGroupDetails_BeneficiaryGroupId", IsForeignKey = true, Storage = "_refBeneficiaryGroupId", ThisKey = "_beneficiaryGroupId")]

            public BeneficiaryGroupID BeneficiaryGroup
            {
                get { return _refBeneficiaryGroupId.Entity; }
                set { _refBeneficiaryGroupId.Entity = value; }
            }

            [Column(Name = "BeneficiaryID", IsPrimaryKey = true)]
            private int _beneficiaryId;
            private EntityRef<Beneficiary> _refBeneficiaryId = new EntityRef<Beneficiary>();
            [Association(Name = "FK_BeneficiaryGroupDetails_Beneficiaries", IsForeignKey = true, Storage = "_refBeneficiaryId", ThisKey = "_beneficiaryId")]
            public Beneficiary Beneficiary
            {
                get { return _refBeneficiaryId.Entity; }
                set { _refBeneficiaryId.Entity = value; }
            }

            [Column(Name = "BeneficiaryAddDate")]
            public DateTime BeneficiaryAddDate;
            [Column(Name = "BeneficiaryRemoveDate")]
            public Nullable<DateTime> BeneficiaryRemoveDate;
        }
        
        [Table(Name="Interface.GetEmployees")]
        public class Employee
        {
            [Column] public int EmployeeID;
            [Column] public string FirstName;
            [Column] public string LastName;
            [Column] public string Email;
            [Column] public Nullable<int> LevelID;

        }
        public class Employees{}
}



   
