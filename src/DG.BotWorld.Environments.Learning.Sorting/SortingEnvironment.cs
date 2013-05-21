using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using DG.BotWorld.BotSdk;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Environments.Learning.SortingSdk;

namespace DG.BotWorld.Environments.Learning.Sorting
{
	[Export(typeof(IEnvironment))]
	public class SortingEnvironment : EnvironmentBase
	{
		#region Fields
		private SortingEnvironmentContext m_context;
		private IBot m_roundBot;
		private BotRank m_rank;
		private ISortingBotAbility m_ability;
		private int[] m_sortedItems;
		#endregion

		#region Constructors
		public SortingEnvironment()
		{
			Name = "Sorting";
			Description = "Learning space for sorting algorithms";
			var names = GetType().Assembly.GetManifestResourceNames ();

			var image = Image.FromStream (GetType().Assembly.GetManifestResourceStream(names[0]));
			UIInformation = new EnvironmentUIInformation(image);
			MinBotsNumber = 1;
			MaxBotsNumber = 1;
			UpdateTimeout = 10000;
			MaxUpdateCycles = 1000;
			MinItemsSize = 10;
			MaxItemsSize = 100;
		}
		#endregion

		#region Properties
		public int MinItemsSize { get; set; }
		public int MaxItemsSize { get; set; }
		public int[] Items 
		{
			get {
				return m_context.Items;
			}
		}
		#endregion

		#region implemented abstract members of EnvironmentBase

		public override void Initialize (IWorldContext context)
		{
			m_context = new SortingEnvironmentContext ();
			m_context.Items = GenerateItems ();
			m_sortedItems = m_context.Items.OrderBy (i => i).ToArray();
		}

		private int[] GenerateItems()
		{			
			var random = new Random (DateTime.Now.Millisecond);

			var items = new List<int> ();
			var size = random.Next (MinItemsSize, MaxItemsSize + 1);

			for(var i = 0; i < size; i++)
			{
				items.Add (random.Next ());
			}

			return items.ToArray ();
		}

		public override void InitializeRound (IWorldContext context)
		{
			m_context.Cycle = context.Cycle;
			m_roundBot = context.GetBotsWithKindOfAbility<ISortingBotAbility> () [0];
			m_ability = context.GetBotAbility<ISortingBotAbility> (m_roundBot);
			m_ability.Initialize (m_context);
		}

		public override void Update (IWorldContext context)
		{
			var result = m_ability.SwapItems ();

			int tmp = m_context.Items [result.FirstItemIndex];
			m_context.Items [result.FirstItemIndex] = m_context.Items [result.SecondItemIndex];
			m_context.Items [result.SecondItemIndex] = tmp;

			if(m_context.Items.SequenceEqual(m_sortedItems))
			{
				m_rank = new BotRank (m_roundBot, MaxUpdateCycles - context.Cycle);
				State = EnvironmentState.Finished;
			}
		}

		public override Type[] GetNeededBotAbilities ()
		{
			return new Type[] { typeof(ISortingBotAbility) };
		}

		public override BotRank[] GetBotsRanking ()
		{
			return new BotRank[] { m_rank };
		}
		#endregion
	}
}