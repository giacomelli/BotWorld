using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DG.BotWorld.BotSdk;
using System.IO;
using System.Drawing.Imaging;
using DG.BotWorld.Hosting;
using DG.BotWorld.World;

public static class WebSiteBotHelper
{
    public static string GetAvatarRelativePath(IBot bot)
    {
        return DG.BotWorld.Hosting.BotHelper.GetAvatarFilePath(bot, Host.Current).Replace(AppDomain.CurrentDomain.BaseDirectory,  "../");
    }

     public static string GetBotImageUrl(object data)
     {
         string name;
         var bot = data as IBot;

         if (bot == null)
         {             
             name = data.ToString();
         }
         else
         {
             name = bot.Name;
         }

         return GetAvatarRelativePath(Host.Current.GetBotByName(name));
     }

     public static string GetBotName(object data)
     {         
         var bot = data as IBot;

         if (bot == null)
         {
             return data.ToString();
         }
         else
         {
             return bot.Name;
         }     
     }

     public static string GetBotScoreForEnvironment(object botData, string environmentName)
     {
         var bot = botData as IBot;

         if (bot == null)
         {
             return "0.00";
         }
         else
         {
             var botRank = Host.Current.GetBotRankingForEnvironment(bot, Host.Current.GetEnvironmentByName(environmentName));

             if (botRank == null)
             {
                 return "0.00";
             }

             return botRank.Score.ToString("N2");
         }  
     }

}
