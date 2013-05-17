using System.Collections.Generic;
using DG.BotWorld.BotSdk;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Arguments for EnvironmentRunning event.
	/// </summary>
	public class EnvironmentRunningEventArgs : EnvironmentEventArgsBase
	{
		#region Constructors
		/// <summary>
		///Initialize a new <see cref="EnvironmentRunningEventArgs"/> instance.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <param name="bots">The bots.</param>
		public EnvironmentRunningEventArgs(IEnvironment environment, IList<IBot> bots) : base(environment)
		{            
			Bots = bots;            
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the bots.
		/// </summary>
		public IList<IBot> Bots
		{
			get;
			private set;
		}
		#endregion
	}
}
