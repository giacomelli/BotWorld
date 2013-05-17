using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Environments.Games.PongSdk;
using System.Drawing;
using DG.BotWorld.Environments.Games.Pong.Resources;
using System.ComponentModel.Composition;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Games.Pong
{
    [Export(typeof(IEnvironment))]
    public class PongEnvironment : EnvironmentBase
    {
        #region Constants
        public const int PaddleWidth = 15;
        public const int PaddleHeight = 45;
        #endregion

        #region Fields
        private IBot m_leftPaddleBot;
        private IBot m_rightPaddleBot;

        private IPongBotAbility m_leftPaddleBotAbility;
        private IPongBotAbility m_rightPaddleBotAbility;

        private PongEnvironmentContext m_leftPaddleContext;
        private PongEnvironmentContext m_rightPaddleContext;

        private BotRank[] m_botsRanks = new BotRank[2];

        private Random m_random = new Random();
        #endregion

        #region Constructors
        public PongEnvironment()
        {
            Name = "Pong";
            Description = "A challenge on classic Pong.";
            UIInformation = new EnvironmentUIInformation(PongEnvironmentResource.Avatar);
            MinBotsNumber = 2;
            MaxBotsNumber = 2;
            UpdateTimeout = 10000000;
            MaxUpdateCycles = 10000;
            TableSize = new Size(500, 400);

            Ball = new Ball(0, 0, PaddleWidth, PaddleWidth);
        }
        #endregion

        #region Properties
        public Size TableSize
        {
            get;
            private set;
        }

        public Ball Ball
        {
            get;
            private set;
        }

        public Paddle LeftPaddle
        {
            get;
            private set;
        }

        public Paddle RightPaddle
        {
            get;
            private set;
        }
        #endregion

        public override void Initialize(IWorldContext context)
        {
            
        }

        public override void InitializeRound(IWorldContext context)
        {            
			var bots = context.GetBotsWithKindOfAbility<IPongBotAbility>();

            ResetBallPosition();

            m_leftPaddleBot = bots[0];
			m_leftPaddleBotAbility = (IPongBotAbility) context.GetBotAbility<IPongBotAbility>(m_leftPaddleBot);
            m_leftPaddleContext = new PongEnvironmentContext();
            m_leftPaddleContext.TableWidth = TableSize.Width;
            m_leftPaddleContext.TableHeight = TableSize.Height;            

            m_rightPaddleBot = bots[1];
			m_rightPaddleBotAbility = (IPongBotAbility)context.GetBotAbility<IPongBotAbility>(m_rightPaddleBot);
            m_rightPaddleContext = new PongEnvironmentContext();
            m_rightPaddleContext.TableWidth = TableSize.Width;
            m_rightPaddleContext.TableHeight = TableSize.Height;            

            LeftPaddle = new Paddle(m_leftPaddleBot, 2, (TableSize.Height / 2) - (PaddleHeight / 2), PaddleWidth, PaddleHeight);
            RightPaddle = new Paddle(m_rightPaddleBot, TableSize.Width - LeftPaddle.Width - 2, LeftPaddle.Y, PaddleWidth, PaddleHeight);

            m_leftPaddleBotAbility.Initialize(m_leftPaddleContext);
            m_rightPaddleBotAbility.Initialize(m_rightPaddleContext);
        }

        private void ResetBallPosition()
        {            
            Ball.X = TableSize.Width / 2;
            Ball.Y = TableSize.Height / 2;

            Ball.SpeedX *= m_random.Next(0, 2) == 0 ? -1 : 1;
            Ball.SpeedY *= m_random.Next(0, 2) == 0 ? -1 : 1;
        }


        public override void Update(IWorldContext context)
        {
            m_leftPaddleContext.Cycle = context.Cycle;
            m_leftPaddleContext.MyPaddleX = LeftPaddle.CenterX;
            m_leftPaddleContext.MyPaddleY = LeftPaddle.CenterY;
            m_leftPaddleContext.OpponentPaddleX = RightPaddle.CenterX;
            m_leftPaddleContext.OpponentPaddleY = RightPaddle.CenterY;
            m_leftPaddleContext.BallX = Ball.CenterX;
            m_leftPaddleContext.BallY = Ball.CenterY;
            m_leftPaddleContext.BallSpeedX = Ball.SpeedX;
            m_leftPaddleContext.BallSpeedY = Ball.SpeedY;
            m_leftPaddleContext.BallWidth = Ball.Width;
            m_leftPaddleContext.BallHeight = Ball.Height;
            
            m_rightPaddleContext.Cycle = context.Cycle;
            m_rightPaddleContext.MyPaddleX = RightPaddle.CenterX;
            m_rightPaddleContext.MyPaddleY = RightPaddle.CenterY;
            m_rightPaddleContext.OpponentPaddleX = LeftPaddle.CenterX;
            m_rightPaddleContext.OpponentPaddleY = LeftPaddle.CenterY;
            m_rightPaddleContext.BallX = Ball.CenterX;
            m_rightPaddleContext.BallY = Ball.CenterY;
            m_rightPaddleContext.BallSpeedX = Ball.SpeedX;
            m_rightPaddleContext.BallSpeedY = Ball.SpeedY;
            m_rightPaddleContext.BallWidth = Ball.Width;
            m_rightPaddleContext.BallHeight = Ball.Height;

            PeformsPaddleMove(LeftPaddle, m_leftPaddleBotAbility, m_leftPaddleContext);            
            PeformsPaddleMove(RightPaddle, m_rightPaddleBotAbility, m_rightPaddleContext);

            PerformsBallMove();

            if (LeftPaddle.Points == 3 || RightPaddle.Points == 3)
            {
                m_botsRanks[0] = new BotRank(LeftPaddle.Controller, CalculateRank(LeftPaddle, context));
                m_botsRanks[1] = new BotRank(RightPaddle.Controller, CalculateRank(RightPaddle, context));
                State = EnvironmentState.Finished;
            }
        }

        private float CalculateRank(Paddle p, IWorldContext context)
        {
            return ((MaxUpdateCycles - context.Cycle) / (float)MaxUpdateCycles) / ((3 - p.Points) + 1);
        }

        private void PerformsBallMove()
        {
            // Walls.
            if (Ball.X <= 0 || (Ball.X + Ball.Width >= TableSize.Width))
            {
                if (Ball.SpeedX > 0)
                {
                    LeftPaddle.Points++;
                }
                else
                {
                    RightPaddle.Points++;
                }
                                
                ResetBallPosition();
            }

            if (Ball.Y <= 0 || (Ball.Y + Ball.Height >= TableSize.Height))
            {
                Ball.SpeedY *= -1;
            }

            // Paddles.
            if (Ball.IsColliding(LeftPaddle) || Ball.IsColliding(RightPaddle))
            {
                Ball.SpeedX *= -1;
            }
        
            
            Ball.X += Ball.SpeedX;
            Ball.Y += Ball.SpeedY;
        }

        private void PeformsPaddleMove(Paddle paddle, IPongBotAbility ability, PongEnvironmentContext context)
        {
            var move = ability.MovePaddle(context);

            if (move == PaddleMoveDirection.Down)
            {
                if (paddle.Y + paddle.Height + 1 < TableSize.Height)
                {
                    paddle.Y += paddle.SpeedY;
                }
            }
            else if (move == PaddleMoveDirection.Up)            
            {
                if (paddle.Y - 1 > 0)
                {
                    paddle.Y -= paddle.SpeedX;
                }                
            }
        }

        public override Type[] GetNeededBotAbilities()
        {
            return new Type[] { typeof(IPongBotAbility) };
        }

        public override BotRank[] GetBotsRanking()
        {
            return m_botsRanks;
        }
    }
}
