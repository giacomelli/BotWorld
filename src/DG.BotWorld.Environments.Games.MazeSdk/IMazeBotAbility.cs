#region Usings
using DG.BotWorld.BotSdk;
#endregion

namespace DG.BotWorld.Environments.Games.MazeSdk
{
    #region Enumerations
    /// <summary>
    /// Directions bot can walk on maze.
    /// </summary>
    public enum WalkDirection
    {
        /// <summary>
        /// Walk to up side of maze.
        /// </summary>
        Up,

        /// <summary>
        /// Walk to right side of maze.
        /// </summary>
        Right,

        /// <summary>
        /// Walk to down side of maze.
        /// </summary>
        Down,

        /// <summary>
        /// Walk to left side of maze.
        /// </summary>
        Left
    }
    #endregion

    /// <summary>
    /// Ability to play environment.    
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item>A* search algorithm (http://en.wikipedia.org/wiki/A*_search_algorithm)</item>
    /// <item>A* Pathfinding for Beginners (http://www.policyalmanac.org/games/aStarTutorial.htm)</item>
    /// <item>Fixing Pathfinding Once and For All (http://www.ai-blog.net/archives/000152.html)</item>
    /// <item>Amit`s A* Pages (http://theory.stanford.edu/~amitp/GameProgramming/)</item>
    /// </list>
    /// </remarks>
    public interface IMazeBotAbility : IBotAbility
    {
        /// <summary>
        /// Choose the walk direction.
        /// </summary>
        /// <param name="context">The maze environment's context.</param>
        /// <returns>The walk diretion choosen.</returns>
        WalkDirection Walk(IMazeEnvironmentContext context);
    }
}
