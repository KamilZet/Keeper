using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeperRichClient.Modules.Benefits.Services
{
    public static class ServerChanger
    {
        public static string ConnStr
        {
            get 
            {   
                return Properties.Settings.Default.MCM_Keeper_Dev_ConnString;
            }
        }
    }
}
