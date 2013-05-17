using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.BotWorld.World.Model
{
    public static class BotPersister
    {
        public static void SaveBot(string name)
        {
            using (var ctx = new Entities())
            {
                Bot bot = GetBot(name);

                if (bot == null)
                {
                    bot = new Bot();
                    bot.Name = name;
                    ctx.AddToBot(bot);
                    ctx.SaveChanges(true);
                }                               
            }
        }

        public static Bot GetBot(string name)
        {
            using (var ctx = new Entities())
            {
                var query = from b in ctx.Bot
                            where b.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                            select b;

                Bot bot = query.FirstOrDefault();

                if (bot != null)
                {
                    ctx.Detach(bot);
                }

                return bot;
            }
        }

    }
}
