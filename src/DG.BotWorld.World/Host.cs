using System;
using System.Linq;
using DG.BotWorld.BotSdk;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Hosting;

namespace DG.BotWorld.World
{
	/// <summary>
	/// The World host.
	/// </summary>
	public class Host : DG.BotWorld.Hosting.World
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="Host"/> class instance.
		/// </summary>
		public Host()
		{
			EnvironmentAssemblySaved += new EventHandler<EnvironmentAssemblySavedEventArgs>(Host_EnvironmentAssemblySaved);
			BotAssemblySaved += new EventHandler<BotAssemblySavedEventArgs>(Host_BotAssemblySaved);
			EnvironmentRan += new EventHandler<EnvironmentRanEventArgs>(Host_EnvironmentRan);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the current host.
		/// </summary>
		public static Host Current
		{
			get;
			private set;
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Initialize the host.
		/// </summary>
		public static void Initialize()
		{
			Current = new Host();
			Current.InitializeInstance();
		}

		/// <summary>
		/// Gets the bots ranking.
		/// </summary>
		/// <returns>The bots ranks list.</returns>
		public BotRank[] GetBotsRanking()
		{
			throw new NotImplementedException ();
			//return CollapseBotRankingsToBotRank(BotRankingPersister.GetAllBotRanking());
		}

		/// <summary>
		/// Gets the bot ranking for environment.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="environment">The environment.</param>
		/// <returns>The bot rank.</returns>
		public BotRank GetBotRankingForEnvironment(IBot bot, IEnvironment environment)
		{
			throw new NotImplementedException ();
//			var brs = CollapseBotRankingsToBotRank(BotRankingPersister.GetBotRankingsForEnvironment(bot.Name, environment.Name));
//
//			if (brs.Length == 0)
//			{
//				return null;
//			}
//
//			return brs[0];
		}
		#endregion

		#region Private methods
		void Host_EnvironmentRan(object sender, EnvironmentRanEventArgs e)
		{
			var environment = e.Environment;
			var bots = e.Bots;

			// Save the bots ranking.
			var botsRanking = environment.GetBotsRanking();

			if (botsRanking != null && botsRanking.Length > 0 && botsRanking.All(br => br != null))
			{
				foreach (BotRank br in botsRanking)
				{
					//BotRankingPersister.SaveBotRanking(br.Bot.Name, environment.Name, br.Score);
				}
			}
			else
			{
				foreach (IBot b in bots)
				{
					//BotRankingPersister.SaveBotRanking(b.Name, environment.Name, 0);
				}
			}
		}

		void Host_EnvironmentAssemblySaved(object sender, DG.BotWorld.Hosting.EnvironmentAssemblySavedEventArgs e)
		{
			//EnvironmentPersister.SaveEnvironment(e.Environment.Name);
		}

		void Host_BotAssemblySaved(object sender, DG.BotWorld.Hosting.BotAssemblySavedEventArgs e)
		{            
			//BotPersister.SaveBot(e.Bot.Name);
		}        

//		private BotRank[] CollapseBotRankingsToBotRank(BotRanking[] botRankings)
//		{
//			var query = from br in botRankings.GroupBy(r => r.Bot)
//						select new
//							BotRank(GetBotByName(br.Key.Name), br.Sum(s => s.Score));
//
//			return query.OrderByDescending(b => b.Score).ToArray();
//		}
		#endregion
	}
}
