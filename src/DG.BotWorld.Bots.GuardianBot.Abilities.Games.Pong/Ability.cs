#region Usings
using System.ComponentModel.Composition;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.PongSdk;
#endregion

namespace DG.BotWorld.Bots.GuardianBot.Abilities.Games.Pong
{
	/// <summary>
	/// Sample implementation of DG.BotWorld.Environments.Games.PongSdk.IPongBotAbility ability.
	/// Bot needs this ability to run on DG.BotWorld.Environments.Games.Pong environment.
	/// </summary>
	[Export(typeof(IBotAbility))] // This MEF's attribute is required, otherwise Bot World can't see the ability.
	public class Ability : IPongBotAbility
	{

		#region IPongBotAbility Members
		/// <summary>
		/// Moves the paddle.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		public PaddleMoveDirection MovePaddle(IPongEnvironmentContext context)
		{
			if (context.MyPaddleY > context.BallY)
			{
				return PaddleMoveDirection.Up;
			}
			else if (context.MyPaddleY < context.BallY)
			{
				return PaddleMoveDirection.Down;
			}
			else
			{
				return PaddleMoveDirection.Stop;
			}
		}

		#endregion

		#region IBotAbility Members
		/// <summary>
		/// Performs ability's initialization.
		/// </summary>
		/// <param name="context">The environment context.</param>
		public void Initialize(IEnvironmentContext context)
		{
			
		}
		#endregion
	}
}
