using System;
using System.ComponentModel.Composition;
using System.Globalization;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.TicTacToe.Resources;
using DG.BotWorld.Environments.Games.TicTacToeSdk;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Environments.Games.TicTacToe
{
	/// <summary>
	/// A Tic Tac Toe environment.
	/// </summary>
	[Export(typeof(IEnvironment))]
	public class TicTacToeEnvironment : EnvironmentBase
	{
		#region Fields
		private TicTacToeBoard m_board;
		
		private IBot m_noughtBot;
		private ITicTacToeBotAbility m_noughtBotAbility;
		private TicTacToeEnvironmentContext m_noughtBotEnviromentContext;

		private IBot m_crossBot;
		private ITicTacToeBotAbility m_crossBotAbility;
		private TicTacToeEnvironmentContext m_crossBotEnviromentContext;

		private TicTacToeEnvironmentUpdateResult m_upateResult;

		private ITicTacToeBoardSpace[] m_winnerSpaces;

		private BotRank[] m_botsRanking;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="TicTacToeEnvironment"/> instance.
		/// </summary>
		public TicTacToeEnvironment()
		{
			Name = "Tic Tac Toe";
			Description = "A classic Tic Tac Toe where two bots can play.";
			UIInformation = new EnvironmentUIInformation(TicTacToeEnvironmentResource.Avatar);
			MinBotsNumber = 2;
			MaxBotsNumber = 2;
			MaxUpdateCycles = 5;
			UpdateTimeout = 500;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the board.
		/// </summary>
		public ITicTacToeBoard Board
		{
			get
			{
				return m_board;
			}
		}

		/// <summary>
		/// Gets the cross bot.
		/// </summary>
		public IBot CrossBot
		{
			get
			{
				return m_crossBot;
			}
		}

		/// <summary>
		/// Gets the nought bot.
		/// </summary>
		public IBot NoughtBot
		{
			get
			{
				return m_noughtBot;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Initializes the environment using the world context specified.
		/// </summary>
		/// <param name="context">The world context.</param>
		public override void  Initialize(IWorldContext context)
		{
			m_board = new TicTacToeBoard();
		}

		/// <summary>
		/// Initializes the round.
		/// </summary>
		/// <param name="context">The world context.</param>
		public override void InitializeRound(IWorldContext context)
		{
			m_board = new TicTacToeBoard();
			m_noughtBotEnviromentContext = new TicTacToeEnvironmentContext();
			m_crossBotEnviromentContext = new TicTacToeEnvironmentContext();
			m_upateResult = new TicTacToeEnvironmentUpdateResult();

			var bots = context.GetBotsWithKindOfAbility<ITicTacToeBotAbility>();
			m_crossBot = bots[0];
			m_crossBotAbility = (ITicTacToeBotAbility)context.GetBotAbility<ITicTacToeBotAbility>(m_crossBot);
			m_crossBotEnviromentContext.Board = m_board;
			m_crossBotEnviromentContext.MySpaceType = SpaceType.Cross;
			m_crossBotEnviromentContext.OpponentSpaceType = SpaceType.Nought;

			m_noughtBot = bots[1];
			m_noughtBotAbility = (ITicTacToeBotAbility)context.GetBotAbility<ITicTacToeBotAbility>(m_noughtBot);
			m_noughtBotEnviromentContext.Board = m_board;
			m_noughtBotEnviromentContext.MySpaceType = SpaceType.Nought;
			m_noughtBotEnviromentContext.OpponentSpaceType = SpaceType.Cross;

			m_winnerSpaces = new ITicTacToeBoardSpace[0];
		}

		/// <summary>
		/// Updates the environment (run a cycle).
		/// </summary>
		/// <param name="context">The world context.</param>
		public override void Update(IWorldContext context)
		{
			Play(m_crossBot, m_crossBotAbility, m_crossBotEnviromentContext);

			if (HasWinner())
			{
				MakeBotsRank(m_crossBot, m_noughtBot, false, context.Cycle);
				return;
			}

			if (IsDrawn())
			{
				MakeBotsRank(m_crossBot, m_noughtBot, true, context.Cycle);
				return;
			}

			Play(m_noughtBot, m_noughtBotAbility, m_noughtBotEnviromentContext);

			if (HasWinner())
			{
				MakeBotsRank(m_noughtBot, m_crossBot, false, context.Cycle);
				return;
			}

			if (IsDrawn())
			{
				MakeBotsRank(m_noughtBot, m_crossBot, true, context.Cycle);
				return;
			}
		}

		/// <summary>
		/// Gets the winner spaces.
		/// </summary>
		/// <returns></returns>
		public ITicTacToeBoardSpace[] GetWinnerSpaces()
		{
			return m_winnerSpaces;
		}

		/// <summary>
		/// Gets the abilities needed for a bot to get in the environment.
		/// </summary>
		/// <returns>
		/// The abilities types.
		/// </returns>
		public override Type[] GetNeededBotAbilities()
		{
			return new Type[] { typeof(ITicTacToeBotAbility) };
		}

		/// <summary>
		/// Gets the current bots ranks.
		/// </summary>
		/// <returns>
		/// The bots ranks.
		/// </returns>
		public override BotRank[] GetBotsRanking()
		{
			return m_botsRanking;
		}
		#endregion

		#region Private methods
		private void MakeBotsRank(IBot firstBot, IBot secondBot, bool isDraw, int cycle)
		{
			float firstScore = 0;

			if (isDraw)
			{
				firstScore = 0;
			}
			else
			{
				switch (cycle)
				{
					case 3:
						firstScore = 1;
						break;

					case 4:
						firstScore = 0.75f;
						break;

					case 5:
						firstScore = 0.5f;
						break;
				}
			}

			var firstRank = new BotRank(firstBot, firstScore);
			var secondRank = new BotRank(secondBot, 0);

			m_botsRanking = new BotRank[] { firstRank, secondRank };
		}

		private void Play(IBot bot, ITicTacToeBotAbility botAbility, ITicTacToeEnvironmentContext context)
		{
			var spaces = m_board.GetSpaces();

			var p = botAbility.PlayTurn(context);

			if (spaces[p.RowIndex, p.ColumnIndex].SpaceType == SpaceType.Empty)
			{
				m_board.SetSpace(p.RowIndex, p.ColumnIndex, context.MySpaceType);
				return;
			}
			else
			{
				var msg = String.Format(CultureInfo.CurrentUICulture, "O bot '{0}' executou uma atualização inválida. Tentativa de jogar na linha {1} e coluna {2}.", bot.Name, p.RowIndex, p.ColumnIndex);
				throw new InvalidOperationException(msg);
			}
		}

		private bool HasWinner()
		{
			var spaces = m_board.GetSpaces();

			#region By row
			// XXX
			// ...
			// ...
			if (AreAllEqual(spaces[0, 0], spaces[0, 1], spaces[0, 2]))
			{
				return true;
			}

			// ...
			// XXX
			// ...                        
			if (AreAllEqual(spaces[1, 0], spaces[1, 1], spaces[1, 2]))
			{
				return true;
			}

			// ...
			// ...
			// XXX                        
			if (AreAllEqual(spaces[2, 0], spaces[2, 1], spaces[2, 2]))
			{
				return true;
			}
			#endregion

			#region By column
			// X..
			// X..
			// X..                        
			if (AreAllEqual(spaces[0, 0], spaces[1, 0], spaces[2, 0]))
			{
				return true;
			}

			// .X.
			// .X.
			// .X.
			if (AreAllEqual(spaces[0, 1], spaces[1, 1], spaces[2, 1]))
			{
				return true;
			}

			// ..X
			// ..X
			// ..X
			if (AreAllEqual(spaces[0, 2], spaces[1, 2], spaces[2, 2]))
			{
				return true;
			}
			#endregion

			#region By diagonal
			// X..
			// .X.
			// ..X
			if (AreAllEqual(spaces[0, 0], spaces[1, 1], spaces[2, 2]))
			{
				return true;
			}

			// ..X
			// .X.
			// X..
			if (AreAllEqual(spaces[0, 2], spaces[1, 1], spaces[2, 0]))
			{
				return true;
			}
			#endregion

			return false;
		}

		private bool IsDrawn()
		{
			var spaces = m_board.GetSpaces();

			for (int r = 0; r < 3; r++)
			{
				for (int c = 0; c < 3; c++)
				{
					if (spaces[r, c].SpaceType == SpaceType.Empty)
					{
						return false;
					}
				}
			}

			if (HasWinner())
			{
				return false;
			}
			else
			{
				m_upateResult.IsDrawn = true;
				State = EnvironmentState.Finished;
				return true;
			}
		}

		private bool AreAllEqual(ITicTacToeBoardSpace first, ITicTacToeBoardSpace second, ITicTacToeBoardSpace third)
		{
			var equals = first.SpaceType != SpaceType.Empty && first.SpaceType == second.SpaceType && first.SpaceType == third.SpaceType;

			if (equals)
			{
				if (m_crossBotEnviromentContext.MySpaceType == first.SpaceType)
				{
					m_upateResult.Winner = m_crossBot;
				}
				else
				{
					m_upateResult.Winner = m_noughtBot;
				}

				m_winnerSpaces = new ITicTacToeBoardSpace[] { first, second, third };
				State = EnvironmentState.Finished;
			}

			return equals;
		}		
		#endregion
	}
}
