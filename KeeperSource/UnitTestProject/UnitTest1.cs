using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeeperRichClient.Modules.Benefits;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PeselValidator pv = new PeselValidator();
            pv.Validate(54032805210, System.Globalization.CultureInfo.CurrentCulture);

            

        }
    }
}
