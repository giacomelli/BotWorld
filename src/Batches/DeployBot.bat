@echo "<DEPLOY BOT>"

mkdir "%2DG.BotWorld.WebSite\World\Sources\Bots"
copy "%1" "%2DG.BotWorld.WebSite\World\Sources\Bots"

mkdir "%2DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Bots"
copy "%1" "%2DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Bots"

@echo "</DEPLOY BOT>"