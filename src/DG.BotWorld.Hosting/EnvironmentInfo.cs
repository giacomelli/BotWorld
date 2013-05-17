using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.EnvironmentSdk;
using System.ComponentModel.Composition;
using DG.BotWorld.RendererSdk;

namespace DG.BotWorld.Hosting
{
    internal class EnvironmentInfo
    {
        public EnvironmentInfo(IEnvironment environment)
        {
            Environment = environment;
            Renderers = new List<IEnvironmentRenderer>();
        }

        public IEnvironment Environment
        {
            get;
            private set;
        }

        [ImportMany(typeof(IEnvironmentRenderer), AllowRecomposition = true)]
        public List<IEnvironmentRenderer> Renderers
        {
            get;
            private set;
        }
    }
}
