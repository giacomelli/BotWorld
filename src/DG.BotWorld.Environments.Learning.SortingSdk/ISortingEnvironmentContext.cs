using System;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Learning.SortingSdk
{
	/// <summary>
	/// Defines a interface for the Sorting environemnt context.
	/// </summary>
	public interface ISortingEnvironmentContext : IEnvironmentContext
	{
		int[] Items { get; }
	}
}