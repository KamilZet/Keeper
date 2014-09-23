using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using KeeperRichClient.Modules.Benefits;
using KeeperRichClient.Modules.Benefits.ViewModels;
using KeeperRichClient.Modules.Benefits.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LanguageCourseViewModel langCourseVm = new LanguageCourseViewModel();
            
            
            langCourseVm.ActiveCourse = new LanguageCoursesToEmployee();


            Assert.Fail("Course start date error", langCourseVm.CourseStartDate);

        }
    }
}
