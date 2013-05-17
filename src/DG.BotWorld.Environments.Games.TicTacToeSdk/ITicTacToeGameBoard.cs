using System.Diagnostics.CodeAnalysis;

namespace DG.BotWorld.Environments.Games.TicTacToeSdk
{
	#region Enumerations
	/// <summary>
	/// Tic Tac Toe board spaces types.
	/// </summary>
	public enum SpaceType
	{
		/// <summary>
		/// A empty space.
		/// </summary>
		Empty,

		/// <summary>
		/// A nought space.
		/// </summary>
		Nought,

		/// <summary>
		/// A cross space.
		/// </summary>
		Cross
	}
	#endregion

	/// <summary>
	/// Defines a interface for a Tic Tac Toe board.
	/// </summary>
	public interface ITicTacToeBoard
	{
		#region Methods
		/// <summary>
		/// Gets the spaces.
		/// </summary>
		/// <returns>A matrix with the board spaces.</returns>
		[SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Return")]
		ITicTacToeBoardSpace[,] GetSpaces();        
		#endregion
	}
}
