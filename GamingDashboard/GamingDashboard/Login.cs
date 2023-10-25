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
    public partial class Login : Form
    {
        private Database database;

        public Login(Database database)
        {
            this.database = database;
            InitializeComponent();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // MessageBox.Show("Username: " + username + "password: " + password);
            //check if the inputs are empty
            if(username != "" && password != "")
            {
                User user = database.Login(username, password);
                if (user != null)
                {
                    MessageBox.Show("Login succesfully Welcom " + user.UserFirstName + " " + user.UserLastName);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    database.LogedInUser = user; //Set the user in the database
                    EpicSpecialExclusive mainPage = new EpicSpecialExclusive(database);//Generate a new main page // this page is place holder for now.
                    mainPage.Show();//show the new mainpage
                    this.Hide(); //hide this page
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Plese Enter your username and password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp(this.database); // pass this database to the login form. 
            this.Hide();
            signup.Show();
            //this.Close();
        }
    }
}
