using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingDashboard
{
    public partial class FavouriteManager : Form
    {
        private Database database;

        public FavouriteManager(Database database)
        {
            this.database = database;
            InitializeComponent();

            UserNameLbl.Text = database.LogedInUser.Username;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void UserNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void FavouriteManager_Load(object sender, EventArgs e)
        {
            List<EpicFavourite> myFaves = database.GetFavorites(database.LogedInUser);

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = myFaves;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage(database);
            main.Show();
            this.Dispose();
        }
    }

}
