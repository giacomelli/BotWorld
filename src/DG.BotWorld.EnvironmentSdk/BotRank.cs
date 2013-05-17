using DG.BotWorld.BotSdk;

namespace DG.BotWorld.EnvironmentSdk
{
	/// <summary>
	/// Represents a rank for a bot.
	/// </summary>
	public class BotRank
	{
		#region Constructors		
		/// <summary>
		/// Initiliazes a new <see cref="BotRank"/> class instance.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="score">The score.</param>
		public BotRank(IBot bot, float score)
		{
			Bot = bot;
			Score = score;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the bot.
		/// </summary>
		public IBot Bot
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the score.
		/// </summary>
		public float Score
		{
			get;
			private set;
		}
		#endregion
	}
}
