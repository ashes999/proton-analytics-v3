using Newtonsoft.Json;
using ProtonAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtonAnalytics.Controllers.Web
{
    public class GamesController : ProtonAnalyticsController
    {
        // GET: Game
        public ActionResult Index()
        {
            // API calls are done by Angular directly
            return View();
        }
    }
}