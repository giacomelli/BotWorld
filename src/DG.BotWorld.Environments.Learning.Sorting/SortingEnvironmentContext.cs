using System;
using DG.BotWorld.Environments.Learning.SortingSdk;
using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Learning.Sorting
{
	public class SortingEnvironmentContext : EnvironmentContextBase, ISortingEnvironmentContext
	{
		#region ISortingEnvironmentContext implementation
		public int[] Items { get; internal set; }
		#endregion
	}
}

