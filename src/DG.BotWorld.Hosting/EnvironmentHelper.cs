using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.BotWorld.EnvironmentSdk;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using HelperSharp;

namespace DG.BotWorld.Hosting
{
	/// <summary>
	/// Helper stuffs for environments.
	/// </summary>
	public static class EnvironmentHelper
	{
		/// <summary>
		/// Saves the avatar.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <param name="world">The world.</param>
		public static void SaveAvatar(IEnvironment environment, World world)
		{
			ExceptionHelper.ThrowIfNull ("environment", environment);
			ExceptionHelper.ThrowIfNull ("world", world);

			if (environment.UIInformation == null || environment.UIInformation.Avatar == null) {
				throw new ArgumentException ("Is impossible save the avatar because the environemnt has no UIInformation about it.", "environment");
			}

			string fileName = GetAvatarFilePath(environment, world);

			if (!File.Exists(fileName))
			{
				environment.UIInformation.Avatar.Save(fileName, ImageFormat.Png);
			}
		}

		/// <summary>
		/// Saves the avatar.
		/// </summary>
		/// <param name="environments">The environments.</param>
		/// <param name="world">The world.</param>
		public static void SaveAvatar(IEnvironment[] environments, World world)
		{
			foreach (var e in environments)
			{
				SaveAvatar(e, world);
			}
		}

		/// <summary>
		/// Gets the avatar file path.
		/// </summary>
		/// <param name="environment">The environment.</param>
		/// <param name="world">The world.</param>
		/// <returns></returns>
		public static string GetAvatarFilePath(IEnvironment environment, World world)
		{
			return String.Format(CultureInfo.InvariantCulture, @"{0}\{1}\Images\avatar.png", world.EnvironmentsInstanceDir, environment.Name);
		}
	}
}
