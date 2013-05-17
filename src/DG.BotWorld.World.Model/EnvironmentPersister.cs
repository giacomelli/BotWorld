using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.BotWorld.World.Model
{
    public static class EnvironmentPersister
    {
        public static void SaveEnvironment(string name)
        {
            using (var ctx = new Entities())
            {
                var query = from b in ctx.Environment
                            where b.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                            select b;

                Environment environment = query.FirstOrDefault();

                if (environment == null)
                {
                    environment = new Environment();
                    environment.Name = name;
                    ctx.AddToEnvironment(environment);
                    ctx.SaveChanges(true);
                }
            }
        }

        public static Environment GetEnvironment(string name)
        {
            using (var ctx = new Entities())
            {
                var query = from b in ctx.Environment
                            where b.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                            select b;

                Environment environment = query.FirstOrDefault();

                if (environment != null)
                {
                    ctx.Detach(environment);
                }

                return environment;
            }
        }
    }
}
