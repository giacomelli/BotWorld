using System.ComponentModel.Composition;
using System.Drawing;
using DG.BotWorld.Environments.Games.Maze;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Renderers.Games.Maze.Resources;
using DG.BotWorld.RendererSdk;

namespace DG.BotWorld.Renderers.Games.Maze
{
	/// <summary>
	/// Renderizador do ambiente de labirinto baseado em imagem.
	/// </summary>
	[Export(typeof(IEnvironmentRenderer))]
	public class MazeEnvironmentImageRenderer : EnvironmentImageRendererBase
	{
		/// <summary>
		/// Renders the specified environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		public override void Render(IEnvironment environment)
		{
			var e = (MazeEnvironment)environment;

			var map = e.GetMap();
			var horizontalCell = e.HorizontalCells;
			
			var imageSize = 800;
			var cellSize = imageSize / horizontalCell;

			Bitmap bmp = new Bitmap(imageSize, imageSize);
			var pen = System.Drawing.Pens.Black;
			var g = Graphics.FromImage(bmp);
			g.FillRectangle(Brushes.White, 0, 0, imageSize, imageSize);

			for (int row = 0; row < e.HorizontalCells; row++)
			{
				for (int column = 0; column < e.VerticalCells; column++)
				{
					var cell = map[row, column];

					DrawCell(cell, cellSize, g, pen);
				}
			}

			OutputImage = bmp;
		}

		private static void DrawCell(MazeCell cell, int cellSize, Graphics g, Pen pen)
		{
			var r = new Rectangle(cell.X * cellSize, cell.Y * cellSize, cellSize, cellSize);

			switch (cell.State)
			{
				case CellState.Occupied:
					if (cell.OccupiedByBot == null)
					{
						g.FillRectangle(Brushes.Black, r);
					}
					else
					{
						g.DrawImage(cell.OccupiedByBot.UIInformation.Avatar, r);
					}

					break;

				case CellState.Visited:
					break;

				case CellState.Unknown:
					g.FillRectangle(Brushes.LightGray, r);
					break;

				case CellState.Target:
					g.DrawImage(MazeEnvironmentImageRendererResource.CellStateTarget, r);
					break;
			}

			if (cell.TopSide == CellSideType.Wall)
			{
				g.DrawLine(pen, r.Left, r.Top, r.Right, r.Top);
			}

			if (cell.RightSide == CellSideType.Wall)
			{
				g.DrawLine(pen, r.Right, r.Top, r.Right, r.Bottom);
			}

			if (cell.BottomSide == CellSideType.Wall)
			{
				g.DrawLine(pen, r.Left, r.Bottom, r.Right, r.Bottom);
			}

			if (cell.LeftSide == CellSideType.Wall)
			{
				g.DrawLine(pen, r.Left, r.Top, r.Left, r.Bottom);
			}
		}    
	}
}
