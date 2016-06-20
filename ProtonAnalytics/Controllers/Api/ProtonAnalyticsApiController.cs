using ProtonAnalytics.DataAccessLayer;
using ProtonAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProtonAnalytics.Controllers.Api
{
    [Authorize]
    public class ProtonAnalyticsApiController : ApiController
    {
        protected UserWithIdModel CurrentUser
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                {
                    throw new InvalidOperationException("User is not authenticated");
                }

                var userName = User.Identity.Name;
                var repository = new ActiveRecordRepository<UserWithIdModel>();
                var user = repository.GetAll().Single(s => s.Email == userName);
                return user;
            }
        }
    }
}
