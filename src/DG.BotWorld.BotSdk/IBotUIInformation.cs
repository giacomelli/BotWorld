using System.Drawing;

namespace DG.BotWorld.BotSdk
{
	/// <summary>
	/// Defines a interface to expose user interface information about the bot.
	/// </summary>
	public interface IBotUIInformation
	{
		/// <summary>
		/// Gets the avatar.
		/// </summary>
		Image Avatar
		{
			get;
		}
	}
}
