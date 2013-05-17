using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.RendererSdk
{
	/// <summary>
	/// Defines a interface for a environment render.
	/// </summary>
	public interface IEnvironmentRenderer
	{
		/// <summary>
		/// Renders the specified environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		void Render(IEnvironment environment);        
	}
}
