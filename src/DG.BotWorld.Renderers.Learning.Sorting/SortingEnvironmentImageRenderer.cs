using System;
using DG.BotWorld.RendererSdk;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Environments.Learning.Sorting;
using System.Drawing;
using System.ComponentModel.Composition;

namespace DG.BotWorld.Renderers.Learning.Sorting
{
	[Export(typeof(IEnvironmentRenderer))]
	public class SortingEnvironmentImageRenderer : EnvironmentImageRendererBase
	{
		#region implemented abstract members of EnvironmentImageRendererBase
		public override void Render (IEnvironment environment)
		{
			var e = (SortingEnvironment)environment;

		//	var items = e.Items;

			var imageSize = 800;
			var bmp = new Bitmap(imageSize, imageSize);
//			var pen = new Pen(Color.Black, 2);            
//			var g = Graphics.FromImage(bmp);
//			var font = new Font("Arcade Classic", 30, FontStyle.Regular); 
//			g.FillRectangle(Brushes.White, 0, 0, imageSize, imageSize);
//	
//			foreach(var i in items)
//			{
//				g.DrawString(i.ToString(), font, Brushes.Black, 400, i * 10);
//			}

			bmp.Dispose();
			OutputImage = bmp;
		}

		#endregion
	}
}