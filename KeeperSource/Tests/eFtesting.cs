
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    public  class eFtesting
    {
        public void Run()
        {
            McmKeeper Keeper = new McmKeeper();

            //foreach (var b in Keeper.Beneficiaries) Console.WriteLine(b.BeneficiaryPesel);

            var Ulas = from Benef in Keeper.Beneficiaries where Benef.BeneficiaryFName == "Ula" || Benef.BeneficiaryPesel.StartsWith("9") select Benef;

            foreach (var item in Ulas)
            {
                Console.WriteLine(item.BeneficiaryFName + " " + item.BeneficiaryLName + " " + item.BeneficiaryPesel);
            }
        }

        public Beneficiaries CreateBeneficiary() 
        {
            Beneficiaries Ben = new Beneficiaries();
            Ben.BeneficiaryFName = "Ula";
            Ben.BeneficiaryLName = "Zień";
            Ben.BeneficiaryPesel = "987456789";
            Ben.BeneficiaryAddress = "Adres1";
            Ben.BeneficiaryIdentityCardType = 1;
            Ben.BeneficiaryIdentityCardNumber = "987123123123";
            Ben.BeneficiaryParentEmployeeID = 1;
            return Ben;
        }
    }
}
