using ProtonAnalytics.DataAccessLayer;
using ProtonAnalytics.Helpers.Routing;
using ProtonAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProtonAnalytics.Controllers.Api
{
    [ApiRoutePrefix("Game")]
    public class GameApiController : ProtonAnalyticsApiController
    {
        [Route("GetAll")]
        public IEnumerable<GameModel> GetAll()
        {
            var repository = new DataAccessLayer.ActiveRecordRepository<GameModel>();
            var currentUserId = this.CurrentUser.Id;
            var toReturn = repository.GetAll().Where(g => g.OwnerId == currentUserId);
            return toReturn;
        }
    }
}
