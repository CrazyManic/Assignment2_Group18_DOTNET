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

    // GET RID OF THIS
    /// <summary>
    /// 
    /// GET RID OF THIS
    /// </summary>
    public partial class NewsExclusive : Form
    {
        private Database db;
        public NewsExclusive(Database db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void NewsExclusive_Load(object sender, EventArgs e)
        {

        }
    }
}
