using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingDashboard
{
    public partial class UserManagementDashboard : Form
    {
        private Database db;
        Validation validate = new Validation();
        public UserManagementDashboard(Database db)
        {
            InitializeComponent();

            this.db = db;
            User user = db.LogedInUser;
            this.StartPosition = FormStartPosition.CenterScreen;
            firstNameInput1.Text = user.UserFirstName;
            lastNameInput1.Text = user.UserLastName;
            emailInput1.Text = user.UserEmail;
            usernameInput1.Text = user.Username;
            passwordInput1.Text = user.Password;

        }

        private void UserManagementDashboard_Load(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int userId = db.LogedInUser.UserId;
            string firstName = firstNameInput1.Text;
            string lastName = lastNameInput1.Text;
            string email = emailInput1.Text;
            string username = usernameInput1.Text;
            string password = passwordInput1.Text;

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

            
            

           string isUpdated = db.Update(db.LogedInUser.UserId,username, password, email, firstName, lastName);
            MessageBox.Show(isUpdated);

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            //not sure where you want the back button should take us to???
            // i got chu ali. 
            MainPage main = new MainPage(db);
            main.Show();
            this.Dispose();
        }
    }
}
