using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.MazeSdk;

namespace DG.BotWorld.Bots.HalBot.Abilities.Games.Maze
{
	/// <summary>
	/// The Hal bot's Maze ability implementation.
	/// </summary>
	[Export(typeof(IBotAbility))]
	public class Ability : IMazeBotAbility
	{
		#region Fields
		private Dictionary<MazeCell, long> m_visitedCells;
		private MazeCell m_myCell;
		#endregion

		#region IBotAbility Members

		/// <summary>
		/// Performs ability's initialization.
		/// </summary>
		/// <param name="context">The environment context.</param>
		public void Initialize(IEnvironmentContext context)
		{
			m_visitedCells = new Dictionary<MazeCell, long>();
			m_myCell = new MazeCell(0, 0);
		}

		/// <summary>
		/// Choose the walk direction.
		/// </summary>
		/// <param name="context">The maze environment's context.</param>
		/// <returns>
		/// The walk diretion choosen.
		/// </returns>
		public WalkDirection Walk(IMazeEnvironmentContext context)
		{
			SetVisitedCell();

			var result = GetResult(context, true);

			if (!result.HasValue)
			{
				var aroundVisitedCells = new Dictionary<MazeCell, long>();
				var s = m_myCell;


				var aroundCell = GetVisitedAroundCell(WalkDirection.Up);

				if (context.CanWalkTo(WalkDirection.Up))
				{
					if (aroundCell.Key == null)
					{
						return PrepareResult(WalkDirection.Up);
					}

					if (aroundCell.Key != null)
					{
						aroundVisitedCells.Add(aroundCell.Key, aroundCell.Value);
					}
				}

				if (context.CanWalkTo(WalkDirection.Right))
				{
					aroundCell = GetVisitedAroundCell(WalkDirection.Right);

					if (aroundCell.Key == null)
					{
						return PrepareResult(WalkDirection.Right);
					}

					if (aroundCell.Key != null)
					{
						aroundVisitedCells.Add(aroundCell.Key, aroundCell.Value);
					}
				}

				if (context.CanWalkTo(WalkDirection.Down))
				{
					aroundCell = GetVisitedAroundCell(WalkDirection.Down);

					if (aroundCell.Key == null)
					{
						return PrepareResult(WalkDirection.Down);
					}
					if (aroundCell.Key != null)
					{
						aroundVisitedCells.Add(aroundCell.Key, aroundCell.Value);
					}
				}

				if (context.CanWalkTo(WalkDirection.Left))
				{
					aroundCell = GetVisitedAroundCell(WalkDirection.Left);

					if (aroundCell.Key == null)
					{
						return PrepareResult(WalkDirection.Left);
					}

					if (aroundCell.Key != null)
					{
						aroundVisitedCells.Add(aroundCell.Key, aroundCell.Value);
					}
				}
				
				var futureCellEntry = aroundVisitedCells.OrderBy(a => a.Value).FirstOrDefault();

				if (futureCellEntry.Key == null)
				{
					return PrepareResult(GetResult(context, false));                    
				}

				var futureCell = futureCellEntry.Key;

				if (futureCell.Y == s.Y - 1 && futureCell.X == s.X && context.CanWalkTo(WalkDirection.Up))
				{
					return PrepareResult(WalkDirection.Up);
				}
				else if (futureCell.Y == s.Y && futureCell.X == s.X + 1 && context.CanWalkTo(WalkDirection.Right))
				{
					return PrepareResult(WalkDirection.Right);
				}
				else if (futureCell.Y == s.Y + 1 && futureCell.X == s.X && context.CanWalkTo(WalkDirection.Down))
				{
					return PrepareResult(WalkDirection.Down);
				}
				else if (futureCell.Y == s.Y && futureCell.X == s.X - 1 && context.CanWalkTo(WalkDirection.Left))
				{
					return PrepareResult(WalkDirection.Left);
				}
			}                        

			return PrepareResult(result);
		}

		private WalkDirection PrepareResult(WalkDirection? direction)
		{
			m_myCell = GetNewAroundCell(direction.Value);
			return direction.Value;
		}

		private KeyValuePair<MazeCell, long> GetVisitedAroundCell(WalkDirection direction)
		{
			var aroundCell = GetNewAroundCell(direction);

			var query = from vs in m_visitedCells
						where vs.Key.Equals(aroundCell)
						select vs;

			return query.FirstOrDefault();
		}

		private MazeCell GetNewAroundCell(WalkDirection direction)
		{
			var aroundCell = new MazeCell(m_myCell.X, m_myCell.Y);

			switch (direction)
			{
				case WalkDirection.Down:
					aroundCell.Y++;
					break;

				case WalkDirection.Left:
					aroundCell.X--;
					break;

				case WalkDirection.Right:
					aroundCell.X++;
					break;

				case WalkDirection.Up:
					aroundCell.Y--;
					break;
			}

			return aroundCell;
		}

		private void SetVisitedCell()
		{                      
			m_visitedCells[m_myCell] = DateTime.Now.Ticks;
		}

		private bool HasBeenVisited(WalkDirection direction)
		{
			return m_visitedCells.ContainsKey(GetNewAroundCell(direction));
		}

		private WalkDirection? GetResult(IMazeEnvironmentContext ctx, bool onlyNotVisited)
		{            
			if (ctx.CanWalkTo(WalkDirection.Up) && (!onlyNotVisited || !HasBeenVisited(WalkDirection.Up)))
			{
				return WalkDirection.Up;
			}

			if (ctx.CanWalkTo(WalkDirection.Right) && (!onlyNotVisited || !HasBeenVisited(WalkDirection.Right)))
			{
				return WalkDirection.Right;
			}

			if (ctx.CanWalkTo(WalkDirection.Down) && (!onlyNotVisited || !HasBeenVisited(WalkDirection.Down)))
			{
				return WalkDirection.Down;
			}

			if (ctx.CanWalkTo(WalkDirection.Left) && (!onlyNotVisited || !HasBeenVisited(WalkDirection.Left)))
			{
				return WalkDirection.Left;
			}

			return null;
		}

		#endregion
	}
}
