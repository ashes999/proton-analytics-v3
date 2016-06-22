using Newtonsoft.Json;
using ProtonAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtonAnalytics.Controllers.Web
{
    [Authorize]
    public class GamesController : AbstractAuthenticatedController
    {
        // GET: Game
        public ActionResult Index()
        {
            // API calls are done by Angular directly
            return View();
        }
    }
}