using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace GamingDashboard
{

    public partial class IGNReviewExclusive : Form
    {
        private Database db;
        public int imageScale = 168; //the size of the view port for images
        public int imageScaleFactor = 14; //resizes the images from the api call.
        public string platform = ""; //api call for searchwords
        public string sortBY = ""; //API call for category
        private Button current = null; //Tracks the current category button to make it blue.
        public IGNReviewExclusive(Database db)
        {
            InitializeComponent();
            this.db = db;
        }

        private async void IGNReviewExclusive_Load(object sender, EventArgs e)
        {
            setButtons();
            if (current != null)
            {
                current.BackColor = Color.Blue;
            }

            List<IGNReview> iGNReviews = await db.SearchIGNReview(platform, sortBY);

            List<IGNDisplayHelper> gridView = iGNReviews.Select(iGNReview => new IGNDisplayHelper
            {
                Name = iGNReview.Name,
                Score = scoreSettler(iGNReview.minScore, iGNReview.maxScore) 
            }).ToList();

            foreach (IGNReview ignreview in iGNReviews)
            {
                Console.WriteLine(Name = ignreview.Name);
            }

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = null;

            dataGridView2.DataSource = gridView;

            Load_Images(iGNReviews);

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "ImageColumn";

            imageColumn.Name = "ImageColumn";
            imageColumn.Width = 128; // Set the width for the desired aspect ratio
            dataGridView2.Columns.Add(imageColumn);
            dataGridView2.Columns[0].Width = 400;
            dataGridView2.Columns[2].Width = imageScale;

            // Adjust row height to 128 pixels

            //Asynchronous call for images from the API, can be a little slow but atleast it does not crash the application untill complete

            dataGridView2.Refresh();

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
                    dataGridView2.Rows[i].Cells["ImageColumn"] = imageCell;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Need to fix this
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Need to fix this
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Need to fix this
            IGNReviewExclusive_Load(sender, e);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Need to fix this
            IGNReviewExclusive_Load(sender, e);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Need to fix this
            IGNReviewExclusive_Load(sender, e);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Need to fix this
            IGNReviewExclusive_Load(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Need to fix this
            IGNReviewExclusive_Load(sender, e);
        }
        private void setButtons()
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button6.BackColor = Color.White;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Need a form manager class to manage all forms. Coming soon.
            IGNReviewExclusive newsExclusiveForm = new IGNReviewExclusive(db);
            //this.Close();
            newsExclusiveForm.Show(new IGNReviewExclusive(db));
        }
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
