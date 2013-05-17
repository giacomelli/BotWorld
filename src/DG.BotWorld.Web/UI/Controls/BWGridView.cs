using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DG.BotWorld.Web.UI.Controls
{    
	/// <summary>
	/// A grid view control.
	/// </summary>
	[ToolboxData("<{0}:BWGridView runat=server></{0}:BWGridView>")]
	public class BWGridView : GridView
	{
		/// <summary>
		/// Initialize a new <see cref="BWGridView"/> instance.
		/// </summary>
		public BWGridView()
		{
			BackColor = Color.White;
			BorderColor = ColorTranslator.FromHtml("#DEDFDE");
			BorderStyle = BorderStyle.None;
			BorderWidth = 1;
			CellPadding = 4;
			ForeColor = Color.Black;
			GridLines = GridLines.Vertical;
			RowStyle.BackColor = ColorTranslator.FromHtml("#F7F7DE");
			FooterStyle.BackColor = ColorTranslator.FromHtml("#CCCC99");
			
			PagerStyle.BackColor = ColorTranslator.FromHtml("#F7F7DE");
			PagerStyle.ForeColor = Color.Black;
			PagerStyle.HorizontalAlign = HorizontalAlign.Right;
			
			SelectedRowStyle.BackColor = ColorTranslator.FromHtml("#CE5D5A");
			SelectedRowStyle.Font.Bold = true;
			SelectedRowStyle.ForeColor = Color.White;

			HeaderStyle.BackColor = ColorTranslator.FromHtml("#6B696B");
			HeaderStyle.Font.Bold = true;
			HeaderStyle.ForeColor = Color.White;

			AlternatingRowStyle.BackColor = Color.White;            
		}
	}
}
