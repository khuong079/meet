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
    public partial class FormTaoTaiKhoan : Form
    {
        bool isEdit = true; 

        public FormTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void FormTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadUser();
            SetEnable(false);
        }

        private void LoadUser()
        {
            var sql = $"SELECT * FROM UserLogin ORDER BY UserID ";
            var dtUser = DataProvider.TruyVanLayDuLieu(sql);
            DgvTaoTaiKhoan.DataSource = dtUser;
        }


        // Thay đổi trạng thái các nút nhấn
   
        void SetEnable(bool enable)
        {
            txtMaUser.Enabled = enable;
            txtTaiKhoan.Enabled = enable;
            txtMatkhau.Enabled = enable;
            txtVaitro.Enabled = enable;
            txtEmail.Enabled = enable;
            txtDienThoai.Enabled = enable;

            //set bộ nút (Thêm/Sửa trái ngược với textbox ở trên)
            btnThem.Enabled = !enable;
            btnSua.Enabled = !enable;

            //không cho xóa khi đang edit (enable = True)
            btnXoa.Enabled = !isEdit;
            btnHuy.Enabled = enable;
            btnLuu.Enabled = enable;
        }
        private void DgvTaoTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaUser.Text = DgvTaoTaiKhoan.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            txtTaiKhoan.Text = DgvTaoTaiKhoan.Rows[e.RowIndex].Cells["TaiKhoan"].Value.ToString();
            txtMatkhau.Text = DgvTaoTaiKhoan.Rows[e.RowIndex].Cells["MatKhau"].Value.ToString();
            txtVaitro.Text = DgvTaoTaiKhoan.Rows[e.RowIndex].Cells["Vaitro"].Value.ToString();
            txtEmail.Text = DgvTaoTaiKhoan.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            txtDienThoai.Text = DgvTaoTaiKhoan.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();
            this.SetEnable(false); // Không cho phép sửa thông tin trên form
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetEnable(true);
            //xóa giá trị đang nhập
            txtMaUser.Clear();
            txtTaiKhoan.Clear();
            txtMatkhau.Clear();
            txtVaitro.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetEnable(true);
            isEdit = true;
            txtMaUser.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isEdit = true;
            this.SetEnable(false); // Không cho phép sửa thông tin trên form
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isEdit)//đang sửa
            {
                var sqlEdit = $"UPDATE UserLogin SET TaiKhoan = N'{txtTaiKhoan.Text}',MatKhau = N'{txtMatkhau.Text}', VaiTro = '{txtVaitro.Text}', Email ='{txtEmail.Text}' , DienThoai ='{txtDienThoai.Text}'";
                DataProvider.TruyVanXuLyDuLieu(sqlEdit);
                isEdit = false;
            }
            else
            {
                var sqlInsert = $"INSERT INTO UserLogin(UserID, TaiKhoan, MatKhau,VaiTro, Email,DienThoai) VALUES('{txtMaUser.Text}', N'{txtTaiKhoan.Text}','{txtMatkhau.Text}', '{txtVaitro.Text}', '{txtEmail.Text}', '{txtDienThoai.Text}')";
                DataProvider.TruyVanXuLyDuLieu(sqlInsert);
            }
            LoadUser();
            SetEnable(false);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //dựa vào textbox mã khách hàng để xóa
            if (txtMaUser.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var traLoi = MessageBox.Show("Bạn có chắc xóa khách hàng không?",

            "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (traLoi == DialogResult.Yes)
            {
                            var sqlDelete = $"DELETE FROM KhachHang WHERE MaKH = '{txtMaUser.Text}'";

                            if (DataProvider.TruyVanXuLyDuLieu(sqlDelete))
                            {
                                LoadUser();
                            }
                            else
                            {
                                MessageBox.Show("Xóa không thành công!");
                            }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.LoadUser();// Gọi hàng để tải lại DataGridView
        }
    }
}
