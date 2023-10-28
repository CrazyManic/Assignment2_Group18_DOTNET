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
    public partial class SignUp : Form
    {
        private Database database;
        Validation validate = new Validation();
        public SignUp(Database database)
        {
            this.database = database;
            InitializeComponent();
        }

        private void signUpBtn2_Click(object sender, EventArgs e)
        {
            
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string email = emailInput.Text;
            string username = usernameInput.Text;
            string password = passwordInput.Text;


            // validate the inputs
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // is firstName letters only
            if (!validate.isValidName(firstName))
            {
                MessageBox.Show("First name should contain letters only.", "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!validate.isValidName(lastName))
            {
                MessageBox.Show("Last name should contain letters only.", "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!validate.isValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!validate.isValidUsername(username))
            {
                MessageBox.Show("Username should start with letters and be followed by numbers.", "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //create user
            User user = database.CreateUser(username, password, email, firstName, lastName);
            if(user != null)
            {
                MessageBox.Show("User created and saved to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                firstNameInput.Text = "";
                lastNameInput.Text = "";
                emailInput.Text = "";
                usernameInput.Text = "";
                passwordInput.Text = "";

                Login login = new Login(database);
                this.Hide();
                login.Show();
            }
            else
            {
                MessageBox.Show("Couldn't register the user.", "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                firstNameInput.Text = "";
                lastNameInput.Text = "";
                emailInput.Text = "";
                usernameInput.Text = "";
                passwordInput.Text = "";
            }


        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
