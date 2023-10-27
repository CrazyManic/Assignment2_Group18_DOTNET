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
        public string qurry = " ";
        public string platform = " ";
        private Button current = null; //Tracks the current category button to make it blue.
        public IGNReviewExclusive(Database db)
        {
            InitializeComponent();
            this.db = db;
        }

        private async void IGNReviewExclusive_LoadQuary(object sender, EventArgs e)
        {
            setButtons();
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

        private async void IGNReviewExclusive_Load(object sender, EventArgs e)
        {
            setButtons();
            if (current != null)
            {
                current.BackColor = Color.Blue;
            }

            List<IGNReview> iGNReviews = await db.PlatformIGNReview(platform);

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
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            platform = "PlayStation 5";
            current = button7;
            IGNReviewExclusive_Load(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            platform = "Nintendo Switch";
            current = button8;
            IGNReviewExclusive_Load(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            platform = "PC";
            current = button9;
            IGNReviewExclusive_Load(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            platform = "Xbox One";
            current = button10;
            IGNReviewExclusive_Load(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            platform = "PlayStation 4";
            current = button11;
            IGNReviewExclusive_Load(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            qurry = textBox2.Text;
            current = button1;
            IGNReviewExclusive_LoadQuary(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EpicSpecialExclusive newsExclusiveForm = new EpicSpecialExclusive(db);
            newsExclusiveForm.Show(new EpicSpecialExclusive(db));
        }


        //private void button5_Click(object sender, EventArgs e)
        //{
        //    //Need a form manager class to manage all forms. Coming soon.
        //    EpicSpecialExclusive EpicForm = new EpicSpecialExclusive(db);
        //    //this.Close();
        //    EpicForm.Show(new EpicSpecialExclusive(db));
        //}

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
