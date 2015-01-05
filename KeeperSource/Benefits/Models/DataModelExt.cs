
using System;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Collections.Generic;

namespace KeeperRichClient.Modules.Benefits.Models
{
    public partial class LanguageCoursesToEmployee
    {
        public LanguageCoursesToEmployee Clone()
        {
            return (LanguageCoursesToEmployee)this.MemberwiseClone();
        }
    }

    public partial class DbContext : System.Data.Linq.DataContext{
        partial void OnCreated(){
            this.CommandTimeout = 0;
        }

        
        
        [FunctionAttribute(Name = "Healthcare.RunInternMedReport")]
        [ResultType(typeof(RunInternMedReportResult))] // for perm emp results
        [ResultType(typeof(RunInternMedReportResult))] // for shit (aka freelance;) emp results
        [ResultType(typeof(RunInternMedReportResult))] // for business emp result
        
        public  IMultipleResults RunInternMedReportExt(
            [ParameterAttribute(DbType = "DateTime")] System.Nullable<System.DateTime> repStart, 
            [ParameterAttribute(DbType = "DateTime")] System.Nullable<System.DateTime> repEnd)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), repStart, repEnd);
            return ((IMultipleResults)(result.ReturnValue));
        }

    }

}