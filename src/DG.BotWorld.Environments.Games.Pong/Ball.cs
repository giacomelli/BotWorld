using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.BotWorld.Environments.Games.Pong
{
    public class Ball : PongObject
    {
        public Ball(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            SpeedX = 5;
            SpeedY = 5;
        }       
    }
}
