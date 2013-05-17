using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.TicTacToeSdk;

namespace DG.BotWorld.Bots.HalBot.Abilities.Games.TicTacToe
{
	/// <summary>
	/// The Hal bot's Tic Tac Toe ability implementation.
	/// </summary>
	[Export(typeof(IBotAbility))]
	public class Ability : ITicTacToeBotAbility
	{
		#region Fields
		[SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member")]
		private ITicTacToeBoardSpace[,] m_spaces;
		#endregion

		#region IBotAbility Members
		/// <summary>
		/// Performs ability's initialization.
		/// </summary>
		/// <param name="context">The environment context.</param>
		public void Initialize(IEnvironmentContext context)
		{
			
		}

		/// <summary>
		/// Play a turn on the board.
		/// </summary>
		/// <param name="context">The Tic Tac Toe environment's context.</param>
		/// <returns>
		/// The play turn result.
		/// </returns>
		public TicTacToeBotPlayTurnResult PlayTurn(ITicTacToeEnvironmentContext context)
		{
			m_spaces = context.Board.GetSpaces();

			// If has a victory space to play.
			var result = CheckVictorySpace(context.MySpaceType);
			
			if (result != null)
			{
				return result;
			}

			// If need to block a opponent victory space.
			result = CheckVictorySpace(context.OpponentSpaceType);

			if (result != null)
			{
				return result;
			}

			// If center space is empty, use it.
			result = CheckCenterSpace();

			if (result != null)
			{
				return result;
			}

			// If any corners spaces is empty.
			result = CheckCornerSpaces();
			
			if (result != null)
			{
				return result;
			}

			// If any non corners spaces is empty.
			return CheckNonCornerSpaces();

					   
		}

		private TicTacToeBotPlayTurnResult CheckVictorySpace(SpaceType victorySpaceType)
		{
			#region By row
			// XXX
			// ...
			// ...
			var result = GetVictorySpace(victorySpaceType, m_spaces[0, 0], m_spaces[0, 1], m_spaces[0, 2]);
			if (result != null)
			{
				return result;
			}

			// ...
			// XXX
			// ...  
			result = GetVictorySpace(victorySpaceType, m_spaces[1, 0], m_spaces[1, 1], m_spaces[1, 2]);
			if (result != null)
			{
				return result;
			}

			// ...
			// ...
			// XXX  
			result = GetVictorySpace(victorySpaceType, m_spaces[2, 0], m_spaces[2, 1], m_spaces[2, 2]);
			if (result != null)
			{
				return result;
			}
			#endregion

			#region By column
			// X..
			// X..
			// X..   
			result = GetVictorySpace(victorySpaceType, m_spaces[0, 0], m_spaces[1, 0], m_spaces[2, 0]);  
			if (result != null)
			{
				return result;
			}

			// .X.
			// .X.
			// .X.
			result = GetVictorySpace(victorySpaceType, m_spaces[0, 1], m_spaces[1, 1], m_spaces[2, 1]);
			if (result != null)
			{
				return result;
			}

			// ..X
			// ..X
			// ..X
			result = GetVictorySpace(victorySpaceType, m_spaces[0, 2], m_spaces[1, 2], m_spaces[2, 2]);
			if (result != null)
			{
				return result;
			}
			#endregion

			#region By diagonal
			// X..
			// .X.
			// ..X
			result = GetVictorySpace(victorySpaceType, m_spaces[0, 0], m_spaces[1, 1], m_spaces[2, 2]); 
			if (result != null)
			{
				return result;
			}

			// ..X
			// .X.
			// X..
			result = GetVictorySpace(victorySpaceType, m_spaces[0, 2], m_spaces[1, 1], m_spaces[2, 0]); 
			if (result != null)
			{
				return result;
			}
			#endregion

			return null;
		}

		private static TicTacToeBotPlayTurnResult GetVictorySpace(SpaceType victorySpaceType, ITicTacToeBoardSpace first, ITicTacToeBoardSpace second, ITicTacToeBoardSpace third)
		{
			int count = 0;
			TicTacToeBotPlayTurnResult victoryResult = null;

			if (first.SpaceType == victorySpaceType)
			{
				count++;
			}
			else if(first.SpaceType == SpaceType.Empty)
			{
				victoryResult = new TicTacToeBotPlayTurnResult(first.RowIndex, first.ColumnIndex);
			}

			if (second.SpaceType == victorySpaceType)
			{
				count++;
			}
			else if (second.SpaceType == SpaceType.Empty)
			{
				victoryResult = new TicTacToeBotPlayTurnResult(second.RowIndex, second.ColumnIndex);
			}

			if (third.SpaceType == victorySpaceType)
			{
				count++;
			}
			else if (third.SpaceType == SpaceType.Empty)
			{
				victoryResult = new TicTacToeBotPlayTurnResult(third.RowIndex, third.ColumnIndex);
			}

			if (count == 2)
			{
				return victoryResult;
			}

			return null;
		}

		private TicTacToeBotPlayTurnResult CheckNonCornerSpaces()
		{
			if (m_spaces[0, 1].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(0, 1);
			}

			if (m_spaces[1, 2].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(1, 2);
			}

			if (m_spaces[2, 1].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(2, 1);
			}

			return new TicTacToeBotPlayTurnResult(1, 0); 
		}        

		private TicTacToeBotPlayTurnResult CheckCenterSpace()
		{
			if (m_spaces[1, 1].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(1, 1);
			}

			return null;
		}

		private TicTacToeBotPlayTurnResult CheckCornerSpaces()
		{
			if (m_spaces[0, 0].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(0, 0);
			}

			if (m_spaces[0, 2].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(0, 2);
			}

			if (m_spaces[2, 0].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(2, 0);
			}

			if (m_spaces[2, 2].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(2, 2);
			}

			return null;
		}
		#endregion
	}
}
