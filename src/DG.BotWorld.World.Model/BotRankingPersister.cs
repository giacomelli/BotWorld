using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.BotWorld.World.Model
{
    public static class BotRankingPersister
    {
        public static BotRanking[] GetBotRankings(string botName)
        {
            using (var ctx = new Entities())
            {
                var query = from br in ctx.BotRanking.Include("Bot").Include("Environment")
                            where br.Bot.Name.Equals(botName, StringComparison.OrdinalIgnoreCase)
                            select br;

                return query.ToArray();                
            }
        }

        public static BotRanking[] GetAllBotRanking()
        {
            using (var ctx = new Entities())
            {
                var brs = ctx.BotRanking.Include("Bot").Include("Environment").ToArray();

                return brs;
            }
        }

        public static void SaveBotRanking(string botName, string environmentName, float score)
        {
            using (var ctx = new Entities())
            {
                BotRanking br = new BotRanking();
                var bot = BotPersister.GetBot(botName);
                ctx.Attach(bot);
                br.Bot = bot;

                var environment = EnvironmentPersister.GetEnvironment(environmentName);
                ctx.Attach(environment);
                br.Environment = environment;

                br.Score = score;

                ctx.AddToBotRanking(br);
                ctx.SaveChanges(true);
            }
        }

        public static BotRanking[] GetBotRankingsForEnvironment(string botName, string environmentName)
        {
            using (var ctx = new Entities())
            {
                var query = from br in ctx.BotRanking.Include("Bot").Include("Environment")
                            where br.Bot.Name.Equals(botName, StringComparison.OrdinalIgnoreCase) 
                            && br.Environment.Name.Equals(environmentName, StringComparison.OrdinalIgnoreCase)
                            select br;

                return query.ToArray();
            }
        }
    }
}
