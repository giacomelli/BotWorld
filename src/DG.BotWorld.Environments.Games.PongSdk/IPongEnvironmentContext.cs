using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.BotSdk;
using System.Drawing;

namespace DG.BotWorld.Environments.Games.PongSdk
{
    public interface IPongEnvironmentContext : IEnvironmentContext
    {
        int TableWidth
        {
            get;
        }

        int TableHeight
        {
            get;
        }

        int BallX
        {
            get;            
        }

        int BallY
        {
            get;            
        }

        int BallSpeedX
        {
            get;
        }

        int BallSpeedY
        {
            get;
        }

        int BallWidth
        {
            get;
        }

        int BallHeight
        {
            get;
        }

        int MyPaddleX
        {
            get;
        }

        int MyPaddleY
        {
            get;
        }

        int OpponentPaddleX
        {
            get;
        }

        int OpponentPaddleY
        {
            get;
        }


    }
}
