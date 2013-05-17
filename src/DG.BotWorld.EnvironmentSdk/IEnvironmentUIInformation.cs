using System.Drawing;

namespace DG.BotWorld.EnvironmentSdk
{
	/// <summary>
	/// Defines a interface for user interface information about an environment.
	/// </summary>
	public interface IEnvironmentUIInformation
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
