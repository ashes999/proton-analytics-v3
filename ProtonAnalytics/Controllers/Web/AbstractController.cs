using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtonAnalytics.Controllers.Web
{
    public abstract class AbstractController : Controller
    {
        protected IRestResponse ExecuteApiCall(string actionUrl, RestSharp.Method method = Method.GET, object parameters = null)
        {
            var request = new RestRequest(actionUrl, method);
            if (parameters != null)
            {
                request.AddObject(parameters);
            }

            var client = new RestClient(ConfigurationManager.AppSettings["ApiRootUrl"]);

            var cookies = Session["AuthCookies"] as IList<RestResponseCookie>;
            if (cookies != null)
            {
                client.CookieContainer = new System.Net.CookieContainer();

                foreach (var cookie in cookies)
                {
                    client.CookieContainer.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                }
            }

            var response = client.Execute(request);
            return response;
        }

        protected void AddFlash(string message)
        {
            ViewBag.Flash = message;  // shows on non-redirects
            TempData["Flash"] = message; // shows on redirects
        }

        protected string GetWebApiErrorDetails(IRestResponse response)
        {
            var content = JsonConvert.DeserializeObject<JObject>(response.Content);
            // TODO: WebAPI, why do you mock me so?
            var errors = content["ModelState"][""][0].Value<string>();
            return errors;
        }
    }
}