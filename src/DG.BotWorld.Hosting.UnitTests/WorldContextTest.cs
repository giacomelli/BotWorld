using NUnit.Framework;
using System;
using Rhino.Mocks;
using DG.BotWorld.BotSdk;
using DG.BotWorld.Hosting.UnitTests.Stubs;
using TestSharp;

namespace DG.BotWorld.Hosting.UnitTests
{
	[TestFixture()]
	public class WorldContextTest
	{
		[Test()]
		public void AddBot_NullBot_Exception ()
		{
			var target = new WorldContext ();
			ExceptionAssert.IsThrowing (new ArgumentNullException("bot"), () => {			
				target.AddBot (null, null);
			});
		}

		[Test()]
		public void AddBot_NullOrEmptyAbilities_Exception ()
		{
			var target = new WorldContext ();
			var bot = MockRepository.GenerateMock<IBot> ();
			bot.Expect (b => b.Name).Return ("b1");

			ExceptionAssert.IsThrowing (new InvalidOperationException("The bot 'b1' should have abilities to enter in the world context."), () => {			
				target.AddBot (bot, null);
			});

			ExceptionAssert.IsThrowing (new InvalidOperationException("The bot 'b1' should have abilities to enter in the world context."), () => {			
				target.AddBot (bot, new IBotAbility[0]);
			});
		}

		[Test()]
		public void AddBot_BotAlreadyExists_Exception ()
		{
			var target = new WorldContext ();
			var bot = MockRepository.GenerateMock<IBot> ();
			bot.Expect (b => b.Name).Return ("b1");

			ExceptionAssert.IsThrowing (new InvalidOperationException("The bot 'b1' has already been added to the world context."), () => {			
				target.AddBot (bot, MockRepository.GenerateMock<IBotAbility> ());
				target.AddBot (bot, MockRepository.GenerateMock<IBotAbility> ());
			});
		}

		[Test()]
		public void AddBot_BotsAndAbilities_Added ()
		{
			var target = new WorldContext ();
		
			var bot1 = MockRepository.GenerateMock<IBot> ();
			bot1.Expect (b => b.Name).Return ("b1");
			var ability1 = MockRepository.GenerateMock<IOneBotAbility>();

			var bot2 = MockRepository.GenerateMock<IBot> ();
			bot2.Expect (b => b.Name).Return ("b2");
			var ability2 = MockRepository.GenerateMock<ITwoBotAbility>();

			target.AddBot (bot1, ability1);
			target.AddBot (bot2, ability2);

			Assert.AreEqual (2, target.BotsCount);
			Assert.AreEqual (bot1, target.GetBotsWithKindOfAbility<IOneBotAbility> () [0]);
			Assert.AreEqual (bot2, target.GetBotsWithKindOfAbility<ITwoBotAbility> () [0]);
		}
				
		[Test()]
		public void ClearBots_NoArguments_BotsCountZero ()
		{
			var target = new WorldContext ();
			var bot1 = MockRepository.GenerateMock<IBot> ();
			bot1.Expect (b => b.Name).Return ("b1");
			var ability1 = MockRepository.GenerateMock<IOneBotAbility>();

			var bot2 = MockRepository.GenerateMock<IBot> ();
			bot2.Expect (b => b.Name).Return ("b2");
			var ability2 = MockRepository.GenerateMock<ITwoBotAbility>();

			target.AddBot (bot1, ability1);
			target.AddBot (bot2, ability2);

			Assert.AreEqual (2, target.BotsCount);
			target.ClearBots ();
			Assert.AreEqual (0, target.BotsCount);
		}

		[Test()]
		public void GetBotsWithKindOfAbility_NoBots_EmptyList ()
		{
			var target = new WorldContext ();
			Assert.AreEqual(0, target.GetBotsWithKindOfAbility<IBotAbility>().Length);
		}

		[Test()]
		public void GetBotsWithKindOfAbility_AddBots_ListOfAbilities ()
		{
			var target = new WorldContext ();
			var bot1 = MockRepository.GenerateMock<IBot> ();
			var bot2 = MockRepository.GenerateMock<IBot> ();
			var bot3 = MockRepository.GenerateMock<IBot> ();
			var ability1 = MockRepository.GenerateMock<IOneBotAbility> ();
			var ability2 = MockRepository.GenerateMock<ITwoBotAbility> ();
			var ability3 = MockRepository.GenerateMock<IThreeBotAbility> ();

			target.AddBot (bot1, ability1, ability2, ability3);
			target.AddBot (bot2, ability2);
			target.AddBot (bot3, ability3);		

			var actual = target.GetBotsWithKindOfAbility<IOneBotAbility>();
			Assert.AreEqual (1, actual.Length);
			Assert.AreSame (bot1, actual[0]);

			actual = target.GetBotsWithKindOfAbility<ITwoBotAbility>();
			Assert.AreEqual (2, actual.Length);
			Assert.AreSame (bot1, actual[0]);
			Assert.AreSame (bot2, actual[1]);

			actual = target.GetBotsWithKindOfAbility<IThreeBotAbility>();
			Assert.AreEqual (2, actual.Length);
			Assert.AreSame (bot1, actual[0]);
			Assert.AreSame (bot3, actual[1]);
		}

		[Test()]
		public void GetBotAbility_BotNull_Exception ()
		{
			var target = new WorldContext ();
			ExceptionAssert.IsThrowing (new ArgumentNullException("bot"), () => {			
				target.GetBotAbility<IOneBotAbility>(null);
			});
		}

		[Test()]
		public void GetBotAbility_BotNotAdded_Exception ()
		{
			var target = new WorldContext ();
			var bot1 = MockRepository.GenerateMock<IBot> ();
			bot1.Expect (b => b.Name).Return ("b1");
			ExceptionAssert.IsThrowing (new ArgumentException("Bot 'b1' is not in the world context."), () => {			
				target.GetBotAbility<IOneBotAbility>(bot1);
			});
		}

		[Test()]
		public void GetBotAbility_WithoutAbility_Null ()
		{
			var target = new WorldContext ();
			var bot1 = MockRepository.GenerateMock<IBot> ();
			var ability1 = MockRepository.GenerateMock<IOneBotAbility>();

			target.AddBot (bot1, ability1);
			var actual = target.GetBotAbility<ITwoBotAbility> (bot1);
			Assert.IsNull (actual);
		}

		[Test()]
		public void GetBotAbility_WithAbilities_Ability ()
		{
			var target = new WorldContext ();
			var bot1 = MockRepository.GenerateMock<IBot> ();
			var ability1 = MockRepository.GenerateMock<IOneBotAbility>();
			var ability2 = MockRepository.GenerateMock<ITwoBotAbility>();

			target.AddBot (bot1, ability1, ability2);

			IBotAbility actual = target.GetBotAbility<IOneBotAbility> (bot1);
			Assert.AreEqual (ability1, actual);

			actual = target.GetBotAbility<ITwoBotAbility> (bot1);
			Assert.AreEqual (ability2, actual);
		}
	}
}

