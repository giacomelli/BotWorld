#region Usings
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.HtmlControls;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.Hosting;
using DG.Framework.ExceptionHandling;
using DG.Framework.IO.Compression;
using System.Collections.Generic;
using DG.BotWorld.BotSdk;
using DG.BotWorld.World;
#endregion

public partial class Pages_EnvironmentRunner : System.Web.UI.Page
{    
    #region Carregamento
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserHelper.CurrentEnvironment == null)
        {
            Response.Redirect("Home.aspx");
        }

        if (!IsPostBack)
        {
            SelectedBots = new List<IBot>();
            Restart();
        }
    }
    #endregion

    #region Propriedades
    private List<IBot> SelectedBots
    {
        get
        {
            return (List<IBot>)Session["SELECTED_BOTS"];
        }

        set
        {
            Session["SELECTED_BOTS"] = value;
        }
    }    
    #endregion

    #region Manipuladores de eventos
    protected void btnPlayTurn_Click(object sender, EventArgs e)
    {
        Message.InnerText = String.Format("Bot '{0}' is thinking. Please, wait...", grvAvailableBots.SelectedValue);          
        
        btnPlayTurn.Enabled = false;
    }

    protected void btnRestart_Click(object sender, EventArgs e)
    {
        Restart();
    }

    protected void btnGetMoves_Click(object sender, EventArgs e)
    {
        ZipHelper.CreateZipByDirectory(UserHelper.EnvironmentTempDir);

        Message.InnerHtml = String.Format("<a href='{0}.zip'>Click here to download cycles</a>", UserHelper.EnvironmentTempVirtualDir);
    }  
    #endregion

    #region Operações
    private void Restart()
    {
        var startDateTime = DateTime.Now;
    	UserHelper.EnvironmentInstanceId = Guid.NewGuid().ToString();
        Directory.CreateDirectory(UserHelper.EnvironmentTempDir);
        FirstStepBoard.Src = null;
        LastStepBoard.Src = null;
            
        var environment = UserHelper.CurrentEnvironment;
        
        Host.Current.InitializeEnvironment(environment);

        grvAvailableBots.DataSource = Host.Current.GetBotsForEnvironment(environment);
        grvAvailableBots.DataBind();
        grvAvailableBots.SelectedIndex = 0;

        DisplayImageBoard(FirstStepBoard);

        btnPlayTurn.Enabled = true;
        btnGetMoves.Enabled = false;

        var diff = DateTime.Now - startDateTime;
        Message.InnerText = String.Format("Environment generated in {0}  seconds.", diff.TotalSeconds);
    }

    private void DisplayImageBoard(HtmlImage board)
    {
        var fileName = UserHelper.SaveCurrentEnvironmentRenderedImage();

        board.Attributes["src"] = String.Format("{0}/{1}", UserHelper.EnvironmentTempVirtualDir, Path.GetFileName(fileName));
    }    
    #endregion    

    protected void grvAvailableBots_SelectedIndexChanged(object sender, EventArgs e)
    {
        var bot = Host.Current.GetBotByName(grvAvailableBots.SelectedValue.ToString());

        if (!SelectedBots.Contains(bot))
        {
            var environment = UserHelper.CurrentEnvironment;
            SelectedBots.Add(bot);
                        
            if (SelectedBots.Count > environment.MaxBotsNumber)
            {
                SelectedBots.RemoveAt(0);
            }
                        
            grvSelectedBots.DataSource = SelectedBots;
            grvSelectedBots.DataBind();

            UpdateButtonsDisplay();
        }        

        grvAvailableBots.SelectedIndex = -1;
    }

    private void UpdateButtonsDisplay()
    {
        btnPlayTurn.Enabled = SelectedBots.Count >= UserHelper.CurrentEnvironment.MinBotsNumber;
        btnPlayTurn.CssClass = btnPlayTurn.Enabled ? "Button" : "ButtonDisabled";
    }

    protected void grvSelectedBots_SelectedIndexChanged(object sender, EventArgs e)
    {
        var bot = Host.Current.GetBotByName(grvSelectedBots.SelectedValue.ToString());

        if (SelectedBots.Contains(bot))
        {
            SelectedBots.Remove(bot);
            grvSelectedBots.DataSource = SelectedBots;
            grvSelectedBots.DataBind();

            UpdateButtonsDisplay();
        }

        grvSelectedBots.SelectedIndex = -1;
    }

    protected void btnPlayTurn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            var environment = UserHelper.CurrentEnvironment;

            Host.Current.RunEnvironment(environment, SelectedBots.ToArray());
            var bot = SelectedBots[0];

            switch (environment.State)
            {
                case EnvironmentState.Aborted:
                    Message.InnerText = String.Format("The environment's execution has been aborted, because the bot '{0}' has exceeded {1} allowed cycles.", bot.Name, environment.MaxUpdateCycles);
                    break;

                case EnvironmentState.Finished:
                    Message.InnerText = String.Format("Bot '{0}' has won in {1} cycles.", bot.Name, Host.Current.Context.Cycle);
                    break;
            }

            btnGetMoves.Enabled = true;
            DisplayImageBoard(LastStepBoard);
            btnPlayTurn.Enabled = true;
        }
        catch (Exception ex)
        {
            Message.InnerText = ExceptionHelper.GetCompleteRecursiveMessage(ex);
            return;
        }
    }    
}
