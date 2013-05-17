using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Games_Game : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsInWorldManager)
        {
            imgManageBots.ImageUrl = "~/Images/BackIcon.png";
            SetInformationText("Manager");
        }
        else if (IsInEnvironmentsHome)
        {
            imgEnvironmentsHome.Visible = false;
            SetInformationText("Home");
        }
        else
        {
            imgEnvironmentsHome.Visible = true;
            SetInformationText(UserHelper.CurrentEnvironment.Name);
        }

    }

    private void SetInformationText(string text)
    {
        EnvironmentInfo.Text = String.Format(CultureInfo.InvariantCulture, "&nbsp;:: {0}", text);
    }

    private bool IsInWorldManager
    {
        get
        {
            return Page.AppRelativeVirtualPath.EndsWith("WorldManager.aspx");
        }
    }

    private bool IsInEnvironmentsHome
    {
        get
        {
            return Page.AppRelativeVirtualPath.EndsWith("Home.aspx");
        }
    }

    private bool IsInEnvironmentRunner
    {
        get
        {
            return Page.AppRelativeVirtualPath.EndsWith("EnvironmentRunner.aspx");
        }
    }

    protected void imgEnvironmentsHome_Click(object sender, ImageClickEventArgs e)
    {       
       Response.Redirect("Home.aspx");              
    }

    protected void imgManageBots_Click(object sender, ImageClickEventArgs e)
    {
        if (IsInWorldManager)
        {
            Response.Redirect("EnvironmentRunner.aspx");
        }
        else
        {
            Response.Redirect("WorldManager.aspx");
        }
    }
}
