@echo "<DEPLOY BOT ABILITY>"

mkdir "%3DG.BotWorld.WebSite\World\Sources\Bots\%1\Abilities"
copy "%2" "%3DG.BotWorld.WebSite\World\Sources\Bots\%1\Abilities"

mkdir "%3DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Bots\%1\Abilities"
copy "%2" "%3DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Bots\%1\Abilities"

@echo "</DEPLOY BOT ABILITY>"