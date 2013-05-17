
namespace DG.BotWorld.BotSdk
{
	/// <summary>
	/// Defines the basic informations for a environment context.
	/// </summary>
	public interface IEnvironmentContext
	{
		#region Properties
		/// <summary>
		/// Gets the current cycle on the environment.
		/// </summary>
		int Cycle
		{
			get;
		}
		#endregion
	}
}
