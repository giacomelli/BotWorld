using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DG.BotWorld.World;
using DG.BotWorld.Hosting;

namespace MvcApplication7.Controllers
{
    public class EnvironmentsController : Controller
    {
        public ActionResult Index()
        {
			return View (Host.Current.Environments);
        }
    }
}
