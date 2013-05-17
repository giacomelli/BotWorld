using System;
using System.ComponentModel;

namespace DG.BotWorld.EnvironmentSdk
{
	/// <summary>
	/// A abstract base class for environments.
	/// </summary>
	public abstract class EnvironmentBase : IEnvironment
	{
		#region Properties
		/// <summary>
		/// Gets the name.
		/// </summary>
		[Category("Information")]
		[Description("Name")]
		public string Name
		{
			get;
			protected set;
		}

		/// <summary>
		/// Gets the description
		/// </summary>
		[Category("Information")]
		[Description("Description.")]
		public string Description
		{
			get;
			protected set;
		}

		/// <summary>
		/// Gets user interface information.
		/// </summary>
		[Browsable(false)]
		public IEnvironmentUIInformation UIInformation
		{
			get;
			protected set;
		}

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		[Browsable(false)]
		public EnvironmentState State
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the minimum bots number.
		/// </summary>
		[Category("Bots")]
		[Description("Minimum number of bots needed to run environment.")]
		public int MinBotsNumber
		{
			get;
			protected set;
		}

		/// <summary>
		/// Gets the maximum bots number.
		/// </summary>		
		[Category("Bots")]
		[Description("Maximum number of bots supported to run environment.")]
		public int MaxBotsNumber
		{
			get;
			protected set;
		}

		/// <summary>
		/// Gets the update timeout (milliseconds).
		/// </summary>
		[Category("Environment")]
		[Description("Timeout (milliseconds) to perform update.")]
		public int UpdateTimeout
		{
			get;
			protected set;
		}

		/// <summary>
		/// Gets the maximum update cycles.
		/// </summary>
		[Category("Environment")]
		[Description("Maximum update cycles supported.")]
		public int MaxUpdateCycles
		{
			get;
			protected set;
		}

		/// <summary>
		/// Gets if environment supports humans.
		/// </summary>
		[Category("Environment")]
		[Description("If environment supports humans.")]
		public bool SupportHumans
		{
			get;
			protected set;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Initializes the environment using the world context specified.
		/// </summary>
		/// <param name="context">The world context.</param>
		public abstract void Initialize(IWorldContext context);

		/// <summary>
		/// Initializes the round.
		/// </summary>
		/// <param name="context">The world context.</param>
		public abstract void InitializeRound(IWorldContext context);

		/// <summary>
		/// Updates the environment (run a cycle).
		/// </summary>
		/// <param name="context">The world context.</param>
		public abstract void Update(IWorldContext context);

		/// <summary>
		/// Gets the abilities needed for a bot to get in the environment.
		/// </summary>
		/// <returns>
		/// The abilities types.
		/// </returns>
		public abstract Type[] GetNeededBotAbilities();

		/// <summary>
		/// Gets the current bots ranks.
		/// </summary>
		/// <returns>
		/// The bots ranks.
		/// </returns>
		public abstract BotRank[] GetBotsRanking();
		#endregion
	}
}
