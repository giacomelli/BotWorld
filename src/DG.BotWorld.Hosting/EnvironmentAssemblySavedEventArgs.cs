using System;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Arguments for event EnvironemntAssemblySaved.
	/// </summary>
	public class EnvironmentAssemblySavedEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="EnvironmentAssemblySavedEventArgs"/> instance.
		/// </summary>
		/// <param name="environment">The environment.</param>
		public EnvironmentAssemblySavedEventArgs(IEnvironment environment)
		{
			Environment = environment;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the environment.
		/// </summary>
		public IEnvironment Environment
		{
			get;
			private set;
		}
		#endregion
	}
}
