using System;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Learning.SortingSdk
{
	/// <summary>
	/// Ability to play Sorting.
	/// </summary>
	public interface ISortingBotAbility : IBotAbility
	{
		SwapResult SwapItems();
	}
}