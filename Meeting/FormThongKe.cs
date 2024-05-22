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
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            cboUserID.DisplayMember = "TaiKhoan";
            cboUserID.ValueMember = "UserID";
            cboUserID.DataSource = DataProvider.TruyVanLayDuLieu("SELECT * FROM UserLogin");

            // ép chọn người đầu tiên
            cboUserID.SelectedIndex = 0;
            laySocuochoptheoUser();
        }

        private void laySocuochoptheoUser()
        {
            var sql = $"SELECT MeetingID, Title, Date, TimeStart, Link, UserID FROM Meeting WHERE UserID = '{cboUserID.SelectedValue.ToString()}'";

            var dtUser = DataProvider.TruyVanLayDuLieu(sql);
            dgvUser.DataSource = dtUser;
            txtCuocHop.Text = dtUser.Rows.Count.ToString();
        }

        private void cboUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            laySocuochoptheoUser();
        }
    }
}
