using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dangnhap
{
    public partial class frmdangnhap : Form
    {
        public frmdangnhap()
        {
            InitializeComponent();
        }
        DuLieuDataContext dulieu = new DuLieuDataContext();

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string id = "admin";
            string mk = "123456";
            if (id.Equals(txtTenDangNhap.Text) && mk.Equals(txtMatKhau.Text))
            {
                frm_Admin f = new frm_Admin();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                var ktradn = (from TAIKHOAN in dulieu.TAIKHOANs where TAIKHOAN.MANV == txtTenDangNhap.Text.Trim() && TAIKHOAN.MATKHAU == txtMatKhau.Text select TAIKHOAN).SingleOrDefault();
                if (ktradn == null)
                {
                    MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại!");
                }
                else
                {

                    frm_NhanVien f = new frm_NhanVien();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
