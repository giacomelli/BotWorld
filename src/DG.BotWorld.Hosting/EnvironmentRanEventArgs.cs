using System.Collections.Generic;
using DG.BotWorld.BotSdk;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Arguments for EnvironmentRan event.
	/// </summary>
	public class EnvironmentRanEventArgs : EnvironmentEventArgsBase
	{
		#region Constructors
		/// <summary>
		///Initialize a new <see cref="EnvironmentRanEventArgs"/> instance.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <param name="bots">The bots.</param>
		/// <param name="cycles">The cycles.</param>
		public EnvironmentRanEventArgs(IEnvironment environment, IList<IBot> bots, int cycles) : base(environment)
		{            
			Bots = bots;
			Cycles = cycles;
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

		/// <summary>
		/// Gets the cycles.
		/// </summary>
		public int Cycles
		{
			get;
			private set;
		}
		#endregion
	}
}
