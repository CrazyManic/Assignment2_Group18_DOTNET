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
    
    public partial class EpicSpecialExclusive : Form
    {
        private Database db;
        public int imageScale = 168; //the size of the view port for images
        public int imageScaleFactor = 14; //resizes the images from the api call.
        public string searchBar = ""; //api call for searchwords
        public string category = ""; //API call for category
        private Button current = null; //Tracks the current category button to make it blue.
        public EpicSpecialExclusive(Database db)
        {
            InitializeComponent();
            this.db = db;

            this.StartPosition = FormStartPosition.CenterScreen;
            Console.WriteLine(db.LogedInUser.Username);

        }

        private async void EpicSpecialExclusive_Load(object sender, EventArgs e)
        {
            setButtons();
            UserNameLbl.Text = db.LogedInUser.Username; //set the username logo
            if (current != null)
            {
                current.BackColor = Color.Blue;
            }
            try
            { //trys to find a list of epic specials based on the category and search words.
                List<EpicSpecial> epicSpecials = await db.SearchEpicSales(searchBar, category);
                //Converts the lengthy epic specials into much more paletable display helper datasources. 
                List<epicDisplayHelper> gridView = epicSpecials.Select(epicSpecial => new epicDisplayHelper
                {
                    Title = epicSpecial.Title,
                    Price = priceFormatter(epicSpecial.CurrentPrice),
                }).ToList();

                //debug
                foreach (EpicSpecial epic in epicSpecials)
                {
                    Console.WriteLine(epic.Title);
                }

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;

                dataGridView1.DataSource = gridView;
                //Loads the images from the provided API urls, into smaller images, this is an asynchronous task. 
                Load_Images(epicSpecials);

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
            catch (Exception ex)
            {
                //Catches null return exception from the API and clears the display port.
                List<EpicSpecial> epicSpecials;
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
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
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

            }

        }

        private string priceFormatter(decimal currentPrice)
        {
            if(currentPrice == 0)
            {
                return "Free!";
            } else
            {
                return "$" + Convert.ToString(currentPrice/100);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchBar = textBox1.Text;
            current = button1;
            EpicSpecialExclusive_Load(sender, e);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            category = "Games";
            current = button2;
            EpicSpecialExclusive_Load(sender, e);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            category = "Apps";
            current = button3;
            EpicSpecialExclusive_Load(sender, e);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            category = "GameAddOn";
            current = button4;
            EpicSpecialExclusive_Load(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            category = "GameDemo";
            current = button6;
            EpicSpecialExclusive_Load(sender, e);
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

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            //Return the user to the main menu 
            MainPage main = new MainPage(db);
            main.Show();
            this.Dispose();
        }

        private void UserNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    //Helper class to better display what i need
    public class epicDisplayHelper
    {
        public string Title { get; set; }
        public string Price { get; set; }

    }
}
