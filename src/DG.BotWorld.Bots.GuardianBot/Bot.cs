using System.ComponentModel.Composition;
using DG.BotWorld.Bots.GuardianBot.Resources;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Bots.GuardianBot
{
	/// <summary>
	/// The Guardian bot implementation.
	/// </summary>
	[Export(typeof(IBot))]
	public class Bot : BotBase
	{
		/// <summary>
		/// Initializes a new <see cref="Bot"/> instance.
		/// </summary>
		public Bot()
		{
			Name = "Guardian";
			UIInformation = new BotUIInformation(BotResource.Avatar);
		}
	}
}
