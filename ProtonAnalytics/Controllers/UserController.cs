using ProtonAnalytics.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProtonAnalytics.Controllers
{
    public class UserController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = new RestRequest("Account/Login", Method.POST);
            request.AddObject(model);

            var client = new RestClient(ConfigurationManager.AppSettings["ApiRootUrl"]);
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                HttpContext.User = new GenericPrincipal(new GenericIdentity(model.Email), null);
                return Redirect("~/");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }
    }
}