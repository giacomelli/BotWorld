using System.ComponentModel.Composition;
using DG.BotWorld.Bots.HalBot.Resources;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Bots.HalBot
{
	/// <summary>
	/// The Hal bot implementation.
	/// </summary>
	[Export(typeof(IBot))]
	public class Bot : BotBase
	{
		/// <summary>
		/// Initializes a new <see cref="Bot"/> instance.
		/// </summary>
		public Bot()
		{
			Name = "Hal";
			UIInformation = new BotUIInformation(BotResource.Avatar);
		}
	}
}
