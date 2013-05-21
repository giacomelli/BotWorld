using System;

namespace DG.BotWorld.Hosting
{
	public class WorldException : Exception
	{
		public WorldException (string message, Exception innerException) : base(message, innerException)
		{
		}

		public WorldException (string message) : base(message)
		{
		}
	}
}

