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
    public partial class NewsExclusive : Form
    {
        private Database db;
        public NewsExclusive(Database db)
        {
            this.db = db;
            InitializeComponent();
        }
    }
}
