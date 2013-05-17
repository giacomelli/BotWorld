using System.ComponentModel;

namespace DG.BotWorld.BotSdk
{
	/// <summary>
	/// A abstract base class for bots.
	/// </summary>
	public abstract class BotBase : IBot
	{
		#region IBot Members
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
		/// Gets user interface information.
		/// </summary>
		[Browsable(false)]
		public IBotUIInformation UIInformation
		{
			get;
			protected set;
		}           
		#endregion
	}
}
