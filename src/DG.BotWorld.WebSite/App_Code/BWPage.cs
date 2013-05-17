using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BWPage : System.Web.UI.Page
{
    public void Alert(string msg)
    {
        JSHelper.Alert(this, msg);
    }
}
