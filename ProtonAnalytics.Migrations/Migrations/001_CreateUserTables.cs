using FluentMigrator;
using ProtonAnalytics.Controllers;
using ProtonAnalytics.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace ProtonAnalytics.Migrations.Migrations
{
    [Migration(1)]
    public class CreateUserTables : Migration
    {
        public override void Up()
        {
            // Invoke Entity Framework to create Aspnet_* tables
            // There's no easy, stable API to do this. So create/delete a user.
            // Since this is Web API based, just make an API call. Crazy? Maybe.
            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["ApiRootUrl"]);

            var request = new RestRequest("Account/Register", Method.POST);

            request.AddObject(new RegisterBindingModel()
            {
                Email = "initial@deleteme.com",
                Password = "P@ssw0rd",
                ConfirmPassword = "P@ssw0rd"
            });

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Delete.FromTable throws a null reference exception. I can't believe it.
                // Good ol' dapper to the rescue!
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.Execute("DELETE FROM [AspNetUsers]");
                }
            }
            else
            {
                throw new InvalidOperationException("Registering initial user failed. Try running iisreset if you just dropped the database.");
            }
        }

        public override void Down()
        {
            Delete.Table("__MigrationHistory");
            Delete.Table("AspNetRoles");
            Delete.Table("AspNetUserClaims");
            Delete.Table("AspNetUserLogins");
            Delete.Table("AspNetUserRoles");
            Delete.Table("AspNetUsers");
        }
    }
}
