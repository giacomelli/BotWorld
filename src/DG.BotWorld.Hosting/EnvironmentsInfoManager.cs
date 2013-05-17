using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Hosting
{
    internal class EnvironmentsInfoManager
    {
        public EnvironmentsInfoManager()
        {
            Environments = new List<IEnvironment>();
        }

        [ImportMany(typeof(IEnvironment), AllowRecomposition = true)]
        public List<IEnvironment> Environments
        {
            get;
            private set;
        }
    }
}
