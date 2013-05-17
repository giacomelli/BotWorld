using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.Environments.Games.TicTacToeSdk;
using DG.BotWorld.BotSdk;
using System.ComponentModel.Composition;

namespace DG.BotWorld.Bots.GuardianBot.Abilities.Games.TicTacToe
{
	/// <summary>
	/// The Guardian bot's Tic Tac Toe ability implementation.
	/// </summary>
	[Export(typeof(IBotAbility))]
	public class Ability : ITicTacToeBotAbility
	{
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
			var spaces = context.Board.GetSpaces();

			// If center space is empty, use it.
			if (spaces[1, 1].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(1, 1);
			}

			// If any corners spaces is empty.
			if (spaces[0, 0].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(0, 0);
			}

			if (spaces[0, 2].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(0, 2);
			}

			if (spaces[2, 0].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(2, 0);
			}

			if (spaces[2, 2].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(2, 2);
			}

			// If any non corners spaces is empty.
			if (spaces[0, 1].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(0, 1);
			}

			if (spaces[1, 2].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(1, 2);
			}

			if (spaces[2, 1].SpaceType == SpaceType.Empty)
			{
				return new TicTacToeBotPlayTurnResult(2, 1);
			}

			return new TicTacToeBotPlayTurnResult(1, 0);  
		}
		#endregion
	}
}
