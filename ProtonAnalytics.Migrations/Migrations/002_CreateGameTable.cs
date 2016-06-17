using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtonAnalytics.Migrations.Migrations
{
    [Migration(2)]
    public class CreateGameTable : Migration
    {
        public override void Up()
        {
            Create.Table("Games")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable().WithDefault(SystemMethods.NewGuid)
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("OwnerId").AsString(128).ForeignKey("AspNetUsers", "Id").NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Games");
        }
    }
}
