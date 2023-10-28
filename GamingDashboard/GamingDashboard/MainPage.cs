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
    public partial class MainPage : Form
    {
        private Database database;
        public MainPage(Database database)
        {
            this.database = database;
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            UserNameLbl.Text = database.LogedInUser.Username;
        }

        private void EpicSalesBtn_Click(object sender, EventArgs e)
        {
            //Opens new epic specials page 
            EpicSpecialExclusive epic = new EpicSpecialExclusive(database);
            epic.Show();
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void ManageAccountBtn_Click(object sender, EventArgs e)
        {
            UserManagementDashboard userManager = new UserManagementDashboard(database);
            userManager.Show();
            this.Dispose();
        }

        private void MyFavouritesBtn_Click(object sender, EventArgs e)
        {
            FavouriteManager faveManager = new FavouriteManager(database);
            faveManager.Show();
            this.Dispose();
        }

        private void ComingSoonBtn_Click(object sender, EventArgs e)
        {
            ComingSoon comingSoon = new ComingSoon(database);
            comingSoon.Show();
            this.Dispose();
        }

        private void ReviewsBtn_Click(object sender, EventArgs e)
        {
            IGNReviewExclusive newsExclusiveForm = new IGNReviewExclusive(database);
            newsExclusiveForm.Show(new IGNReviewExclusive(database));
        }
    }
}
