using System;
using System.Diagnostics;
using System.Globalization;

namespace DG.BotWorld.Bots.HalBot.Abilities.Games.Maze
{
	/// <summary>
	/// Represents the way that Hal Bot understand a maze cell.
	/// </summary>
	[DebuggerDisplay("X: {X}, Y: {Y}")]
	public class MazeCell : IEquatable<MazeCell>, IComparable<MazeCell>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="MazeCell"/> instance.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		public MazeCell(int x, int y)
		{
			X = x;
			Y = y;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the X coordinate
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
			return GetHashCode().Equals(other.GetHashCode());
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
			return GetHashCode().Equals(obj.GetHashCode());
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return String.Format(CultureInfo.InvariantCulture, "{0}_{1}", X, Y).GetHashCode();
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
			return GetHashCode() - other.GetHashCode();
		}
		#endregion

		//#region Operators
		///// <summary>
		///// Implements the operator ==.
		///// </summary>
		///// <param name="firstCell">The first cell.</param>
		///// <param name="secondCell">The second cell.</param>
		///// <returns>
		///// The result of the operator.
		///// </returns>
		//public static bool operator == (MazeCell firstCell, MazeCell secondCell)
		//{
		//    return firstCell.Equals(secondCell);
		//}

		///// <summary>
		///// Implements the operator !=.
		///// </summary>
		///// <param name="firstCell">The first cell.</param>
		///// <param name="secondCell">The second cell.</param>
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
		//public static bool operator >(MazeCell firstCell, MazeCell secondCell)
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
		//public static bool operator <(MazeCell firstCell, MazeCell secondCell)
		//{
		//    return firstCell.CompareTo(secondCell) < 0;
		//}
		//#endregion
	}
}
