#region Usings

#endregion

namespace DG.BotWorld.BotSdk
{
    /// <summary>
    /// Defines a bot.
    /// </summary>
    public interface IBot
    {
        #region Properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets user interface information.
        /// </summary>
        IBotUIInformation UIInformation
        {
            get;
        }
        #endregion
    }
}
