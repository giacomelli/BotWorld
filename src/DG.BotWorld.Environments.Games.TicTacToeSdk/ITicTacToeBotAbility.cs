#region Usings
using DG.BotWorld.BotSdk;
#endregion

namespace DG.BotWorld.Environments.Games.TicTacToeSdk
{
    /// <summary>
    /// Ability to play the environment.
    /// </summary>
    public interface ITicTacToeBotAbility : IBotAbility
    {
        /// <summary>
        /// Play a turn on the board.
        /// </summary>
        /// <param name="context">The Tic Tac Toe environment's context.</param>
        /// <returns>The play turn result.</returns>
        TicTacToeBotPlayTurnResult PlayTurn(ITicTacToeEnvironmentContext context);
    }
}
