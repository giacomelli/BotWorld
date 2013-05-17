using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DG.BotWorld.Hosting;
using DG.BotWorld.EnvironmentSdk;
using DG.BotWorld.BotSdk;
using DG.BotWorld.World;

public partial class Pages_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserHelper.CurrentEnvironment = null;
            grvEnvironments.DataSource = Host.Current.Environments;
            grvEnvironments.DataBind();

            grvBotsRanking.DataSource = Host.Current.GetBotsRanking();
            grvBotsRanking.DataBind();
        }
    }

    protected void grvEnvironments_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserHelper.CurrentEnvironment = Host.Current.GetEnvironmentByName(grvEnvironments.SelectedValue.ToString());
        Response.Redirect("EnvironmentRunner.aspx");
    }

    public string GetBotImageUrl(object bot)
    {
        var b = (IBot)bot;

        return WebSiteBotHelper.GetBotImageUrl(b.Name);
    }
}
