using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Games.Pong
{
    public class Paddle : PongObject
    {
        public Paddle(IBot controller, int x, int y, int width, int height)
        {
            Controller = controller;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            SpeedX = 4;
            SpeedY = 4;
        }

        public IBot Controller
        {
            get;
            private set;
        }

        public int Points
        {
            get;
            set;
        }
    }
}
