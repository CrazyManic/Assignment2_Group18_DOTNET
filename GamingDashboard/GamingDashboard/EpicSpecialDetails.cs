using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data;
using System.IO;

namespace GamingDashboard
{
    public partial class EpicSpecialDetails : Form
    {
        private Database database;
        private EpicSpecial epic;
        private int imageScaleFactor = 8;

        public EpicSpecialDetails(Database database, EpicSpecial epic)
        {
            this.database = database;
            this.epic = epic;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            GameTitle.Text = epic.Title;
            GameDesc.Text = epic.Description;
            PriceLbl.Text = "Price: $" + epic.CurrentPrice/100;
            label1.Text = "Published: " + epic.PublisherName;
            label2.Text = "Release: " + epic.ReleaseDate;
            checkFave();

            if (database.isEpicAlreadyAdded(database.LogedInUser, epic))
            {
                button2.BackgroundImage = Properties.Resources.favourite_14390;
            }

            loadImage();
        }

        private void DameDesc_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EpicSpecialExclusive epicSpecialExclusive = new EpicSpecialExclusive(database);
            epicSpecialExclusive.Show();
            this.Dispose();
        }

        private async void loadImage()
        {
            try
            {
                using(WebClient wc = new WebClient())
                {
                    byte[] imageBytes = await wc.DownloadDataTaskAsync(epic.KeyImages[0].Url);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(ms );
                        image = new Bitmap(image, new Size(image.Width / imageScaleFactor, image.Height / imageScaleFactor));
                        pictureBox1.Image = image;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Image caused a big yikes." + ex.Message);
            }
        }


        public void checkFave()
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
            if(!database.isEpicAlreadyAdded(database.LogedInUser, epic))
            {
                database.AddEpicFavorite(database.LogedInUser, epic);
                button2.BackgroundImage = Properties.Resources.favourite_14390;
            } else
            {
                database.RemoveEpicFavorite(database.LogedInUser, epic);
                button2.BackgroundImage = Properties.Resources.Heart;
            }

        }
    }
}
