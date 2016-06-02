using NUnit.Framework;
using ProtonAnalytics.Api.Controllers;
using ProtonAnalytics.Api.FunctionalTests.Infrastructure;
using ProtonAnalytics.Web.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProtonAnalytics.Api.FunctionalTests.Controllers
{
    [TestFixture]
    class AccountControllerTests
    {
        // Workflow test
        [Test]
        public void UserCanRegisterLogIn()
        {
            var userName = "test@test.com";
            var password = "Super SECURE password!?1!";

            // Delete the user if they already exists
            DatabaseFacade.ExecuteQuery("DELETE FROM AspNetUsers WHERE email = @email", new { email = userName });

            var client = new RestSharp.RestClient("http://localhost/ProtonAnalytics.Api");

            // Register
            var request = new RestRequest("Account/Register", Method.POST);

            request.AddObject(new RegisterViewModel()
            {
                Email = userName,
                Password = password,
                ConfirmPassword = password
            });

            IRestResponse response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, response.Content);

            // Log in
            request = new RestRequest("Account/Login", Method.POST);
            request.AddObject(new LoginViewModel()
            {
                Email = userName,
                Password = password,
                RememberMe = false
            });

            response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, response.Content);
            Assert.That(response.Cookies.Count, Is.GreaterThan(0));
        }
    }
}
