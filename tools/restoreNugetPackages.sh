mono --runtime=v4.0.30319 ../src/.nuget/nuget.exe install "../src/DG.BotWorld.Hosting/packages.config" -source "" -solutionDir "" -OutputDirectory "../src/packages"

mono --runtime=v4.0.30319 ../src/.nuget/nuget.exe install "../src/DG.BotWorld.Hosting.UnitTests/packages.config" -source "" -solutionDir "" -OutputDirectory "../src/packages"

mono --runtime=v4.0.30319 ../src/.nuget/nuget.exe install "../src/DG.BotWorld.World.Model/packages.config" -source "" -solutionDir "" -OutputDirectory "../src/packages"

mono --runtime=v4.0.30319 ../src/.nuget/nuget.exe install "../src/DG.BotWorld.World.MvcApp/packages.config" -source "" -solutionDir "" -OutputDirectory "../src/packages"