using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtonAnalytics.Web.Controllers
{
    public class ProtonAnalyticsController : Controller
    {
        protected RestClient restClient;

        public ProtonAnalyticsController()
        {
            this.restClient = new RestClient();
            var apiRoot = ConfigurationManager.AppSettings["ApiRoot"];
            this.restClient = new RestClient(apiRoot);
        }
    }
}