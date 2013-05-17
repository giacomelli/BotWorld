using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.BotWorld.Hosting
{
    internal static class ConfigHelper
    {
        static ConfigHelper()
        {
            WorldRootDir = AppDomain.CurrentDomain.BaseDirectory + @"World\";

            WorldSourceRootDir = WorldRootDir + @"Sources\";
            EnvironmentsSourceRootDir = WorldSourceRootDir + @"Environments\";
            BotsSourceRootDir = WorldSourceRootDir + @"Bots\";

            WorldInstancesRootDir = WorldRootDir + @"Instances\";
        }

        public static string WorldRootDir
        {
            get;
            private set;
        }

        internal static string WorldInstancesRootDir
        {
            get;
            private set;
        }

        internal static string WorldSourceRootDir
        {
            get;
            private set;
        }      

        internal static string EnvironmentsSourceRootDir
        {
            get;
            private set;
        }

        internal static string BotsSourceRootDir
        {
            get;
            private set;
        } 
    }
}
