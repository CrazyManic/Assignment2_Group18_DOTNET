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
    public partial class IGNSearch : Form
    {
        private Database db;
        public int imageScale = 168; //the size of the view port for images
        public int imageScaleFactor = 14; //resizes the images from the api call.
        public string qurry = " ";
        public string platform = " ";
        private Button current = null; //Tracks the current category button to make it blue.
        public IGNSearch(Database db)
        {
            InitializeComponent();
            this.db = db;

            this.StartPosition = FormStartPosition.CenterScreen;
            Console.WriteLine(db.LogedInUser.Username);
        }

        private async void IGNSearch_Load(object sender, EventArgs e)
        {

            setButtons();
            UserNameLbl.Text = db.LogedInUser.Username; //set the username logo
            if (current != null)
            {
                current.BackColor = Color.Blue;
            }

            List<IGNReview> iGNReviews = await db.SearchIGNReview(qurry);

            List<IGNDisplayHelper> gridView = iGNReviews.Select(iGNReview => new IGNDisplayHelper
            {
                Name = iGNReview.Name,
                Score = scoreSettler(iGNReview.minScore, iGNReview.maxScore)
            }).ToList();

            foreach (IGNReview ignreview in iGNReviews)
            {
                Console.WriteLine(Name = ignreview.Name);
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = gridView;

            Load_Images(iGNReviews);

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "ImageColumn";

            imageColumn.Name = "ImageColumn";
            imageColumn.Width = 128; // Set the width for the desired aspect ratio
            dataGridView1.Columns.Add(imageColumn);
            dataGridView1.Columns[0].Width = 400;
            dataGridView1.Columns[2].Width = imageScale;

            // Adjust row height to 128 pixels

            //Asynchronous call for images from the API, can be a little slow but atleast it does not crash the application untill complete

            dataGridView1.Refresh();

        }

        private async void Load_Images(List<IGNReview> ign)
        {
            for (int i = 0; i < ign.Count; i++)
            {
                DataGridViewImageCell imageCell = new DataGridViewImageCell();
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] imageBytes = await wc.DownloadDataTaskAsync(ign[i].Image); //NEED TO FIX THIS!!!!!!!!!!!!!!!

                        using (MemoryStream ms = new MemoryStream(imageBytes))                   //Loads the image to the memory
                        {
                            Image image = Image.FromStream(ms);
                            image = new Bitmap(image, new Size(image.Width / imageScaleFactor, image.Height / imageScaleFactor));
                            imageCell.Value = image; // sets this image cell.
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Image caused a big yikes." + ex.Message);
                }


                try
                {
                    dataGridView1.Rows[i].Cells["ImageColumn"] = imageCell;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

            }

        }

        private string scoreSettler(double minScore, double maxScore)
        {
            double currentScore = (minScore + maxScore) / 2;
            return currentScore.ToString();

        }

        private void setButtons()
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;

        }

            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        //Helper class to better display what i need
        public class IGNDisplayHelper
        {
            public string Name { get; set; }
            public string minScore { get; set; }
            public string maxScore { get; set; }
            public string Score { get; set; }

        }

    }
}
