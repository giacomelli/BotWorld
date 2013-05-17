using System.Web.UI.WebControls;

namespace DG.BotWorld.Web.UI.Controls
{
	/// <summary>
	/// A score field control.
	/// </summary>
	public class BWScoreField : DG.Framework.Web.UI.Controls.DGBoundField
	{
		/// <summary>
		/// Initializes a new <see cref="BWScoreField"/> instance.
		/// </summary>
		public BWScoreField()
		{
			DataFormatString = "{0:n2}";
			ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
	}
}
