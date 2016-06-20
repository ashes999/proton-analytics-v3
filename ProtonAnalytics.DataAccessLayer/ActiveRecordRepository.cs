using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtonAnalytics.DataAccessLayer
{
    public class ActiveRecordRepository<T>
    {
        private string tableName = "";

        public ActiveRecordRepository()
        {
            var typeName = typeof(T).Name;
            if (typeName.ToUpperInvariant().EndsWith("MODEL"))
            {
                typeName = typeName.Substring(0, typeName.ToUpperInvariant().LastIndexOf("MODEL"));
            }

            if (typeName.ToUpperInvariant().Contains("USER"))
            {
                this.tableName = "AspNetUsers";
            }
            else
            {
                // try to pluralize
                if (!typeName.ToUpperInvariant().EndsWith("S"))
                {
                    typeName += "s";
                }

                this.tableName = typeName;
            }
        }

        public IEnumerable<T> GetAll()
        {
            var facade = new DatabaseFacade();
            return facade.ExecuteQuery<T>(string.Format("SELECT * FROM {0}", this.tableName));
        }
    }
}
