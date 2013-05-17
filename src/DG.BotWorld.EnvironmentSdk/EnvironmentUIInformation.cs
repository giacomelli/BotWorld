using System.Drawing;

namespace DG.BotWorld.EnvironmentSdk
{
	/// <summary>
	/// Basic user interface information about an environment.
	/// </summary>
	public class EnvironmentUIInformation : IEnvironmentUIInformation
	{
		#region Constructors
		/// <summary>
		/// Initialize a new <see cref="EnvironmentUIInformation"/> class instance.
		/// </summary>
		/// <param name="avatar">The avatar.</param>
		public EnvironmentUIInformation(Image avatar)
		{
			Avatar = avatar;
		}
		#endregion

		#region IEnvironmentUIInformation Members
		/// <summary>
		/// Gets or sets the avatar.
		/// </summary>
		/// <value>
		/// The avatar.
		/// </value>
		public Image Avatar
		{
			get;
			set;
		}
		#endregion
	}
}
