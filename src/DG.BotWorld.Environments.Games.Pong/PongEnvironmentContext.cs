using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.Environments.Games.PongSdk;
using System.Drawing;

namespace DG.BotWorld.Environments.Games.Pong
{
    public class PongEnvironmentContext : IPongEnvironmentContext
    {
        #region IPongEnvironmentContext Members

        public int TableWidth
        {
            get;
            set;
        }

        public int TableHeight
        {
            get;
            set;
        }

        public int BallX
        {
            get;
            set;
        }

        public int BallY
        {
            get;
            set;
        }

        public int BallSpeedX
        {
            get;
            set;
        }

        public int BallSpeedY
        {
            get;
            set;
        }

        public int BallWidth
        {
            get;
            set;
        }

        public int BallHeight
        {
            get;
            set;
        }

        public int MyPaddleX
        {
            get;
            set;
        }

        public int MyPaddleY
        {
            get;
            set;
        }

        public int OpponentPaddleX
        {
            get;
            set;
        }

        public int OpponentPaddleY
        {
            get;
            set;
        }

        #endregion

        #region IEnvironmentContext Members

        public int Cycle
        {
            get;
            set;
        }

        #endregion
    }
}
