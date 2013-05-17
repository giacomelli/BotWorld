using System;
using DG.BotWorld.EnvironmentSdk;
using System.Diagnostics.CodeAnalysis;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Abstract base classe for environments.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public abstract class EnvironmentEventArgsBase : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initilializes a new <see cref="EnvironmentEventArgsBase"/> instance.
		/// </summary>
		/// <param name="environment">The environment.</param>
		protected EnvironmentEventArgsBase(IEnvironment environment)
		{
			Environment = environment;
		}
		#endregion

		#region Methods
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
