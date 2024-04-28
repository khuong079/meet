using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Meeting
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3NJ3M6ES;Initial Catalog=Quanlicuochop;Integrated Security=True;");
        private void openConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private void closeConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        private Boolean Exe(string cmd)
        {
            openConn();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, conn);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception) 
            {
                check = false;
            }
            closeConn();
            return check;
        }

        private DataTable Red(string cmd)
        {
            openConn();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, conn);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            closeConn();
            return dt;
        }
        private void load()
        {
            DataTable dt = Red("SELECT * FROM Metting ");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btn_Thoat(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MettingID.ResetText();
            Title.ResetText();
            Date.ResetText();
            Time.ResetText();
            Location.ResetText();
            Meetingstatus.ResetText();
            IDuser.ResetText();
        }

        private void btn_Them(object sender, EventArgs e)
        {
            Exe("INSERT INTO Metting(MettingID,Title,Date,Time,Location,Meetingstatus,IDuser) VALUES(N'"+ MettingID.Text +"',N'" +Title.Text+ "',N'" +Date.Text+ "',N'" +Time.Text+ "',N'" +Location.Text+ "',N'" +Meetingstatus.Text+ "',N'" +IDuser.Text+ "')");

        }

        private void btn_TroVe(object sender, EventArgs e)
        {
            load();
        }

        private void btn_Sua(object sender, EventArgs e)
        {
            Exe("UPDATE Metting SET MettingID = N'" + MettingID.Text + "', Title = N'" + Title.Text + "', Date = N'" + Date.Text + "', Time = N'" + Time.Text + "', Location =  N'" + Location.Text + "', Meetingstatus =  N'" + Meetingstatus.Text + "', IDuser = N'" + IDuser.Text + "' WHERE MettingID='"+MettingID+"'");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MettingID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Title.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Date.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Time.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Location.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Meetingstatus.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            IDuser.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btn_Xoa(object sender, EventArgs e)
        {
            Exe("DELETE FROM Metting  WHERE MettingID='" + MettingID + "' ");
        }
    }
}
