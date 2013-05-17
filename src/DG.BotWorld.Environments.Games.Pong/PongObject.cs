using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.BotWorld.Environments.Games.Pong
{
    public class PongObject
    {
        public int X
        {
            get;
            set;
        }

        public int X2
        {
            get
            {
                return X + Width;
            }
        }

        public int CenterX
        {
            get
            {
                return X + (Width / 2);
            }
        }

        public int Y
        {
            get;
            set;
        }

        public int Y2
        {
            get
            {
                return Y + Height;
            }
        }

        public int CenterY
        {
            get
            {
                return Y + (Height / 2);
            }
        }

        public int SpeedX
        {
            get;
            set;
        }

        public int SpeedY
        {
            get;
            set;
        }


        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public bool IsColliding(PongObject other)
        {
            bool isXColliding = (X >= other.X && X <= other.X2) || (X2 >= other.X && X2 <= other.X2);
            bool isYColliding = (Y >= other.Y && Y <= other.Y2) || (Y2 >= other.Y && Y2 <= other.Y2);

            return isXColliding && isYColliding;
        }
    }
}
