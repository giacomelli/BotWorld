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
		
		#region ISortingBotAbility implementation
		public SwapResult SwapItems ()
		{
			var result = new SwapResult ();
			result.FirstItemIndex = m_random.Next (0, m_context.Items.Length);
			result.SecondItemIndex = m_random.Next (0, m_context.Items.Length);

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