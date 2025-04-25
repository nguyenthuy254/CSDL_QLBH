using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL_QLBH
{
    public partial class frmDMHanghoa : Form
    {
        DataTable tblHang = new DataTable();
        public frmDMHanghoa()
        {
            InitializeComponent();

            // Load data to Conbobox
            string sql = "select machatlieu, tenchatlieu from tblChatLieu";
            DAO.FillDataToCombo(cboChatlieu, sql, "tenchatlieu", "machatlieu");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "C:\\Users\\Admin\\OneDrive\\Hình ảnh";
            dlgOpen.FilterIndex = 4;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtLinkAnh.Text = dlgOpen.FileName;
            }

        }

        private void frmDMHanghoa_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            DAO.con = new SqlConnection(DAO.ConnectionString);
            DAO.con.Open();
            Load_DataGridView();

        }

        private void Load_DataGridView()
        {

            txtMahang.Enabled = false;
            DAO.cmd = DAO.con.CreateCommand();
            DAO.cmd.CommandText = "select * from dbo.tblHang";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DAO.cmd;
            tblHang.Clear();
            adapter.Fill(tblHang);
            dgvHanghoa.DataSource = tblHang;
            dgvHanghoa.Columns[0].HeaderText = "Mã hàng";
            dgvHanghoa.Columns[1].HeaderText = "Tên hàng";
            dgvHanghoa.Columns[2].HeaderText = "Mã chất liệu";
            dgvHanghoa.Columns[3].HeaderText = "Số lượng";
            dgvHanghoa.Columns[4].HeaderText = "Đơn giá nhập";
            dgvHanghoa.Columns[5].HeaderText = "Đơn giá bán";
            dgvHanghoa.Columns[6].HeaderText = "Ảnh";
            dgvHanghoa.Columns[7].HeaderText = "Ghi chú";
        }

        private void dgvHanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int i;
            i = dgvHanghoa.CurrentRow.Index;
            txtMahang.Text = dgvHanghoa.Rows[i].Cells[0].Value.ToString();
            txtTenhang.Text = dgvHanghoa.Rows[i].Cells[1].Value.ToString();
            cboChatlieu.Text = dgvHanghoa.Rows[i].Cells[2].Value.ToString();
            txtSoluong.Text = dgvHanghoa.Rows[i].Cells[3].Value.ToString();
            txtDongianhap.Text = dgvHanghoa.Rows[i].Cells[4].Value.ToString();
            txtDongiaban.Text = dgvHanghoa.Rows[i].Cells[5].Value.ToString();
            txtLinkAnh.Text = dgvHanghoa.Rows[i].Cells[6].Value.ToString();
            txtGhichu.Text = dgvHanghoa.Rows[i].Cells[7].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên");
                txtMahang.Focus();
                return;
            }
            if (txtTenhang.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên");
                txtTenhang.Focus();
                return;
            }
            if(cboChatlieu.Items.Count == 0)
            {
                MessageBox.Show("Bạn hãy chọn mã chất liệu");
                cboChatlieu.Focus();
                return;
            } 

            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Hãy nhập số lượng");
                txtSoluong.Focus();
                return;
            }

            if (txtDongianhap.Text == "")
            {
                MessageBox.Show("Hãy nhập đơn giá nhập");
                txtDongianhap.Focus();
                return;
            }

            if(txtDongiaban.Text == "")
            {
                MessageBox.Show("Hãy nhập đơn giá bán");
                txtDongiaban.Focus();
                return;
            }

            if(picAnh.Image == null)
            {
                MessageBox.Show("Bạn hãy chọn ảnh");
                btnOpen.Focus();
                return;
            }
            try
            {
                DAO.cmd = DAO.con.CreateCommand();
                DAO.cmd.CommandText = "INSERT INTO dbo.tblHang values ('" + txtMahang.Text + "', N'" + txtTenhang.Text + "', N'" + cboChatlieu.Text + "', '" + txtSoluong.Text + "', '" + txtDongianhap.Text + "', '" + txtDongiaban.Text + "', N'"+txtLinkAnh.Text+"', N'"+txtGhichu.Text +"')";
                DAO.cmd.ExecuteNonQuery();
                MessageBox.Show("Đã lưu thành công");
                Load_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ! " + ex.Message);
            }

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;

        }

        public void reSetValue()
        {
            txtMahang.Text = "";
            txtTenhang.Text = "";
            cboChatlieu.Text = "";
            txtSoluong.Text = "";
            txtDongianhap.Text = "";
            txtDongiaban.Text = "";
            txtLinkAnh.Text = "";
            picAnh.Image = null;
            txtGhichu.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            reSetValue();
            txtMahang.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            txtMahang.Focus();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Chưa có bản ghi nào được chọn");
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        DAO.cmd = DAO.con.CreateCommand();
                        DAO.cmd.CommandText = "DELETE from dbo.tblHang where Mahang = N'" + txtMahang.Text + "'";
                        DAO.cmd.ExecuteNonQuery();
                        //Load_DataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }

                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Chưa có bản ghi nào được chọn");
                txtMahang.Focus();
                return;
            }
            else 
            {
                try
                {
                    DAO.cmd = DAO.con.CreateCommand();
                    DAO.cmd.CommandText = "UPDATE dbo.tblHang set Mahang = '" + txtMahang.Text + "', Tenhang = N'" + txtTenhang.Text + "', Machatlieu = '" + cboChatlieu.Text + "', Soluong = '" + txtSoluong.Text + "', Dongianhap='" + txtDongianhap.Text + "', Dongiaban='"+txtDongiaban.Text+"', Anh = N'"+txtLinkAnh.Text+"', Ghichu = N'"+txtGhichu.Text+"' where Mahang = '" + txtMahang.Text + "'";
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
            txtMahang.Enabled = false;
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            reSetValue();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahang.Text == "") && (txtTenhang.Text == "") && (cboChatlieu.Text ==""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHang WHERE 1=1";
            if (txtMahang.Text != "")
                sql = sql + " AND Mahang Like N'%" + txtMahang.Text + "%'";
            if (txtTenhang.Text != "")
                sql = sql + " AND Tenhang Like N'%" + txtTenhang.Text + "%'";
            if (cboChatlieu.Text != "")
                sql = sql + " AND Machatlieu Like N'%" + cboChatlieu.SelectedValue + "%'";
            tblHang = DAO.GetDataToTable(sql);
            if (tblHang.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblHang.Rows.Count + " bản ghi thỏa mãn điều kiện!!!",
"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvHanghoa.DataSource = tblHang;
            reSetValue();

        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Mahang, Tenhang, Machatlieu, Soluong, Dongianhap, Dongiaban, Anh,Ghichu FROM tblHang";
            tblHang = DAO.GetDataToTable(sql);
            dgvHanghoa.DataSource = tblHang;

        }
    }
}
