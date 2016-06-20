using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProtonAnalytics.Helpers.Routing
{
    public class ApiRoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string ApiRootPrefix = "api";

        public ApiRoutePrefixAttribute(string prefix) : base(string.Format("{0}/{1}", ApiRootPrefix, prefix))
        {
        }
    }
}