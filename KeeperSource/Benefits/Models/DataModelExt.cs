
using System;
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
    }

}