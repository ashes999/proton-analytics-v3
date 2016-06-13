using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Moq;
using NUnit.Framework;
using ProtonAnalytics.Controllers;
using ProtonAnalytics.Models;
using System.Linq;

namespace ProtonAnalytics.UnitTests.Controllers
{
    [TestFixture]
    class AccountControllerTests
    {
        [Test]
        public void LogOutLogsOutOfAuthenticationProvider()
        {
            var authManager = new Mock<IAuthenticationManager>();
            authManager.Setup(a => a.SignOut(CookieAuthenticationDefaults.AuthenticationType));

            var controller = new AccountController(null, null, authManager.Object, null);
            var view = controller.LogOut();
            Assert.IsTrue(view is System.Web.Http.Results.OkResult);
            authManager.VerifyAll();
        }

        [Test] // TODO: needs more negative test cases
        public void LoginSignsInToSignInManager()
        {
            string userName = "test@test.com";
            string password = "P@ssw0rd";

            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            var authManager = new Mock<IAuthenticationManager>();
            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authManager.Object);
            signInManager.Setup(s => s.PasswordSignInAsync(userName, password, false, false)).ReturnsAsync(Microsoft.AspNet.Identity.Owin.SignInStatus.Success);

            var controller = new AccountController(userManager.Object, null, null, signInManager.Object);
            var result = controller.Login(new Models.LoginBindingModel() { Email = userName, Password = password });
            result.Wait();
            var view = result.Result;

            Assert.IsTrue(view is System.Web.Http.Results.OkResult);

            signInManager.VerifyAll();
        }
    }
}
