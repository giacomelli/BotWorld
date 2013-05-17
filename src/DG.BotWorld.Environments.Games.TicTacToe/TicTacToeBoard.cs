using System.Diagnostics.CodeAnalysis;
using DG.BotWorld.Environments.Games.TicTacToeSdk;

namespace DG.BotWorld.Environments.Games.TicTacToe
{
	/// <summary>
	/// A Tic Tac Toe board.
	/// </summary>
	public class TicTacToeBoard : ITicTacToeBoard
	{
		#region Fields
		[SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member")]
		private TicTacToeBoardSpace[,] m_spaces = new TicTacToeBoardSpace[3, 3];
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="TicTacToeBoard"/> class.
		/// </summary>
		public TicTacToeBoard()
		{
			m_spaces[0, 0] = new TicTacToeBoardSpace(0, 0);
			m_spaces[0, 1] = new TicTacToeBoardSpace(0, 1);
			m_spaces[0, 2] = new TicTacToeBoardSpace(0, 2);

			m_spaces[1, 0] = new TicTacToeBoardSpace(1, 0);
			m_spaces[1, 1] = new TicTacToeBoardSpace(1, 1);
			m_spaces[1, 2] = new TicTacToeBoardSpace(1, 2);
			
			m_spaces[2, 0] = new TicTacToeBoardSpace(2, 0);
			m_spaces[2, 1] = new TicTacToeBoardSpace(2, 1);
			m_spaces[2, 2] = new TicTacToeBoardSpace(2, 2);
		}
		#endregion

		#region ITicTacToeBoard Members
		/// <summary>
		/// Gets the spaces.
		/// </summary>
		/// <returns>
		/// A matrix with the board spaces.
		/// </returns>
		public ITicTacToeBoardSpace[,] GetSpaces()
		{
			return m_spaces;   
		}

		/// <summary>
		/// Sets the space.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="columnIndex">Index of the column.</param>
		/// <param name="spaceType">Type of the space.</param>
		public void SetSpace(int rowIndex, int columnIndex, SpaceType spaceType)
		{
			m_spaces[rowIndex, columnIndex].SpaceType = spaceType;
		}

		#endregion
	}
}
