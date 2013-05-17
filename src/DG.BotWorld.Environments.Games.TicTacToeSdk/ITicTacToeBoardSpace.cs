
namespace DG.BotWorld.Environments.Games.TicTacToeSdk
{
	/// <summary>
	/// Defines a interface for a Tic Tac Toe board space.
	/// </summary>
	public interface ITicTacToeBoardSpace
	{
		#region Properties
		/// <summary>
		/// Gets the type of the space.
		/// </summary>
		/// <value>
		/// The type of the space.
		/// </value>
		SpaceType SpaceType
		{
			get;            
		}

		/// <summary>
		/// Gets the index of the column.
		/// </summary>
		/// <value>
		/// The index of the column.
		/// </value>
		int ColumnIndex
		{
			get;
		}

		/// <summary>
		/// Gets the index of the row.
		/// </summary>
		/// <value>
		/// The index of the row.
		/// </value>
		int RowIndex
		{
			get;
		}
		#endregion
	}
}
