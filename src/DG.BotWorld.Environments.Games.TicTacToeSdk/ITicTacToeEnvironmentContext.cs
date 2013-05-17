using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Games.TicTacToeSdk
{
	/// <summary>
	/// Defines a interface for the Tic Tac Toe environment context.
	/// </summary>
	public interface ITicTacToeEnvironmentContext : IEnvironmentContext
	{
		#region Properties
		/// <summary>
		/// Gets the board.
		/// </summary>
		ITicTacToeBoard Board
		{
			get;
		}

		/// <summary>
		/// Gets the type of my space.
		/// </summary>
		/// <value>
		/// The type of my space.
		/// </value>
		SpaceType MySpaceType
		{
			get;
		}

		/// <summary>
		/// Gets the type of the opponent space.
		/// </summary>
		/// <value>
		/// The type of the opponent space.
		/// </value>
		SpaceType OpponentSpaceType
		{
			get;
		}
		#endregion
	}
}
