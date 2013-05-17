using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Hosting;
using System.Drawing.Imaging;
using System.IO;
using DG.BotWorld.World;

public static class UserHelper
{
    public static IEnvironment CurrentEnvironment
    {
        get
        {
            var e = HttpContext.Current.Session["CURRENT_ENVIRONMENT"];

            if (e == null)
            {
                return null;
            }

            return (IEnvironment)e;
        }

        set
        {
            HttpContext.Current.Session["CURRENT_ENVIRONMENT"] = value;
        }
    }

    public static string EnvironmentInstanceId
    {
        get
        {
            return HttpContext.Current.Session["EnvironmentInstanceId"].ToString();
        }

        set
        {
            HttpContext.Current.Session["EnvironmentInstanceId"] = value;
        }
    }

    public static string EnvironmentTempDir
    {
        get
        {
            return String.Format(@"{0}\Temp\Environments\{1}", AppDomain.CurrentDomain.BaseDirectory, EnvironmentInstanceId);
        }
    }

    public static string EnvironmentTempVirtualDir
    {
        get
        {
            return String.Format("../Temp/Environments/{0}", EnvironmentInstanceId);
        }
    }

    public static string SaveCurrentEnvironmentRenderedImage()
    {
        var fileName = String.Format("{0}{1}.jpg", DateTime.Now.Ticks, Host.Current.Context.Cycle);
        string filePath = Path.Combine(EnvironmentTempDir, fileName);

        var environment = UserHelper.CurrentEnvironment;
        var image = Host.Current.RenderEnvironmentToImage(environment);

        image.Save(filePath, ImageFormat.Jpeg);
        image.Dispose();

        return fileName;
    }
}
