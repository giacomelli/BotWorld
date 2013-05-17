#region Usings

#endregion

namespace DG.BotWorld.BotSdk
{
    /// <summary>
    /// Defines a ability a bot can have.
    /// A ability must be define by a environment and implemented by a bot.
    /// </summary>
    public interface IBotAbility
    {
        #region Métodos
        /// <summary>
        /// Performs ability's initialization.
        /// </summary>
        /// <param name="context">The environment context.</param>
        void Initialize(IEnvironmentContext context);
        #endregion
    }
}
