#region Usings
using System;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using DG.BotWorld.BotSdk;
#endregion

namespace DG.BotWorld.Environments.Games.Maze
{
	#region Enumerations
	/// <summary>
	/// A maze cell state.
	/// </summary>
	public enum CellState
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		Unknown,

		/// <summary>
		/// Cell visited.
		/// </summary>
		Visited,

		/// <summary>
		/// Cell occupied.
		/// </summary>
		Occupied,

		/// <summary>
		/// Cell is the target.
		/// </summary>
		Target        
	}

	/// <summary>
	/// A maze cell type.
	/// </summary>
	public enum CellSideType
	{
		/// <summary>
		/// Side is a wall.
		/// </summary>
		Wall,

		/// <summary>
		/// Side is free.
		/// </summary>
		Free
	}
	#endregion

	/// <summary>
	/// A single maze cell.
	/// </summary>
	[DebuggerDisplay("({RowIndex},{ColumnIndex}) {State}")]
	public class MazeCell : IEquatable<MazeCell>, IComparable<MazeCell>, IComparable, IComparer
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="MazeCell"/> instance.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="columnIndex">Index of the column.</param>
		public MazeCell(int rowIndex, int columnIndex)
		{
			State = CellState.Unknown;
			X = columnIndex;
			Y = rowIndex;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		public CellState State
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the top side.
		/// </summary>
		/// <value>
		/// The top side.
		/// </value>
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "TopSide")]
		public CellSideType TopSide
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the right side.
		/// </summary>
		/// <value>
		/// The right side.
		/// </value>
		public CellSideType RightSide
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the bottom side.
		/// </summary>
		/// <value>
		/// The bottom side.
		/// </value>
		public CellSideType BottomSide
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the left side.
		/// </summary>
		/// <value>
		/// The left side.
		/// </value>
		public CellSideType LeftSide
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Y coordinate.
		/// </summary>
		/// <value>
		/// The Y.
		/// </value>
		public int Y
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the X coordinate.
		/// </summary>
		/// <value>
		/// The X.
		/// </value>
		public int X
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the bot that is occuping the cell.
		/// </summary>
		/// <value>
		/// The occupied by bot.
		/// </value>
		public IBot OccupiedByBot
		{
			get;
			set;
		}

		#endregion

		#region IEquatable<MazeCell> Members
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="other">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="T:System.NullReferenceException">
		/// The <paramref name="other"/> parameter is null.
		///   </exception>
		public bool Equals(MazeCell other)
		{
			return other.Y == Y && other.X == X;
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="T:System.NullReferenceException">
		/// The <paramref name="obj"/> parameter is null.
		///   </exception>
		public override bool Equals(object obj)
		{
			return Equals((MazeCell)obj);
		}
		#endregion

		#region IComparable<MazeCell> Members
		/// <summary>
		/// Compares to.
		/// </summary>
		/// <param name="other">The other.</param>
		/// <returns></returns>
		public int CompareTo(MazeCell other)
		{
			if (other.Y < Y || other.X < X)
			{
				return -1;
			}

			if (other.Y > Y || other.X > X)
			{
				return 1;
			}

			return 0;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return String.Format(CultureInfo.InvariantCulture, "{0}_{1}", Y, X).GetHashCode();            
		}
		#endregion

		#region IComparable Members
		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings:
		/// Value
		/// Meaning
		/// Less than zero
		/// This instance is less than <paramref name="obj"/>.
		/// Zero
		/// This instance is equal to <paramref name="obj"/>.
		/// Greater than zero
		/// This instance is greater than <paramref name="obj"/>.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="obj"/> is not the same type as this instance.
		///   </exception>
		public int CompareTo(object obj)
		{
			return CompareTo((MazeCell)obj);
		}

		#endregion

		#region IComparer Members

		/// <summary>
		/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
		/// </summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns>
		/// Value
		/// Condition
		/// Less than zero
		/// <paramref name="x"/> is less than <paramref name="y"/>.
		/// Zero
		/// <paramref name="x"/> equals <paramref name="y"/>.
		/// Greater than zero
		/// <paramref name="x"/> is greater than <paramref name="y"/>.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">
		/// Neither <paramref name="x"/> nor <paramref name="y"/> implements the <see cref="T:System.IComparable"/> interface.
		/// -or-
		///   <paramref name="x"/> and <paramref name="y"/> are of different types and neither one can handle comparisons with the other.
		///   </exception>
		public int Compare(object x, object y)
		{
			return ((MazeCell)x).CompareTo((MazeCell)y);
		}

		#endregion

		//#region Operators
		///// <summary>
		///// Implements the operator ==.
		///// </summary>
		///// <param name="firstCell">The c1.</param>
		///// <param name="secondCell">The c2.</param>
		///// <returns>
		///// The result of the operator.
		///// </returns>
		//public static bool operator ==(MazeCell firstCell, MazeCell secondCell)
		//{
		//    return firstCell.Equals(secondCell);
		//}

		///// <summary>
		///// Implements the operator !=.
		///// </summary>
		///// <param name="firstCell">The c1.</param>
		///// <param name="secondCell">The c2.</param>
		///// <returns>
		///// The result of the operator.
		///// </returns>
		//public static bool operator !=(MazeCell firstCell, MazeCell secondCell)
		//{
		//    return !firstCell.Equals(secondCell);
		//}

		///// <summary>
		///// Implements the operator &gt;.
		///// </summary>
		///// <param name="firstCell">The first cell.</param>
		///// <param name="secondCell">The second cell.</param>
		///// <returns>
		///// The result of the operator.
		///// </returns>
		//public static bool operator > (MazeCell firstCell, MazeCell secondCell)
		//{
		//    return firstCell.CompareTo(secondCell) > 0;
		//}

		///// <summary>
		///// Implements the operator &lt;.
		///// </summary>
		///// <param name="firstCell">The first cell.</param>
		///// <param name="secondCell">The second cell.</param>
		///// <returns>
		///// The result of the operator.
		///// </returns>
		//public static bool operator < (MazeCell firstCell, MazeCell secondCell)
		//{
		//    return firstCell.CompareTo(secondCell) < 0;
		//}
		//#endregion
	}
}
