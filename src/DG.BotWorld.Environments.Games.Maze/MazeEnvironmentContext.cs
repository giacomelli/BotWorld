using System.Diagnostics.CodeAnalysis;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.MazeSdk;

namespace DG.BotWorld.Environments.Games.Maze
{
	/// <summary>
	/// A Maze environment context.
	/// </summary>
	public class MazeEnvironmentContext : EnvironmentContextBase, IMazeEnvironmentContext
	{
		#region Fields
		[SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member")]
		private MazeCell[,] m_map;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="MazeEnvironmentContext"/> instance.
		/// </summary>
		/// <param name="environmentMap">The environment map.</param>
		public MazeEnvironmentContext(MazeCell[,] environmentMap)
		{
			m_map = (MazeCell[,])environmentMap.Clone();
		}
		#endregion

		#region IMazeEnvironmentContext Members
		/// <summary>
		/// Determines whether the bot can walk to the specified direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <returns>
		///   <c>true</c> if the bot can walk to the specified direction; otherwise, <c>false</c>.
		/// </returns>
		public bool CanWalkTo(WalkDirection direction)
		{
			var cell = m_map[MyCell.Y, MyCell.X];

			switch (direction)
			{
				case WalkDirection.Up:
					return cell.TopSide == CellSideType.Free;

				case WalkDirection.Left:
					return cell.LeftSide == CellSideType.Free;

				case WalkDirection.Right:
					if (cell.X == m_map.GetUpperBound(1))
					{
						return false;
					}
					return GetMyNextCellFrom(direction).LeftSide == CellSideType.Free;

				case WalkDirection.Down:
					if (cell.Y == m_map.GetUpperBound(0))
					{
						return false;
					}

					return GetMyNextCellFrom(direction).TopSide == CellSideType.Free;
			}

			return false;
		}
		#endregion

		#region Private methods
		private MazeCell GetMyNextCellFrom(WalkDirection direction)
		{
			switch (direction)
			{
				case WalkDirection.Down:
					return MyDownCell;

				case WalkDirection.Left:
					return MyLeftCell;

				case WalkDirection.Right:
					return MyRightCell;

				default:
					return MyTopCell;
			}
		}
	  
		internal void SetCellState(int rowIndex, int columnIndex, CellState state)
		{
			var space = m_map[rowIndex, columnIndex];
			space.State = state;

			if (state == CellState.Visited)
			{
				space.OccupiedByBot = null;
			}
		}

		internal MazeCell MyCell
		{
			get;
			set;
		}

		private MazeCell MyTopCell
		{
			get
			{
				return m_map[MyCell.Y - 1, MyCell.X];
			}
		}

		private MazeCell MyRightCell
		{
			get
			{
				return m_map[MyCell.Y, MyCell.X + 1];
			}           
		}

		private MazeCell MyDownCell
		{
			get
			{
				return m_map[MyCell.Y + 1, MyCell.X];
			}
		}

		private MazeCell MyLeftCell
		{
			get
			{
				return m_map[MyCell.Y, MyCell.X - 1];
			}           
		}
		#endregion
	}
}
