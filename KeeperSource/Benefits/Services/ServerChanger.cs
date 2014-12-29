using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace KeeperRichClient.Modules.Benefits.Services
{
    public static class ServerChanger //: BindableBase
    {
        //private static string actConnStr;
        public static string ConnStr
        {
            get
            {
                //if (actConnStr == null)
                //    actConnStr = Properties.Settings.Default.MCM_Keeper_Dev_ConnString;
                //else if (actConnStr == Properties.Settings.Default.MCM_Keeper_Dev_ConnString)
                //    actConnStr = Properties.Settings.Default.MCM_KeeperConnectionString;
                //else if (actConnStr == Properties.Settings.Default.MCM_KeeperConnectionString)
                //    actConnStr = Properties.Settings.Default.MCM_Keeper_Dev_ConnString;
                #if DEBUG
                    return Properties.Settings.Default.MCM_Keeper_Dev_ConnString;
                #else
                    return Properties.Settings.Default.MCM_KeeperConnectionString;
                #endif


            }
            private set 
            {
                
            }
        }

        public static string ConnStrTag
        {
            get{
                #if DEBUG
                    return "DEVELOPMENT DB";
                #else
                    return "PRODUCTION DB";
                #endif
            }
        }


    }
}

