using System.IO;
using DG.BotWorld.Hosting;

namespace DG.BotWorld.WorldMatrix
{
	/// <summary>
	/// The World host.
	/// </summary>
	public class Host : World
	{
		#region Fields
		private static Host s_current;
		#endregion

		#region Methods
		private static void Initialize()
		{       
			if (!IsInitialized) {
				s_current = new Host ();
				try {
					s_current.InitializeInstance ();
				} catch (DirectoryNotFoundException ex) {
					if (!ex.Message.Contains (@"\IDE\")) {
						throw ex;
					}
				}

				IsInitialized = true;
			}
		}
		#endregion

		#region Properties
		public static bool IsInitialized  { get; set; } 
		/// <summary>
		/// Gets the current host.
		/// </summary>
		public static Host Current
		{
			get{
				if (s_current == null) {
					Initialize ();
				}

				return s_current;
			}
		}
		#endregion
	}
}
