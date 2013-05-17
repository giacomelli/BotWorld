using System.Drawing;

namespace DG.BotWorld.BotSdk
{
	/// <summary>
	/// The default class for bot's user interface information.
	/// </summary>
	public class BotUIInformation : IBotUIInformation
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="BotUIInformation"/> class instance.
		/// </summary>
		/// <param name="avatar">The avatar.</param>
		public BotUIInformation(Image avatar)
		{
			Avatar = avatar;
		}
		#endregion

		#region IBotUIInformation Members
		/// <summary>
		/// Gets the avatar.
		/// </summary>
		public Image Avatar
		{
			get;
			set;
		}
		#endregion
	}
}
