@echo "<DEPLOY ENVIRONMENT SDK>"

mkdir "%2DG.BotWorld.World.MvcApp\World\Sources\Environments"
copy "%1" "%2DG.BotWorld.World.MvcApp\World\Sources\Environments"

mkdir "%2DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Environments"
copy "%1" "%2DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Environments"

@echo "</DEPLOY ENVIRONMENT SDK>"