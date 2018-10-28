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
    public partial class Frmdangnhap : Form
    {
        public Frmdangnhap()
        {
            InitializeComponent();
        }
        DuLieuDataContext qlks = new DuLieuDataContext();

        private void frm_Admin_Load(object sender, EventArgs e)
        {
            //load nhan vien
            try
            {
                //var nhanviens = from nv in qlks.NHANVIENs select nv;
                var nhanviens = from nv1 in qlks.NHANVIENs
                                join a in qlks.TAIKHOANs on nv1.MANV equals a.MANV
                                select new { nv1.MANV, nv1.TENNV, nv1.CHUCVU, nv1.NAMSINH, nv1.GIOITINH, nv1.BACLUONG };
                dataGridView1.DataSource = nhanviens;
            }
            catch { };
            //load tai khoan
            try
            {
                var taikhoans = from tk in qlks.TAIKHOANs select tk;
                gvTaiKhoan.DataSource = taikhoans;
            }
            catch { };
        }
        //nhan vien---------------------------------------------------------------------------------------------------
        private void btnThemNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                TAIKHOAN tk = new TAIKHOAN();
                nv.MANV = txtMaNV.Text;
                nv.TENNV = txtTenNV.Text;
                nv.CHUCVU = txtChucVu.Text;
                nv.NAMSINH = txtNamSinh.Text;
                nv.GIOITINH = txtGioiTinh.Text;
                nv.BACLUONG = Convert.ToInt32(txtBacLuong.Text);
                qlks.NHANVIENs.InsertOnSubmit(nv);
                var nhanviens = from nv1 in qlks.NHANVIENs select nv1;
                //var nhanviens = from nv1 in qlks.NHANVIENs
                //                join a in qlks.TAIKHOANs on nv1.MANV equals a.MANV
                //                select new { nv1.MANV, nv1.TENNV, nv1.CHUCVU, nv1.NAMSINH, nv1.GIOITINH, nv1.BACLUONG };
                qlks.SubmitChanges();
                dataGridView1.DataSource = nhanviens;
            }
            catch { };
        }

        private void btnXoaNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string manv = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                NHANVIEN nv = qlks.NHANVIENs.Where(t => t.MANV == manv).FirstOrDefault();
                qlks.NHANVIENs.DeleteOnSubmit(nv);
                qlks.SubmitChanges();
                var nhanviens = from nv1 in qlks.NHANVIENs select nv1;
                dataGridView1.DataSource = nhanviens;
            }
            catch { };
        }

        private void btnSuaNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string manv = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                NHANVIEN nv = qlks.NHANVIENs.Where(t => t.MANV == manv).FirstOrDefault();

                nv.TENNV = txtTenNV.Text;
                nv.CHUCVU = txtChucVu.Text;
                nv.NAMSINH = txtNamSinh.Text;
                nv.GIOITINH = txtGioiTinh.Text;
                nv.BACLUONG = Convert.ToInt32(txtBacLuong.Text);
                qlks.SubmitChanges();
                var nhanviens = from nv1 in qlks.NHANVIENs select nv1;
                dataGridView1.DataSource = nhanviens;
            }
            catch { };
        }

        private void btnThoatNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        //tai khoan---------------------------------------------------------------------------------------------------
        private void btnThemTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TAIKHOAN tk = new TAIKHOAN();
                tk.MANV = txtTaiKhoan.Text;
                tk.MATKHAU = txtMatKhau.Text;

                qlks.TAIKHOANs.InsertOnSubmit(tk);
                qlks.SubmitChanges();
                var taikhoans = from tk1 in qlks.TAIKHOANs select tk1;
                gvTaiKhoan.DataSource = taikhoans;
            }
            catch { };
        }

        private void btnXoaTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string matk = gvTaiKhoan.CurrentRow.Cells[0].Value.ToString();
                TAIKHOAN tk = qlks.TAIKHOANs.Where(t => t.MANV == matk).FirstOrDefault();
                qlks.TAIKHOANs.DeleteOnSubmit(tk);
                qlks.SubmitChanges();
                var taikhoans = from tk1 in qlks.TAIKHOANs select tk1;
                gvTaiKhoan.DataSource = taikhoans;
            }
            catch { };
        }

        private void btnSuaTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string matk = gvTaiKhoan.CurrentRow.Cells[0].Value.ToString();
                TAIKHOAN tk = qlks.TAIKHOANs.Where(t => t.MANV == matk).FirstOrDefault();
                qlks.TAIKHOANs.DeleteOnSubmit(tk);
                tk.MATKHAU = txtMatKhau.Text;
                qlks.SubmitChanges();
                var taikhoans = from tk1 in qlks.TAIKHOANs select tk1;
                gvTaiKhoan.DataSource = taikhoans;
            }
            catch { };
        }

        private void btnThoatTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        //--------------------------------------------------------
    }
}
