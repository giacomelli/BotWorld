using System;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Arguments for BotAssemblySaved event.
	/// </summary>
	public class BotAssemblySavedEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="BotAssemblySavedEventArgs"/> instance.
		/// </summary>
		/// <param name="bot">The bot.</param>
		public BotAssemblySavedEventArgs(IBot bot)
		{
			Bot = bot;
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
		#endregion
	}
}
