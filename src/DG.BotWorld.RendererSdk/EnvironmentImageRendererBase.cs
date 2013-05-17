using System.Drawing;
using DG.BotWorld.EnvironmentSdk;

namespace DG.BotWorld.RendererSdk
{
	/// <summary>
	/// A abstract base class image based environment renderer.
	/// </summary>
	public abstract class EnvironmentImageRendererBase : IEnvironmentImageRenderer
	{
		#region IImageRenderer Members
		/// <summary>
		/// Gets the output image.
		/// </summary>
		public Image OutputImage
		{
			get;
			protected set;
		}

		#endregion

		#region IRenderer Members
		/// <summary>
		/// Renders the specified environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		public abstract void Render(IEnvironment environment);
		#endregion
	}
}
