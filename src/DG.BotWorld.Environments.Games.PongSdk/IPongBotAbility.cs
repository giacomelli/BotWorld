using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Games.PongSdk
{
    public enum PaddleMoveDirection
    {
        Up,
        Down,
        Stop
    }

    public interface IPongBotAbility : IBotAbility
    {
        PaddleMoveDirection MovePaddle(IPongEnvironmentContext context);
    }
}
