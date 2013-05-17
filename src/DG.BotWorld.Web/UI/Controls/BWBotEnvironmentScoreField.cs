using System;
using System.Globalization;
using System.Web.UI;
using DG.BotWorld.BotSdk;
using DG.BotWorld.World;

namespace DG.BotWorld.Web.UI.Controls
{
	/// <summary>
	/// A score field for a bot on a environment.
	/// </summary>
	public class BWBotEnvironmentScoreField : BWScoreField
	{
		#region Properties		
		/// <summary>
		/// Gets or sets the name of the environment.
		/// </summary>
		/// <value>
		/// The name of the environment.
		/// </value>
		public string EnvironmentName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the text that is displayed in the header of a data control.
		/// </summary>
		/// <returns>
		/// The text displayed in the header of a data control. The default value is an empty string ("").
		///   </returns>
		public override string HeaderText
		{
			get
			{
				return String.Format(CultureInfo.CurrentUICulture, "{0} score", EnvironmentName);
			}
			set
			{
				base.HeaderText = value;
			}
		}
		#endregion

		#region Methods		
		/// <summary>
		/// Retorna o valor do campo para ser visualizado
		/// </summary>
		/// <param name="controlContainer">O container do campo.</param>
		/// <returns>
		/// O valor do campo.
		/// </returns>
		protected override object GetValue(Control controlContainer)
		{
			var bot = base.GetValue(controlContainer) as IBot;
			float score = 0;

			if (bot != null)
			{
				var botRank = Host.Current.GetBotRankingForEnvironment(bot, Host.Current.GetEnvironmentByName(EnvironmentName));

				if (botRank != null)
				{
					score = botRank.Score;
				}                
			}

			return score.ToString("N2");
		}
		#endregion
	}
}
