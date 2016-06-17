using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtonAnalytics.Migrations.Migrations
{
    [Migration(1)]
    public class CreateUserTables : Migration
    {
        public override void Up()
        {
            // TODO: invoke Entity Framework to create Aspnet_* tables
        }

        public override void Down()
        {
            // TODO: delete the auto-created tables
        }
    }
}
