using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using DG.BotWorld.BotSdk;
using System.IO;
using System.Globalization;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Helper stuffs for bots.
	/// </summary>
	public static class BotHelper
	{
		/// <summary>
		/// Saves the avatar.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="world">The world.</param>
		public static void SaveAvatar(IBot bot, World world)
		{
			string fileName = GetAvatarFilePath(bot, world);

			if(!File.Exists(fileName))
			{
				bot.UIInformation.Avatar.Save(fileName, ImageFormat.Png);
			}
		}

		/// <summary>
		/// Saves the avatar.
		/// </summary>
		/// <param name="bots">The bots.</param>
		/// <param name="world">The world.</param>
		public static void SaveAvatar(IBot[] bots, World world)
		{
			foreach (var b in bots)
			{
				SaveAvatar(b, world);
			}
		}

		/// <summary>
		/// Gets the avatar file path.
		/// </summary>
		/// <param name="bot">The bot.</param>
		/// <param name="world">The world.</param>
		/// <returns></returns>
		public static string GetAvatarFilePath(IBot bot, World world)
		{
			return String.Format(CultureInfo.InvariantCulture, @"{0}\{1}\Images\avatar.png", world.BotsInstanceDir, bot.Name);
		}        
	}
}
