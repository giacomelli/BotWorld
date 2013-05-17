#region Usings
using System.ComponentModel.Composition;
using DG.BotWorld.BotSdk;
using DG.BotWorld.QuickStarts.Bots.SampleBot.Resources;
#endregion

namespace DG.BotWorld.QuickStarts.Bots.SampleBot
{
    /// <summary>
    /// Sample implementation of DG.BotWorld.BotSdk.IBot.
    /// </summary>
    [Export(typeof(IBot))] // This MEF's attribute is required, otherwise Bot World can't see the bot.
    public class Bot : BotBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="Bot"/> class.
        /// </summary>
        public Bot()
        {
            Name = "SampleBot"; // The bot's name. Must be unique in whole Bot World.
            UIInformation = new BotUIInformation(BotResource.Avatar); // Image to represent the bot.
        }
        #endregion
    }
}
