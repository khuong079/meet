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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3NJ3M6ES;Initial Catalog=Quanlicuochop;Integrated Security=True;");
            try
            {
                conn.Open();
                string tk = txtTaiKhoan.Text;
                string mk = txtMatKhau.Text;
                string sql = "select *from User where TK='" +tk+ "' and Pass=  '" +mk+ "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta= cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Thất bại","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Lỗi Kết Nối");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           DialogResult tb = MessageBox.Show("Bạn có muốn thoát ","Thông Báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            Application.Exit();
        }
    }
}
