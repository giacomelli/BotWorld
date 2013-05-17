#region Usings
using System.ComponentModel.Composition;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.MazeSdk;
using DG.Framework.Common;
#endregion

namespace DG.BotWorld.Bots.GuardianBot.Abilities.Games.Maze
{
    /// <summary>
    /// Ability to play DG.BotWorld.Environments.IMazeSdk environment's implementation.
    /// </summary>
    [Export(typeof(IBotAbility))]
    public class Ability : IMazeBotAbility
    {
        #region IBotAbility Members
        /// <summary>
        /// Performs ability's initialization.
        /// </summary>
        /// <param name="context">The environment context.</param>
        public void Initialize(IEnvironmentContext context)
        {
            
        }


        /// <summary>
        /// Choose the walk direction.
        /// </summary>
        /// <param name="context">The maze environment's context.</param>
        /// <returns>The walk diretion choosen.</returns>
        public WalkDirection Walk(IMazeEnvironmentContext context)
        {            
            return (WalkDirection)RandomHelper.NextInt(0, 4);
        }

        #endregion
    }
}
