﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingDashboard
{
    static class Program
    {

        public static Database db = new Database();  // the whole program method list will be accessible from db.

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

       
        public static async Task Main()
        {
            //Build the database if !exists 
            DataBaseBuilder.Initialize();


            //Little test for EpicSales 
            List<EpicSpecial> epicSales = await db.GetEpicSales();
            foreach (var epicSpecial in epicSales)
            {
                Console.WriteLine(epicSpecial.ToString());
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
        
        // Handle login
        //this is a testing commit
    }
}
