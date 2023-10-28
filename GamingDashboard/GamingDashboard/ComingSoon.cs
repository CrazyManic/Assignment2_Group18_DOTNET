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
    public partial class ComingSoon : Form
    {
        private Database database;
        List<EpicSpecial> comingSoon;
        public string searchBar = " ";
        private int imageScale = 168;
        private int imageScaleFactor = 14;

        public ComingSoon(Database database )
        {
            this.database = database;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void ComingSoon_Load(object sender, EventArgs e)
        {
            UserNameLbl.Text = database.LogedInUser.Username;

            //trys to find a list of epic specials based on the category and search words.
                comingSoon = await database.GetUpComingGames(searchBar, "Games");
                //Converts the lengthy epic specials into much more paletable display helper datasources. 
                List<epicDisplayHelper> gridView = comingSoon.Select(epicSpecial => new epicDisplayHelper
                {
                    Title = epicSpecial.Title,
                    Price = priceFormatter(epicSpecial.CurrentPrice),
                }).ToList();


                foreach (EpicSpecial epic in comingSoon)
                {
                    Console.WriteLine(epic.Title);
                }

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;

                dataGridView1.DataSource = gridView;
                //Loads the images from the provided API urls, into smaller images, this is an asynchronous task. 
                Load_Images(comingSoon);

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "ImageColumn";

                imageColumn.Name = "ImageColumn";
                imageColumn.Width = 128; // Set the width for the desired aspect ratio
                dataGridView1.Columns.Add(imageColumn);
                dataGridView1.Columns[0].Width = 440;
                dataGridView1.Columns[2].Width = imageScale;

                // Adjust row height to 128 pixels

                //Asynchronous call for images from the API, can be a little slow but atleast it does not crash the application untill complete

                dataGridView1.Refresh();
  

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string priceFormatter(decimal currentPrice)
        {
            if (currentPrice == 0)
            {
                return "Free!";
            }
            else
            {
                return "$" + Convert.ToString(currentPrice / 100);
            }
        }

        private async void Load_Images(List<EpicSpecial> epics)
        {
            for (int i = 0; i < epics.Count; i++)
            {
                DataGridViewImageCell imageCell = new DataGridViewImageCell();
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] imageBytes = await wc.DownloadDataTaskAsync(epics[i].KeyImages[0].Url); //Downloads the image to garvage collection
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

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage(database);
            main.Show();
            this.Dispose();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(comingSoon[e.RowIndex].Title);
            EpicSpecialDetails epicView = new EpicSpecialDetails(database, comingSoon[e.RowIndex], "comingSoon");
            epicView.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchBar = textBox1.Text;
            ComingSoon_Load(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
