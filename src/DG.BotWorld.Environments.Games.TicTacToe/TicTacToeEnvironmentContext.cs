using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.TicTacToeSdk;

namespace DG.BotWorld.Environments.Games.TicTacToe
{
	/// <summary>
	/// A Tic Tac Toe environment context.
	/// </summary>
	public class TicTacToeEnvironmentContext : EnvironmentContextBase, ITicTacToeEnvironmentContext
	{
		#region ITicTacToeEnvironmentContext Members
		/// <summary>
		/// Gets the board.
		/// </summary>
		public ITicTacToeBoard Board
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the type of my space.
		/// </summary>
		/// <value>
		/// The type of my space.
		/// </value>
		public SpaceType MySpaceType
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the type of the opponent space.
		/// </summary>
		/// <value>
		/// The type of the opponent space.
		/// </value>
		public SpaceType OpponentSpaceType
		{
			get;
			set;
		}
		#endregion
	}
}
