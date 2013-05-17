using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.Maze.Resources;
using DG.BotWorld.Environments.Games.MazeSdk;
using DG.BotWorld.EnvironmentSdk;
using DG.Framework.Common;

namespace DG.BotWorld.Environments.Games.Maze
{
	/// <summary>
	/// The Maze environment.
	/// </summary>
	[Export(typeof(IEnvironment))]
	public class MazeEnvironment : EnvironmentBase
	{
		#region Fields
		[SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member")]
		private MazeCell[,] m_map;
		private IBot m_roundBot;
		private IMazeBotAbility m_roundBotAbility;
		private MazeEnvironmentContext m_environmentContext;
		private MazeCell m_bornCell;
		private MazeCell m_targetCell;
		private HashSet<MazeCell> m_visitedCells;
		private BotRank m_botRank;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="MazeEnvironment"/> instance.
		/// </summary>
		public MazeEnvironment()
		{
			Name = "Maze";
			Description = "A maze where bot must find the target.";
			UIInformation = new EnvironmentUIInformation(MazeEnvironmentResource.Avatar);
			MinBotsNumber = 1;
			MaxBotsNumber = 1;
			MaxUpdateCycles = 10000;
			UpdateTimeout = 1000000;
			HorizontalCells = 40;
			VerticalCells = 40;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the number of horizontal cells in the maze.
		/// </summary>
		[Category("Environment")]
		[Description("Number of horizontal cells in the maze.")]
		public int HorizontalCells
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the number of vertical cells in the maze
		/// </summary>
		[Category("Environment")]
		[Description("Number of vertical cells in the maze.")]
		public int VerticalCells
		{
			get;
			private set;
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Initializes the environment using the world context specified.
		/// </summary>
		/// <param name="context">The world context.</param>
		[SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Body")]
		public override void Initialize(IWorldContext context)
		{
			m_visitedCells = new HashSet<MazeCell>();
			m_map = new MazeCell[HorizontalCells, VerticalCells];

			m_targetCell = GetRandomCell(CellState.Target);

			GenerateInternalWalls();
			GenerateMaze(m_map[m_targetCell.Y, m_targetCell.X]);
			GenerateExternalWalls();            

			m_bornCell = GetRandomCell(CellState.Visited);

			while (m_targetCell.Equals(m_bornCell))
			{
				m_bornCell = GetRandomCell(CellState.Visited);
			}

			MarkBornAndTargetCells();
		}

		/// <summary>
		/// Initializes the round.
		/// </summary>
		/// <param name="context">The world context.</param>
		public override void InitializeRound(IWorldContext context)
		{
			MarkAllCellsUnknown();
			MarkBornAndTargetCells();

			m_environmentContext = new MazeEnvironmentContext(m_map);
			m_environmentContext.SetCellState(m_bornCell.Y, m_bornCell.X, CellState.Visited);
			m_environmentContext.MyCell = m_bornCell;

			m_roundBot = context.GetBotsWithKindOfAbility<IMazeBotAbility>()[0];
			m_roundBotAbility = (IMazeBotAbility)context.GetBotAbility<IMazeBotAbility>(m_roundBot);
			m_roundBotAbility.Initialize(m_environmentContext);

			m_botRank = null;
		}

		/// <summary>
		/// Generates the maze.
		/// </summary>
		/// <param name="cell">The cell.</param>
		public void GenerateMaze(MazeCell cell)
		{
			m_visitedCells.Add(cell);
			List<MazeCell> freeNeighbors = new List<MazeCell>();

			do
			{
				freeNeighbors.Clear();

				if (cell.Y > 0)
				{
					var neighborCell = m_map[cell.Y - 1, cell.X];

					if (!m_visitedCells.Contains(neighborCell))
					{
						freeNeighbors.Add(neighborCell);
					}
				}

				if (cell.X < m_map.GetUpperBound(1))
				{
					var neighborCell = m_map[cell.Y, cell.X + 1];

					if (!m_visitedCells.Contains(neighborCell))
					{
						freeNeighbors.Add(neighborCell);
					}
				}

				if (cell.Y < m_map.GetUpperBound(0))
				{
					var neighborCell = m_map[cell.Y + 1, cell.X];

					if (!m_visitedCells.Contains(neighborCell))
					{
						freeNeighbors.Add(neighborCell);
					}
				}

				if (cell.X > 0)
				{
					var neighborCell = m_map[cell.Y, cell.X - 1];

					if (!m_visitedCells.Contains(neighborCell))
					{
						freeNeighbors.Add(neighborCell);
					}
				}

				if (freeNeighbors.Count > 0)
				{
					var randomNeighborIndex = RandomHelper.NextInt(0, freeNeighbors.Count);

					var selectedNeighbor = freeNeighbors[randomNeighborIndex];
					freeNeighbors.RemoveAt(randomNeighborIndex);

					if (selectedNeighbor.Y < cell.Y)
					{
						cell.TopSide = CellSideType.Free;
						selectedNeighbor.BottomSide = CellSideType.Free;
					}
					else if (selectedNeighbor.X > cell.X)
					{
						cell.RightSide = CellSideType.Free;
						selectedNeighbor.LeftSide = CellSideType.Free;
					}
					else if (selectedNeighbor.Y > cell.Y)
					{
						cell.BottomSide = CellSideType.Free;
						selectedNeighbor.TopSide = CellSideType.Free;
					}
					else
					{
						cell.LeftSide = CellSideType.Free;
						selectedNeighbor.RightSide = CellSideType.Free;
					}

					GenerateMaze(selectedNeighbor);
				}

			}
			while (freeNeighbors.Count > 0);
		}

		/// <summary>
		/// Gets the map.
		/// </summary>
		/// <returns></returns>
		[SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Return")]
		public MazeCell[,] GetMap()
		{
			return m_map;
		}

		/// <summary>
		/// Updates the environment (run a cycle).
		/// </summary>
		/// <param name="context">The world context.</param>
		public override void Update(IWorldContext context)
		{
			if (State == EnvironmentState.Running)
			{
				var ctx = m_environmentContext;

				var botWalkDirection = m_roundBotAbility.Walk(ctx);

				if (ctx.CanWalkTo(botWalkDirection))
				{
					var botWishCell = GetBotWishCell(ctx, botWalkDirection);
					var mainMapCell = m_map[botWishCell.Y, botWishCell.X];

					switch (mainMapCell.State)
					{
						case CellState.Occupied:
							ctx.SetCellState(botWishCell.Y, botWishCell.X, mainMapCell.State);
							break;

						case CellState.Target:
							m_botRank = new BotRank(m_roundBot, ((MaxUpdateCycles - context.Cycle) / (float)MaxUpdateCycles));
							State = EnvironmentState.Finished;
							break;

						default:
							mainMapCell.State = CellState.Occupied;
							mainMapCell.OccupiedByBot = m_roundBot;

							mainMapCell = m_map[ctx.MyCell.Y, ctx.MyCell.X];
							mainMapCell.State = CellState.Visited;

							ctx.SetCellState(ctx.MyCell.Y, ctx.MyCell.X, CellState.Visited);
							ctx.SetCellState(botWishCell.Y, botWishCell.X, CellState.Occupied);

							ctx.MyCell = botWishCell;
							break;
					}
				}
			}
		}

		/// <summary>
		/// Gets the abilities needed for a bot to get in the environment.
		/// </summary>
		/// <returns>
		/// The abilities types.
		/// </returns>
		public override Type[] GetNeededBotAbilities()
		{
			return new Type[] { typeof(IMazeBotAbility) };
		}

		/// <summary>
		/// Gets the current bots ranks.
		/// </summary>
		/// <returns>
		/// The bots ranks.
		/// </returns>
		public override BotRank[] GetBotsRanking()
		{
			return new BotRank[] { m_botRank };
		}
		#endregion

		#region Private methods
		private void MarkAllCellsUnknown()
		{
			for (int y = 0; y < VerticalCells; y++)
			{
				for (int x = 0; x < HorizontalCells; x++)
				{
					m_map[y, x].State = CellState.Unknown;
				}
			}
		}

		private void MarkBornAndTargetCells()
		{
			m_map[m_bornCell.Y, m_bornCell.X].State = CellState.Occupied;
			m_map[m_targetCell.Y, m_targetCell.X].State = CellState.Target;
		}						
		
		private void GenerateInternalWalls()
		{
			for (int r = 0; r < HorizontalCells; r++)
			{
				for (int c = 0; c < VerticalCells; c++)
				{
					var cell = new MazeCell(r, c);                     

					m_map[r, c] = cell;
				}                
			}           
		}

		private void GenerateExternalWalls()
		{
			for (int r = 0; r < HorizontalCells; r++)
			{
				for (int c = 0; c < VerticalCells; c++)
				{
					var cell = m_map[r, c];

					if (r == 0)
					{
						cell.TopSide = CellSideType.Wall;
					}
					else if (r == VerticalCells - 1)
					{
						cell.BottomSide = CellSideType.Wall;
					}

					if (c == 0)
					{
						cell.LeftSide = CellSideType.Wall;
					}
					else if (c == HorizontalCells - 1)
					{
						cell.RightSide = CellSideType.Wall;
					}
				} 
			}
		}

		private MazeCell GetRandomCell(CellState state)
		{
			var cell = new MazeCell(RandomHelper.NextInt(1, HorizontalCells - 1), RandomHelper.NextInt(1, VerticalCells - 1));
			cell.State = state;

			return cell;
		}

		private static MazeCell GetBotWishCell(MazeEnvironmentContext ctx, WalkDirection botWalkDirection)
		{
			switch (botWalkDirection)
			{
				case WalkDirection.Down:
					return new MazeCell(ctx.MyCell.Y + 1, ctx.MyCell.X);

				case WalkDirection.Left:
					return new MazeCell(ctx.MyCell.Y, ctx.MyCell.X - 1);

				case WalkDirection.Right:
					return new MazeCell(ctx.MyCell.Y, ctx.MyCell.X + 1);

				default:
					return new MazeCell(ctx.MyCell.Y - 1, ctx.MyCell.X);
			}
		}		
		#endregion						
	}
}
