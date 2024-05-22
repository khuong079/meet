using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meeting
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

      

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormAdmin f = new FormAdmin();
            f.Show();
          
        }

    
        private void xemLịchHọpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Form1 f = new Form1();
            f.Show();
         
        }
           
        
    }
}
