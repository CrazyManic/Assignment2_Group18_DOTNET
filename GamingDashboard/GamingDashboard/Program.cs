using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingDashboard
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// 
        /// 1. LOGIN FORM 
        /// 2. MAIN SCREEN 
        /// 3. EXCLUSIVLY NEWS 
        /// 3. EXCLUSIVLY STEAM SPECIALS 
        /// 4. USER MANAGEMENT 
        /// 5. FAVOURITE MANAGEMENT 
        /// 
        /// All form handling will take place here in the Program class. 
        /// 
        /// 
        /// </summary>
        [STAThread]
       
        static void Main()
        {
            //Build the database if !exists 
            DataBaseBuilder.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
        
        // Handle login
        //this is a testing commit
    }
}
