using System.IO;
using DG.BotWorld.Hosting;

namespace DG.BotWorld.WorldMatrix
{
	/// <summary>
	/// The World host.
	/// </summary>
	public class Host : World
	{
		#region Constructors
		/// <summary>
		/// Initializes the <see cref="Host"/> class.
		/// </summary>
		static Host()
		{            
			Current = new Host();
			try
			{
				Current.InitializeInstance();
			}
			catch (DirectoryNotFoundException ex)
			{
				if (!ex.Message.Contains(@"\IDE\"))
				{
					throw ex;
				}
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the current host.
		/// </summary>
		public static Host Current
		{
			get;
			private set;
		}
		#endregion
	}
}
