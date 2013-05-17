using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Games.MazeSdk
{
	/// <summary>
	/// Defines a interface for the Maze environemnt context.
	/// </summary>
	public interface IMazeEnvironmentContext : IEnvironmentContext
	{
		/// <summary>
		/// Determines whether the bot can walk to the specified direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <returns>
		///   <c>true</c> if the bot can walk to the specified direction; otherwise, <c>false</c>.
		/// </returns>
		bool CanWalkTo(WalkDirection direction);
	}
}
