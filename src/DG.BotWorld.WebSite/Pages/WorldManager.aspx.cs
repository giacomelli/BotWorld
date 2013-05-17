using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DG.BotWorld.Hosting;
using System.Reflection;
using DG.BotWorld.BotSdk;
using AjaxControlToolkit;
using System.IO;
using DG.BotWorld.World;

public partial class Pages_WorldManager : BWPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grvEnvironments.DataSource = Host.Current.Environments;
            grvEnvironments.DataBind();

            grvBots.DataSource = Host.Current.Bots;
            grvBots.DataBind();
        }        
    }

    protected void grvBotAbilities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var r = e.Row;

        if (r.RowType == DataControlRowType.DataRow)
        {
            var tp = r.DataItem.GetType();

            var interfaceType = tp.GetInterfaces().Where(t => t.GetInterfaces().Count(i => i.Equals(typeof(IBotAbility))) > 0).First();
            r.Cells[0].Text = interfaceType.ToString();
            r.Cells[1].Text = tp.ToString();            
        }
    }
    #region Environment upload
    protected void asyncUploadEnvironment_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
    {
        var dir = Host.Current.CreateEnvironmentInJudgmentDir();
        var environmentAssemblyFileName = Path.Combine(dir, Path.GetFileName(e.filename));
        asyncUploadEnvironment.SaveAs(environmentAssemblyFileName);

        if (Host.Current.SaveEnvironmentAssembly(environmentAssemblyFileName))
        {

            Alert("The uploaded file is a corret environment assembly.");
        }
        else
        {
            Alert("The uploaded file is NOT a corret environment assembly.");
        }
    }
    #endregion

    #region Bot upload
    protected void asyncUploadBot_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
    {
        var dir = Host.Current.CreateBotInJudgmentDir();
        var botAssemblyFileName = Path.Combine(dir, Path.GetFileName(e.filename));
        asyncUploadBot.SaveAs(botAssemblyFileName);

        if (Host.Current.SaveBotAssembly(botAssemblyFileName))
        {
            
            Alert("The uploaded file is a corret bot assembly.");
        }
        else
        {
            Alert("The uploaded file is NOT a corret bot assembly.");
        }                
    }

    protected void asyncUploadBot_UploadedFileError(object sender, AsyncFileUploadEventArgs e)
    {

    }
    #endregion

    #region Bot ability upload
    protected void asyncUploadBotAbility_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
    {
        var bot = Host.Current.GetBotByName(grvBots.SelectedValue.ToString());
        var dir = Host.Current.CreateBotAbilitiesInJudgmentDir(bot);
        var botAbilityAssemblyFileName = Path.Combine(dir, Path.GetFileName(e.filename));
        asyncUploadBotAbility.SaveAs(botAbilityAssemblyFileName);

        if (Host.Current.SaveBotAbilityAssembly(bot, botAbilityAssemblyFileName))
        {

            Alert("The uploaded file is a corret bot ability assembly.");
        }
        else
        {
            Alert("The uploaded file is NOT a corret bot ability assembly.");
        }
    }
    protected void asyncUploadBotAbility_UploadedFileError(object sender, AsyncFileUploadEventArgs e)
    {

    }
    #endregion

    protected void grvBots_SelectedIndexChanged(object sender, EventArgs e)
    {
        asyncUploadBotAbility.Visible = true;
        grvBotAbilities.DataSource = Host.Current.GetBotAbilitiesByBotName(grvBots.SelectedValue.ToString());
        grvBotAbilities.DataBind();
    }

    protected void grvBots_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {        
        var bot = Host.Current.Bots[e.RowIndex];
        Host.Current.DeleteBot(bot);           
    }

    protected void grvBotAbilities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var bot = Host.Current.GetBotByName(grvBots.SelectedValue.ToString());
        var interfaceType = grvBotAbilities.Rows[e.RowIndex].Cells[0].Text;
        var botAbility = Host.Current.GetBotAbilityByInterfaceType(bot, interfaceType);
        Host.Current.DeleteBotAbility(bot, botAbility); 
    }
}
