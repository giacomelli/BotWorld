@echo "<DEPLOY ENVIRONMENT RENDERER>"

mkdir "%3DG.BotWorld.WebSite\World\Sources\Environments\%2\Renderers"
copy "%2" "%3DG.BotWorld.WebSite\World\Sources\Environments\%2\Renderers"

mkdir "%3DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Environments\%2\Renderers"
copy "%2" "%3DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Environments\%2\Renderers"

@echo "</DEPLOY ENVIRONMENT RENDERER>"