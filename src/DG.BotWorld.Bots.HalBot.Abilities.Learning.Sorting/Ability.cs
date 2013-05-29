using System;
using DG.BotWorld.Environments.Learning.SortingSdk;
using DG.BotWorld.BotSdk;
using System.ComponentModel.Composition;

namespace DG.BotWorld.Bots.HalBot.Abilities.Learning.Sorting
{
	[Export(typeof(IBotAbility))]
	public class Ability : ISortingBotAbility
	{
		#region Fields
		private Random m_random = new Random(DateTime.Now.Millisecond);
		private ISortingEnvironmentContext m_context;
		#endregion

//		for i = 1:n,
//		swapped = false
//			for j = n:i+1, 
//			if a[j] < a[j-1], 
//			swap a[j,j-1]
//			swapped = true
//				→ invariant: a[1..i] in final position
//				break if not swapped
//					end

		#region ISortingBotAbility implementation
		public SwapResult SwapItems ()
		{
			var result = new SwapResult ();
			var items = m_context.Items;

			for (int i = 0; i < items.Length; i++) {

				for (int j = items.Length - 1; j > i; j--) {
					if (items [j] < items [j - 1]) {
						result.FirstItemIndex = j;
						result.SecondItemIndex = j - 1;

						return result;
					}
				}
			}
					
			return result;
		}
		#endregion
		#region IBotAbility implementation
		public void Initialize (IEnvironmentContext context)
		{
			m_context = (ISortingEnvironmentContext) context;
		}
		#endregion
	}
}