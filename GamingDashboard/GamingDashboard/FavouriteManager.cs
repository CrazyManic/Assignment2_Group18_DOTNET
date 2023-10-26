using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingDashboard
{
    public partial class FavouriteManager : Form
    {
        private Database database;
        private EpicFavourite currentSelection;
        List<EpicFavourite> myFaves;

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
            myFaves = database.GetFavorites(database.LogedInUser);

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            List<epicFaveHelper> gridView = myFaves.Select(EpicFavourite => new epicFaveHelper
            {
                Title = EpicFavourite.Title,
                Price = Convert.ToDecimal( EpicFavourite.Price / 100)
            }).ToList();


            dataGridView1.DataSource = gridView;
            dataGridView1.Columns[0].Width = 200;

        }
        private async void loadImage()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] imageBytes = await wc.DownloadDataTaskAsync(currentSelection.imageUrl);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(ms);
                        image = new Bitmap(image, new Size(image.Width / 7, image.Height / 7));
                        pictureBox3.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Image caused a big yikes." + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage(database);
            main.Show();
            this.Dispose();
        }

        //Unlike button, will unlike the current selection from the database
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentSelection != null)
            {
                database.RemoveEpicFavorite(database.LogedInUser, currentSelection.EpicId);
                currentSelection = null;

                // Update the data source for the dataGridView
                myFaves = database.GetFavorites(database.LogedInUser);
                List<epicFaveHelper> gridView = myFaves.Select(EpicFavourite => new epicFaveHelper
                {
                    Title = EpicFavourite.Title,
                    Price = Convert.ToDecimal(EpicFavourite.Price / 100)
                }).ToList();
                dataGridView1.DataSource = gridView;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelection = myFaves[e.RowIndex];
            loadImage();
        }
    }

    public class epicFaveHelper{
        public String Title { get; set; }
        public Decimal Price { get; set; }
    }

}
