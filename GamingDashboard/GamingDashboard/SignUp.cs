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
        Database database = new Database();
        public SignUp()
        {
            InitializeComponent();
        }

        private void signUpBtn2_Click(object sender, EventArgs e)
        {
            
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string email = emailInput.Text;
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            User user  = database.CreateUser(username, password, email, firstName, lastName);
            
            // verify if the registration is done 
            if(user != null)
            {
                MessageBox.Show("user created and saved to database");
            }
            else
            {
                MessageBox.Show("Couln't register the user");
            }


        }


    }
}
