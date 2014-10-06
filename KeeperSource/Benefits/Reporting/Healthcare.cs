using System;
using OfficeOpenXml;
using KeeperRichClient.Modules.Benefits.Models;

namespace KeeperRichClient.Modules.Benefits.Reporting
{
    public class HealthcareReports
    {
        public HealthcareReports()
        {
            dataContext = new DbContext();
        }
    
        public void ElasReport(
            DateTime ReportStart , 
            DateTime ReportEnd)
        {
            var ret = dataContext.spCalcHealthcareCost(ReportStart, ReportEnd);
        }


        private DbContext dataContext;

    }
}
