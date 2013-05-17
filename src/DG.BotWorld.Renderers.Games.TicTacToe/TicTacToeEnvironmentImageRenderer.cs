using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using DG.BotWorld.Environments.Games.TicTacToe;
using DG.BotWorld.Environments.Games.TicTacToeSdk;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.RendererSdk;

namespace DG.BotWorld.Renderers.Games.TicTacToe
{
	/// <summary>
	/// A image based renderer for TicTacToe environment.
	/// </summary>
	[Export(typeof(IEnvironmentRenderer))]
	public class TicTacToeEnvironmentImageRenderer : EnvironmentImageRendererBase
	{
		#region Fields
		private const int ImageSize = 800;
		private const int CellSize = ImageSize / 3;
		#endregion		

		#region Methods
		/// <summary>
		/// Renders the specified environment.
		/// </summary>
		/// <param name="environment">The environment.</param>
		public override void Render(IEnvironment environment)
		{
			var e = (TicTacToeEnvironment)environment;

			var spaces = e.Board.GetSpaces();

			Bitmap bmp = new Bitmap(ImageSize, ImageSize);
			var pen = new Pen(Color.Black, 2);            
			var g = Graphics.FromImage(bmp);
			g.FillRectangle(Brushes.White, 0, 0, ImageSize, ImageSize);
			
			for (int row = 0; row < 3; row++)
			{
				for (int column = 0; column < 3; column++)
				{
					DrawSpace(e, spaces[row, column], g, pen);                   
				}
			}

			OutputImage = bmp;
		}

		private static void DrawSpace(TicTacToeEnvironment environment, ITicTacToeBoardSpace space, Graphics g, Pen pen)
		{
			int x = space.ColumnIndex * CellSize;
			int y = space.RowIndex * CellSize;

			if (environment.State == EnvironmentState.Finished)
			{
				var winnerSpaces = environment.GetWinnerSpaces();

				if (winnerSpaces.Contains(space))
				{
					var brush = Brushes.Red;

					g.FillRectangle(brush, space.ColumnIndex * CellSize, space.RowIndex * CellSize, CellSize, CellSize);                    
				}                
			}

			switch (space.SpaceType)
			{
				case SpaceType.Cross:
					g.DrawImage(environment.CrossBot.UIInformation.Avatar, x, y, CellSize, CellSize);
					break;

				case SpaceType.Nought:
					g.DrawImage(environment.NoughtBot.UIInformation.Avatar, x, y, CellSize, CellSize);
					break;
			}

			g.DrawRectangle(pen, x, y, CellSize, CellSize);
		}
		#endregion
	}
}
