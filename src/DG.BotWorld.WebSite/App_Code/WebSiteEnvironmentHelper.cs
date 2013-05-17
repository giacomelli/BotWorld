using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Hosting;
using System.IO;
using System.Drawing.Imaging;
using DG.BotWorld.World;

public static class WebSiteEnvironmentHelper
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
