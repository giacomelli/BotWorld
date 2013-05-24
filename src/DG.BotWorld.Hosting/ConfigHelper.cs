using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace DG.BotWorld.Hosting
{
    internal static class ConfigHelper
    {
        static ConfigHelper()
        {
			WorldRootDir = AppDomain.CurrentDomain.BaseDirectory + @"World" + Path.DirectorySeparatorChar;

			WorldSourceRootDir = GetWorldSubDir("Sources");
			EnvironmentsSourceRootDir = GetWorldSourceSubDir("Environments");
			BotsSourceRootDir = GetWorldSourceSubDir("Bots");

			WorldInstancesRootDir = GetWorldSubDir("Instances");
        }

		private static string GetWorldSubDir(string subFolderName)
		{
			return String.Format (CultureInfo.InvariantCulture, "{0}{1}{2}{1}", WorldRootDir, Path.DirectorySeparatorChar, subFolderName);
		}

		private static string GetWorldSourceSubDir(string subFolderName)
		{
			return String.Format (CultureInfo.InvariantCulture, "{0}{1}{2}{1}", WorldSourceRootDir, Path.DirectorySeparatorChar, subFolderName);
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
