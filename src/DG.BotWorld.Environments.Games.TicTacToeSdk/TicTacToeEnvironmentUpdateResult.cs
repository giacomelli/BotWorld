using DG.BotWorld.BotSdk;

namespace DG.BotWorld.Environments.Games.TicTacToeSdk
{
	/// <summary>
	/// Represents a result for environment.
	/// </summary>
	public class TicTacToeEnvironmentUpdateResult
	{
		/// <summary>
		/// Gets or sets the winner.
		/// </summary>
		/// <value>
		/// The winner.
		/// </value>
		public IBot Winner
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether is drawn.
		/// </summary>
		/// <value>
		///   <c>true</c> if is drawn; otherwise, <c>false</c>.
		/// </value>
		public bool IsDrawn
		{
			get;
			set;
		}
	}
}
