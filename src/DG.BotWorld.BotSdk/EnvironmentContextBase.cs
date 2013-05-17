
namespace DG.BotWorld.BotSdk
{
	/// <summary>
	/// A abstract base classe for environment contexts.
	/// </summary>
	public class EnvironmentContextBase : IEnvironmentContext
	{
		#region IEnvironment Members
		/// <summary>
		/// Gets the current cycle on the environment.
		/// </summary>
		public int Cycle
		{
			get;
			protected set;
		}
		#endregion
	}
}
