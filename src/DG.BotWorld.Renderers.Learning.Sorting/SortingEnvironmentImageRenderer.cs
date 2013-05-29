using System;
using DG.BotWorld.RendererSdk;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Environments.Learning.Sorting;
using System.Drawing;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace DG.BotWorld.Renderers.Learning.Sorting
{
	/// <summary>
	/// Sorting environment image renderer.
	/// </summary>
	[Export(typeof(IEnvironmentRenderer))]
	public class SortingEnvironmentImageRenderer : EnvironmentImageRendererBase
	{
		#region implemented abstract members of EnvironmentImageRendererBase
		/// <summary>
		/// Renders the specified environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		public override void Render (IEnvironment environment)
		{
			var e = (SortingEnvironment)environment;

			var items = e.Items;
			var imageSize = 800;

			var bmp = new Bitmap(imageSize, imageSize);
			var g = Graphics.FromImage(bmp);
			var font = new Font (FontFamily.GenericMonospace, 76);
			g.FillRectangle(Brushes.Black, 0, 0, imageSize, imageSize);
				
			var textBuilder = new StringBuilder ();

			for (var i = 0; i < items.Length; i++) {
				textBuilder.AppendFormat ("{0} ", items[i]);

				if ((i + 1) % 20 == 0) {
					textBuilder.AppendLine ();
				}
			}

			var text = textBuilder.ToString ();
			var textSize = g.MeasureString (text, font);
			var scaleX = bmp.Width / textSize.Width;
			var scaleY = bmp.Height / textSize.Height;
			var scale = Math.Min (scaleX, scaleY);
			g.ScaleTransform(scale, scale);
			g.DrawString (text, font, Brushes.White, 0, 0);

			OutputImage = bmp;
		}

		#endregion
	}
}