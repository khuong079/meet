using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Meeting
{
    public partial class FormAdmin : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-3NJ3M6ES;Initial Catalog=Quanlicuochop;Integrated Security=True;";
        SqlDataAdapter adapter = new   SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Metting ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from Metting where MettingID = '"+txtMeetingID.Text+"'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into Metting values('"+txtMeetingID.Text+ "', '" + txtTitle.Text+"' , '"+txtDate.Text +"' , '"+txtTime.Text +"' , '"+txtLocation.Text +"' , '"+txtMeetingStatus.Text+ "', '"+txtIDUser.Text+"' , '" + txtTimeStart.Text +"' , '"+txtTimeEnd.Text+"')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMeetingID.ReadOnly = true;
            int i;
            i = dgv.CurrentRow.Index;
            txtIDUser.Text = dgv.Rows[i].Cells[6].Value.ToString();
            txtMeetingID.Text = dgv.Rows[i].Cells[0].Value.ToString();
            txtTitle.Text = dgv.Rows[i].Cells[1].Value.ToString();
            txtTime.Text = dgv.Rows[i].Cells[3].Value.ToString();
            txtDate.Text = dgv.Rows[i].Cells[2].Value.ToString();
            txtLocation.Text = dgv.Rows[i].Cells[4].Value.ToString();
            txtMeetingStatus.Text = dgv.Rows[i].Cells[5].Value.ToString();
            txtTimeStart.Text = dgv.Rows[i].Cells[7].Value.ToString();
            txtTimeEnd.Text = dgv.Rows[i].Cells[8].Value.ToString();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update Metting set MettingID = '" + txtMeetingID.Text + "',Title = '" + txtTitle.Text + "' , Date = '" + txtDate.Text + "' , Time = '" + txtTime.Text + "' , Location = '" + txtLocation.Text + "' , Meetingstatus = '" + txtMeetingStatus.Text + "', IDuser = '" + txtIDUser.Text + "' , TimeStart = '" + txtTimeStart.Text + "' , TimeEnd = '" + txtTimeEnd.Text + "' where MettingID = '"+txtMeetingID.Text+"'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
