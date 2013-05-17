
namespace DG.BotWorld.Environments.Games.TicTacToeSdk
{
	/// <summary>
	/// A result for a bot play turn.
	/// </summary>
	public class TicTacToeBotPlayTurnResult
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="TicTacToeBotPlayTurnResult"/> instance.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="columnIndex">Index of the column.</param>
		public TicTacToeBotPlayTurnResult(int rowIndex, int columnIndex)
		{            
			RowIndex = rowIndex;
			ColumnIndex = columnIndex;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the index of the column.
		/// </summary>
		/// <value>
		/// The index of the column.
		/// </value>
		public int ColumnIndex
		{
			get;
			private set;
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
			private set;
		}
		#endregion
	}
}
