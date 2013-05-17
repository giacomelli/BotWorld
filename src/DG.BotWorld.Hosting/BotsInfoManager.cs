using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Hosting
{
    internal class BotsInfoManager
    {
        public BotsInfoManager()
        {
            Bots = new List<IBot>();
        }

        [ImportMany(typeof(IBot), AllowRecomposition = true)]
        public List<IBot> Bots
        {
            get;
            private set;
        }
    }
}
