using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.BotSdk;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace DG.BotWorld.Hosting
{
    internal class BotInfo
    {
        public BotInfo(IBot bot)
        {
            Bot = bot;
            Abilities = new List<IBotAbility>();
        }

        public IBot Bot
        {
            get;
            private set;
        }

       [ImportMany(typeof(IBotAbility), AllowRecomposition = true)]
        public List<IBotAbility> Abilities
        {
            get;
            private set;
        }
    }
}
