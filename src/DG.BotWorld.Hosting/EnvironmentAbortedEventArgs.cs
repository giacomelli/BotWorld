using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Arguments for EnvironemntAborted event.
	/// </summary>
	public class EnvironmentAbortedEventArgs : EnvironmentEventArgsBase
	{
		/// <summary>
		/// Initializes a new <see cref="EnvironmentAbortedEventArgs"/> instance.
		/// </summary>
		/// <param name="environment">The environment.</param>
		public EnvironmentAbortedEventArgs(IEnvironment environment)
			: base(environment)
		{
		}
	}
}
