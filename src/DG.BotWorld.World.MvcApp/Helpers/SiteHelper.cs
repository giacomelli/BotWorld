using System;
using DG.BotWorld.Hosting;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.World;

public static class SiteHelper
{
	public static string GetAvatarRelativePath(IEnvironment environment)
	{
		return EnvironmentHelper.GetAvatarFilePath(environment, Host.Current).Replace(AppDomain.CurrentDomain.BaseDirectory, "../");
	}

	public static string GetEnvironmentImageUrl(object data)
	{
		var name = data.ToString();

		return GetAvatarRelativePath(Host.Current.GetEnvironmentByName(name));
	} 
}