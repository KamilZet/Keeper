using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            KeeperRichClient.Modules.Benefits.PeselValidator pv = new KeeperRichClient.Modules.Benefits.PeselValidator();

            pv.Validate(86102009790, System.Globalization.CultureInfo.CurrentCulture);

            

        }
    }
}
