using System.ComponentModel.Composition;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Environments.Games.PongSdk;

namespace DG.BotWorld.Bots.HalBot.Abilities.Games.Pong
{
	/// <summary>
	/// The Hal bot's Pong ability implementation.
	/// </summary>
	[Export(typeof(IBotAbility))]
	public class Ability : IPongBotAbility
	{
		#region Fields
		private int m_centerY;
		private bool m_isLeftPaddle;        
		private int m_lastBallX;
		#endregion

		#region IPongBotAbility Members
		/// <summary>
		/// Moves the paddle.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		public PaddleMoveDirection MovePaddle(IPongEnvironmentContext context)
		{
			var ballIsMovingAway = (m_isLeftPaddle ^ (m_lastBallX > context.BallX));

			m_lastBallX = context.BallX;
			int targetY;
			
			if (ballIsMovingAway)
			{
				targetY = m_centerY;
			}
			else
			{
				targetY = context.BallY;
			}
			
			if (context.MyPaddleY > targetY)
			{
				return PaddleMoveDirection.Up;
			}
			else if (context.MyPaddleY < targetY)
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
			var ctx = ((IPongEnvironmentContext)context);

			m_centerY = ctx.TableHeight / 2;
			m_isLeftPaddle = ctx.OpponentPaddleX > ctx.MyPaddleX;
			m_lastBallX = ctx.BallX;
		}

		#endregion
	}
}
