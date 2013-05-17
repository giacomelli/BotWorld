#region Usings
using System;
using System.ComponentModel.Composition;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.MazeSdk;
#endregion

namespace DG.BotWorld.QuickStarts.Bots.SampleBot.Abilities.Maze
{
    /// <summary>
    /// Sample implementation of DG.BotWorld.Environments.Games.MazeSdk.IMazeBotAbility ability.
    /// Bot needs this ability to run on DG.BotWorld.Environments.Games.Maze environment.
    /// </summary>
    [Export(typeof(IBotAbility))] // This MEF's attribute is required, otherwise Bot World can't see the ability.
    public class Ability : IMazeBotAbility
    {
        #region Fields
        /// <summary>
        /// Use to generate random MoveDirection.
        /// </summary>
        private Random m_random;
        #endregion

        #region IBotAbility Members
        /// <summary>
        /// Performs ability's initialization.
        /// </summary>
        /// <param name="context">The environment context.</param>
        public void Initialize(IEnvironmentContext context)
        {
            m_random = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Performs ability's update
        /// </summary>
        /// <param name="context">The environment context.</param>
        /// <returns>The direction to walk.</returns>
        public WalkDirection Walk(IMazeEnvironmentContext context)
        {
            WalkDirection randomDirection;

            // Look for a direction to walk.
            do
            {
                randomDirection = (WalkDirection)m_random.Next(0, 4);
            }
            while (!context.CanWalkTo(randomDirection));

            // Return direction.
            return randomDirection;
        }

        #endregion
    }
}
