using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.RendererSdk;
using System.ComponentModel.Composition;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Environments.Games.Pong;
using System.Drawing;

namespace DG.BotWorld.Renderers.Games.Pong
{
    [Export(typeof(IEnvironmentRenderer))]
    public class PongEnvironmentImageRenderer : EnvironmentImageRendererBase
    {
        private Font m_font;

        public PongEnvironmentImageRenderer()
        {
             m_font = new Font("Arcade Classic", 30, FontStyle.Regular);             
        }

        public override void Render(IEnvironment environment)
        {
            // TODO: todos os environments deveriam ter uma interface no seu SDK dessa forma evita que o criador de render
            // tenha que referenciar a implementação do ambiente.
            var env = (PongEnvironment)environment;

            Bitmap bmp = new Bitmap(env.TableSize.Width, env.TableSize.Height);
            var pen = System.Drawing.Pens.Black;
            var g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.Black, 0, 0, env.TableSize.Width, env.TableSize.Height);


            if (env.LeftPaddle != null)
            {
                DrawPaddle(env.LeftPaddle, g);
                DrawPaddle(env.RightPaddle, g);
                DrawScore(env, g);
                DrawBall(env, g);
            }            

            var imageWidth = env.TableSize.Width + 10;
            var imageHeight = env.TableSize.Height + 60;

            Bitmap outsideImage = new Bitmap(imageWidth, imageHeight);
            var outsideG = Graphics.FromImage(outsideImage);
            outsideG.FillRectangle(Brushes.Black, 0, 0, imageWidth, imageHeight);
            outsideG.DrawImage(bmp, 5, 30);
            DrawField(env, outsideG, imageWidth, imageHeight);
            bmp.Dispose();

            OutputImage = outsideImage;
        }

        private void DrawBall(PongEnvironment env, Graphics g)
        {
            var ball = env.Ball;
            g.FillRectangle(Brushes.White, ball.X, ball.Y, ball.Width, ball.Height);
        }

        private void DrawScore(PongEnvironment env, Graphics g)
        {
            var middleX = (env.TableSize.Width / 2);            
            g.DrawString(env.LeftPaddle.Points.ToString(), m_font, Brushes.White, middleX - 78, 45);
            g.DrawString(env.RightPaddle.Points.ToString(), m_font, Brushes.White, middleX + 12, 45);

            g.DrawImage(env.LeftPaddle.Controller.UIInformation.Avatar, middleX - 70, 10, 32, 32);
            g.DrawImage(env.RightPaddle.Controller.UIInformation.Avatar, middleX + 20, 10, 32, 32);
        }

        private static void DrawPaddle(Paddle p, Graphics g)
        {
            g.FillRectangle(Brushes.White, p.X, p.Y, p.Width, p.Height);
        }

        private static void DrawField(PongEnvironment env, Graphics g, int width, int height)
        {
            // Top wall.
            g.FillRectangle(Brushes.White, 5, 15, width - 10, 15);

            var bottomWallY = height - 30;

            // Bottom wall.
            g.FillRectangle(Brushes.White, 5, bottomWallY, width - 10, 15);

            // Division.
            var divisionX = (width / 2) - 15;
            for (int y = 15; y < bottomWallY; y += 30)
            {
                g.FillRectangle(Brushes.White, divisionX, y, 15, 15);
            }
        }
    }
}
