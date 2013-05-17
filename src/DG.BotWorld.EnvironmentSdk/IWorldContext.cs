using System;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.EnvironmentSdk
{
	/// <summary>
	/// Defines a interface for a world context.
	/// </summary>
	public interface IWorldContext
	{
		#region Properties
		/// <summary>
		/// Gets the cycle.
		/// </summary>
		int Cycle
		{
			get;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Gets the bots with kind of ability.
		/// </summary>
		/// <returns>The bots with kind of ability.</returns>
		/// <typeparam name="TAbilityType">The kind of ability.</typeparam>
		IBot[] GetBotsWithKindOfAbility<TAbilityType> () where TAbilityType : IBotAbility;

		/// <summary>
		///  Gets the bot ability instance for bot and ability type specified.
		/// </summary>
		/// <returns>The bot abilityy.</returns>
		/// <param name="bot">Bot.</param>
		/// <typeparam name="TAbilityType">The kind of ability.</typeparam>
		IBotAbility GetBotAbility<TAbilityType>(IBot bot) where TAbilityType : IBotAbility;
		#endregion
	}
}
