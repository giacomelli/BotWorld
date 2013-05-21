using System;
using System.Collections.Generic;
using System.Linq;
using DG.BotWorld.BotSdk;
using DG.BotWorld.EnvironmentSdk;
using HelperSharp;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// The World Context.
	/// </summary>
	public class WorldContext : IWorldContext
	{
		#region Fields
		private Dictionary<IBot, IBotAbility[]> m_botsAbilities;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="WorldContext"/> instance.
		/// </summary>
		public WorldContext()
		{
			m_botsAbilities = new Dictionary<IBot, IBotAbility[]>();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the cycle.
		/// </summary>
		public int Cycle
		{
			get;
			internal set;
		}

		/// <summary>
		/// Gets the number of bots.
		/// </summary>
		/// <value>The bots count.</value>
		public int BotsCount
		{
			get {
				return m_botsAbilities.Count;
			}
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Adds the bot to the World.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="abilities">The bot's abilities.</param>
		public void AddBot(IBot bot, params IBotAbility[] abilities)
		{
			ExceptionHelper.ThrowIfNull ("bot", bot);

			if (abilities == null || abilities.Length == 0) {
				throw new InvalidOperationException("The bot '{0}' should have abilities to enter in the world context.".With(bot.Name));
			}

			if (m_botsAbilities.ContainsKey (bot)) {
				throw new InvalidOperationException ("The bot '{0}' has already been added to the world context.".With(bot.Name));
			}

			m_botsAbilities.Add(bot, abilities);
		}

		/// <summary>
		/// Remove all bots from the World.
		/// </summary>
		public void ClearBots()
		{
			m_botsAbilities.Clear();
		}

		/// <summary>
		/// Gets the bots with kind of ability.
		/// </summary>
		/// <returns>The bots with kind of ability.</returns>
		/// <typeparam name="TAbilityType">The kind of ability.</typeparam>
		public IBot[] GetBotsWithKindOfAbility<TAbilityType>() where TAbilityType : IBotAbility
		{
			var abilityTypeFullName = typeof(TAbilityType).FullName;
			var query = from ba in m_botsAbilities
				where ba.Value.Count(a => a.GetType().GetInterface(abilityTypeFullName) != null) > 0
						select ba.Key;

			return query.ToArray();
		}

		/// <summary>
		/// Gets the bot ability instance for bot and ability type specified.
		/// </summary>
		/// <returns>The bot abilityy.</returns>
		/// <param name="bot">Bot.</param>
		/// <typeparam name="TAbilityType">The kind of ability.</typeparam>
		public TAbilityType GetBotAbility<TAbilityType>(IBot bot) where TAbilityType : IBotAbility
		{
			ExceptionHelper.ThrowIfNull ("bot", bot);

			if (!m_botsAbilities.ContainsKey (bot)) {
				throw new ArgumentException("Bot '{0}' is not in the world context.".With(bot.Name));
			}

			var abilities = m_botsAbilities[bot];
			var abilityTypeFullName = typeof(TAbilityType).FullName;

			var abilityQuery = from a in abilities
				where a.GetType().GetInterface(abilityTypeFullName) != null
							   select a;

			return (TAbilityType)abilityQuery.FirstOrDefault();
		}
		#endregion
	}
}   
