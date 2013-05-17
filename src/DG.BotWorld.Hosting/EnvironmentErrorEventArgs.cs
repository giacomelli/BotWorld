using System;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Arguments for EnvironemntError event.
	/// </summary>
	public class EnvironmentErrorEventArgs : EnvironmentEventArgsBase
	{
		#region Methods
		/// <summary>
		/// Initializes new <see cref="EnvironmentErrorEventArgs"/> class.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <param name="exception">The exception.</param>
		public EnvironmentErrorEventArgs(IEnvironment environment, Exception exception)
			: base(environment)
		{
			Exception = exception;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the exception.
		/// </summary>
		public Exception Exception
		{
			get;
			private set;
		}
		#endregion
	}
}
