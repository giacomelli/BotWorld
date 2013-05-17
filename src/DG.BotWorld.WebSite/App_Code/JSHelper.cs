using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

public static class JSHelper
{
    public static void Alert(Control ctrl, string msg)
    {
        ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "alert(\"" + msg + "\");", true);
    }
}
