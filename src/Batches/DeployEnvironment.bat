@echo "<DEPLOY ENVIRONMENT>"

mkdir "%2DG.BotWorld.WebSite\World\Sources\Environments"
copy "%1" "%2DG.BotWorld.WebSite\World\Sources\Environments"

mkdir "%2DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Environments"
copy "%1" "%2DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Environments"

@echo "</DEPLOY ENVIRONMENT>"