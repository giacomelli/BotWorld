using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Arguments for EnvironmentUpdated event.
	/// </summary>
	public class EnvironmentUpdatedEventArgs : EnvironmentEventArgsBase
	{
		#region Constructors		
		/// <summary>
		///Initialize a new <see cref="EnvironmentUpdatedEventArgs"/> instance.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <param name="cycle">The cycle.</param>
		public EnvironmentUpdatedEventArgs(IEnvironment environment, int cycle) : base(environment)
		{            
			Cycle = cycle;
		}
		#endregion

		#region Properties		
		/// <summary>
		/// Gets the cycle.
		/// </summary>
		public int Cycle
		{
			get;
			private set;
		}
		#endregion
	}
}
