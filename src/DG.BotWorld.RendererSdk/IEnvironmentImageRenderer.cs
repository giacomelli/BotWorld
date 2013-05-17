using System.Drawing;

namespace DG.BotWorld.RendererSdk
{
	/// <summary>
	/// Defines a interface for a image based environment renderer.
	/// </summary>
	public interface IEnvironmentImageRenderer : IEnvironmentRenderer
	{
		/// <summary>
		/// Gets the output image.
		/// </summary>
		Image OutputImage
		{
			get;
		}
	}
}
