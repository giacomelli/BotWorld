@echo "<DEPLOY ENVIRONMENT RENDERER>"

mkdir "%3DG.BotWorld.World.MvcApp\World\Sources\Environments\%1\Renderers"
copy "%2" "%3DG.BotWorld.World.MvcApp\World\Sources\Environments\%1\Renderers"

mkdir "%3DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Environments\%1\Renderers"
copy "%2" "%3DG.BotWorld.WorldMatrix.WinApp\bin\debug\World\Sources\Environments\%1\Renderers"

@echo "</DEPLOY ENVIRONMENT RENDERER>"