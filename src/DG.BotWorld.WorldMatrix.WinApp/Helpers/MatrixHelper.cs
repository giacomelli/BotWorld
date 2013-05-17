using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.WorldMatrix.WinApp.Helpers
{
    public static class MatrixHelper
    {
        public static event EventHandler SelectedEnvironmentChanged;
        public static event EventHandler SelectedBotsChanged;

        private static IEnvironment s_selectedEnvironment;
        private static List<IBot> s_selectedBots;

        static MatrixHelper()
        {
            s_selectedBots = new List<IBot>();
        }

        public static IEnvironment SelectedEnvironment
        {
            get
            {
                return s_selectedEnvironment;
            }

            set
            {
                if (value != s_selectedEnvironment)
                {
                    s_selectedEnvironment = value;
                    OnSelectedEnvironmentChanged(EventArgs.Empty);
                }
                else
                {
                    s_selectedEnvironment = value;
                }                
            }
        }

        public static IList<IBot> SelectedBots
        {
            get
            {
                return s_selectedBots.AsReadOnly();
            }
        }

        public static void ClearSelectedBots()
        {
            if (s_selectedBots.Count > 0)
            {
                s_selectedBots.Clear();
                OnSelectedBotsChanged(EventArgs.Empty);
            }
        }

        public static void AddSelectedBot(IBot bot)
        {
            if (!s_selectedBots.Contains(bot))
            {
                s_selectedBots.Add(bot);
                OnSelectedBotsChanged(EventArgs.Empty);
            }
        }

        public static void RemoveSelectedBot(IBot bot)
        {
            if (s_selectedBots.Contains(bot))
            {
                s_selectedBots.Remove(bot);
                OnSelectedBotsChanged(EventArgs.Empty);
            }
        }

        private static void OnSelectedEnvironmentChanged(EventArgs e)
        {
            if(SelectedEnvironmentChanged != null)
            {
                SelectedEnvironmentChanged(typeof(MatrixHelper), e);
            }
        }

        private static void OnSelectedBotsChanged(EventArgs e)
        {
            if (SelectedBotsChanged != null)
            {
                SelectedBotsChanged(typeof(MatrixHelper), e);
            }
        }
    }
}
