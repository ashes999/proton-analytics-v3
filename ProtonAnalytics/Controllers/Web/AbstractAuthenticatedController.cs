using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProtonAnalytics.Controllers.Web
{
    [Authorize]
    public class AbstractAuthenticatedController : AbstractController
    {
    }
}