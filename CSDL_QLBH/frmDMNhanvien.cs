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
using System.Globalization;


namespace CSDL_QLBH
{
    public partial class frmDMNhanvien : Form
    {
        DataTable tblNhanvien = new DataTable();
        public frmDMNhanvien()
        {
            InitializeComponent();
        }

        private void frmDMNhanvien_Load(object sender, EventArgs e)
        {
            DAO.con = new SqlConnection(DAO.ConnectionString);
            DAO.con.Open();
            Load_DataGridView();
            
        }

        private void Load_DataGridView()
        {
            DAO.cmd = DAO.con.CreateCommand();
            DAO.cmd.CommandText = "select * from dbo.tblNhanvien";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DAO.cmd;
            tblNhanvien.Clear();
            adapter.Fill(tblNhanvien);
            dgvNhanvien.DataSource = tblNhanvien;
            dgvNhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanvien.Columns[2].HeaderText = "Giới tính";
            dgvNhanvien.Columns[3].HeaderText = "Địa chỉ";
            dgvNhanvien.Columns[4].HeaderText = "Điện thoại";
            dgvNhanvien.Columns[5].HeaderText = "Ngày sinh";
        }

        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtManhanvien.ReadOnly = true;
            int i;
            i = dgvNhanvien.CurrentRow.Index;
            txtManhanvien.Text = dgvNhanvien.Rows[i].Cells[0].Value.ToString();
            txtTennhanvien.Text = dgvNhanvien.Rows[i].Cells[1].Value.ToString();
            chkGioitinh.Text = dgvNhanvien.Rows[i].Cells[2].Value.ToString();
            txtDiachi.Text = dgvNhanvien.Rows[i].Cells[3].Value.ToString(); 
            mskDienthoai.Text = dgvNhanvien.Rows[i].Cells[4].Value.ToString();
            mskNgaysinh.Text = dgvNhanvien.Rows[i].Cells[5].Value.ToString();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên");
                txtManhanvien.Focus();
                return;
            }
            if(txtTennhanvien.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên");
                txtTennhanvien.Focus();
                return;
            }
            string gioitinh;
            if (chkGioitinh.Checked)
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";

            if(txtDiachi.Text == "")
            {
                MessageBox.Show("Hãy nhập địa chỉ");
                txtDiachi.Focus();
                return;
            }
            
            if(mskNgaysinh.Text == "")
            {
                MessageBox.Show("Hãy nhập ngày sinh");
                mskNgaysinh.Focus();
                return;
            }

            try
            {
                DAO.cmd = DAO.con.CreateCommand();
                DAO.cmd.CommandText = "INSERT INTO dbo.tblNhanvien values ('" + txtManhanvien.Text + "', N'" + txtTennhanvien.Text + "', N'" +gioitinh+ "', N'" + txtDiachi.Text + "', '" + mskDienthoai.Text + "', '" + DAO.GetSQLDateFromText(mskNgaysinh.Text)+ "')";
                DAO.cmd.ExecuteNonQuery();
                MessageBox.Show("Đã lưu thành công");
                Load_DataGridView();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Dữ liệu không hợp lệ! " +ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtManhanvien.Text == "")
            {
                MessageBox.Show("Chưa có bản ghi nào được chọn");
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn xóa không?","Thông báo",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    try
                    {
                        DAO.cmd = DAO.con.CreateCommand();
                        DAO.cmd.CommandText = "DELETE from dbo.tblNhanvien where Manhanvien = N'" + txtManhanvien.Text + "'";
                        DAO.cmd.ExecuteNonQuery();
                        Load_DataGridView();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi: "+ex.Message);
                    }

                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtManhanvien.Enabled = true;
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            chkGioitinh.Text = "Nam";
            chkGioitinh.Checked = false;
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
            mskNgaysinh.Text = "";
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Chưa có bản ghi nào được chọn");
                txtManhanvien.Focus();
                return;
            }
            else
            {
                try
                {
                    DAO.cmd = DAO.con.CreateCommand();
                    DAO.cmd.CommandText = "UPDATE dbo.tblNhanvien set Tennhanvien = N'" + txtTennhanvien.Text + "', Gioitinh = N'"+chkGioitinh.Text+"', Diachi = N'"+txtDiachi.Text+"', Dienthoai = '"+mskDienthoai.Text+"', Ngaysinh='"+mskNgaysinh.Text+"' where Manhanvien = '" + txtManhanvien.Text + "'";
                    DAO.cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã sửa dữ liệu thành công");
                    Load_DataGridView();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            txtManhanvien.Enabled = false;
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            chkGioitinh.Checked = false;
            chkGioitinh.Text = "Nam";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
            mskNgaysinh.Text = "";

        }
    }
}
