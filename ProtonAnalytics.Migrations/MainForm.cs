using ProtonAnalytics.Migrations.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtonAnalytics.Migrations
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnRunMigrations_Click(object sender, EventArgs e)
        {
            this.txtResults.Clear();

            var connectionString = ConfigurationManager.ConnectionStrings["Defaultconnection"].ConnectionString;
            var wrapper = new MigrationsWrapper(connectionString, this.txtResults.AppendText);

            this.txtResults.AppendText(string.Format("Database is currently at migration number {0}; latest version is {1}\r\n", wrapper.CurrentVersionNumber, wrapper.LatestVersionNumber));
            wrapper.MigrateToLatestVersion();
            this.txtResults.AppendText(string.Format("Migrated to migration number {0}\r\n", wrapper.CurrentVersionNumber));
        }
    }
}
