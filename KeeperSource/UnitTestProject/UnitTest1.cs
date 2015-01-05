using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using KeeperRichClient.Modules.Benefits;
using KeeperRichClient.Modules.Benefits.ViewModels;
using KeeperRichClient.Modules.Benefits.Models;
using KeeperRichClient.Modules.Benefits.Services;

using System.Data;
using System.Xml;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        private DateTime reportStartDate;
        private DateTime reportEndDate;
        private DbContext db;

        [TestInitialize]
        public void Init()
        {
            reportStartDate = new DateTime(2014, 1, 1);
            reportEndDate = new DateTime(2014, 1, 31);
            db = new DbContext(KeeperRichClient.Modules.Benefits.Properties.Settings.Default.MCM_KeeperConnectionString);
        }

       

        [TestMethod]
        public void NewLangCourseInitDate()
        {

            LanguageCourseViewModel langCourseVm = new LanguageCourseViewModel();
            langCourseVm.ActiveCourse = new LanguageCoursesToEmployee();

            Assert.IsTrue(langCourseVm.CourseStartDate == null, "Course start date error");

        }

        [TestMethod]
        public void RunPermEmpMedUse()
        {
           System.Data.DataTable permEmpData = db.PermEmpMedUseInLimit(reportStartDate, reportEndDate).ToDataTable();
           Assert.IsNotNull(permEmpData);
           Assert.IsTrue(permEmpData.Rows.Count == 166); 
        }


        [TestMethod]
        public void RunShitEmpMedUse()
        {
            System.Data.DataTable shitEmpData = db.ShitEmpMedUseInLimit(reportStartDate, reportEndDate).ToDataTable();
            Assert.IsNotNull(shitEmpData);
            Assert.IsTrue(shitEmpData.Rows.Count == 3);
        }

        [TestMethod]
        public void RunBusEmpMedUse()
        {
            System.Data.DataTable busEmpData = db.BusEmpMedUseInLimit(reportStartDate, reportEndDate).ToDataTable();
            Assert.IsNotNull(busEmpData);
            Assert.IsTrue(busEmpData.Rows.Count == 5);
        }

       
    }
}
