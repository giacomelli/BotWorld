using System.Diagnostics;
using DG.BotWorld.Environments.Games.TicTacToeSdk;

namespace DG.BotWorld.Environments.Games.TicTacToe
{    
	/// <summary>
	/// A Tic Tac Toe board space.
	/// </summary>
	[DebuggerDisplay("({RowIndex},{ColumnIndex}) {SpaceType}")]
	public class TicTacToeBoardSpace : ITicTacToeBoardSpace
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="TicTacToeBoardSpace"/> instance.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="columnIndex">Index of the column.</param>
		public TicTacToeBoardSpace(int rowIndex, int columnIndex)
		{
			SpaceType = SpaceType.Empty;
			ColumnIndex = columnIndex;
			RowIndex = rowIndex;
		}
		#endregion

		#region ITicTacToeBoardSpace Members
		/// <summary>
		/// Gets the type of the space.
		/// </summary>
		/// <value>
		/// The type of the space.
		/// </value>
		public SpaceType SpaceType
		{
			get;
			set;            
		}

		/// <summary>
		/// Gets the index of the column.
		/// </summary>
		/// <value>
		/// The index of the column.
		/// </value>
		public int ColumnIndex
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the index of the row.
		/// </summary>
		/// <value>
		/// The index of the row.
		/// </value>
		public int RowIndex
		{
			get;
			set;
		}

		#endregion
	}
}
