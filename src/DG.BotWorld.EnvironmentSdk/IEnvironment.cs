#region Usings
using System;
#endregion

namespace DG.BotWorld.EnvironmentSdk
{
	#region Enumeration
	/// <summary>
	/// States for a environment.
	/// </summary>
	public enum EnvironmentState
	{
		/// <summary>
		/// Environment has not been started yet.
		/// </summary>
		NotStarted,

		/// <summary>
		/// Environment is running.
		/// </summary>
		Running,

		/// <summary>
		/// Environment has been finished.
		/// </summary>
		Finished,

		/// <summary>
		/// Environment has been aborted.
		/// </summary>
		Aborted
	}
	#endregion

	/// <summary>
	/// Defines a environment for Bot World.
	/// </summary>
	public interface IEnvironment
	{
		#region Properties
		/// <summary>
		/// Gets the name.
		/// </summary>
		string Name
		{
			get;
		}

		/// <summary>
		/// Gets the description
		/// </summary>
		string Description
		{
			get;
		}

		/// <summary>
		/// Gets user interface information.
		/// </summary>        
		IEnvironmentUIInformation UIInformation
		{
			get;
		}
		
		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		EnvironmentState State
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the minimum bots number.
		/// </summary>
		int MinBotsNumber
		{
			get;            
		}

		/// <summary>
		/// Gets the maximum bots number.
		/// </summary>s
		int MaxBotsNumber
		{
			get;
		}

		/// <summary>
		/// Gets the update timeout (milliseconds).
		/// </summary>
		int UpdateTimeout
		{
			get;            
		}

		/// <summary>
		/// Gets the maximum update cycles.
		/// </summary>
		int MaxUpdateCycles
		{
			get;            
		}

		/// <summary>
		/// Gets if environment supports humans.
		/// </summary>
		bool SupportHumans
		{
			get;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Initializes the environment using the world context specified.
		/// </summary>
		/// <param name="context">The world context.</param>
		void Initialize(IWorldContext context);

		/// <summary>
		/// Initializes the round.
		/// </summary>
		/// <param name="context">The world context.</param>
		void InitializeRound(IWorldContext context);

		/// <summary>
		/// Updates the environment (run a cycle).
		/// </summary>
		/// <param name="context">The world context.</param>
		void Update(IWorldContext context);

		/// <summary>
		/// Gets the abilities needed for a bot to get in the environment.
		/// </summary>
		/// <returns>The abilities types.</returns>
		Type[] GetNeededBotAbilities();

		/// <summary>
		/// Gets the current bots ranks.
		/// </summary>
		/// <returns>The bots ranks.</returns>
		BotRank[] GetBotsRanking();
		#endregion
	}
}
