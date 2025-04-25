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
    public partial class frmDMChatlieu : Form
    {

        DataTable tblChatlieu = new DataTable();
        public frmDMChatlieu()
        {
            InitializeComponent();
        }

        private void frmDMChatlieu_Load(object sender, EventArgs e)
        {
            DAO.con = new SqlConnection(DAO.ConnectionString);
            DAO.con.Open();
            Load_DataGridView();

        }

        private void Load_DataGridView()
        {
            DAO.cmd = DAO.con.CreateCommand();
            DAO.cmd.CommandText = "select * from dbo.tblChatlieu";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DAO.cmd;
            tblChatlieu.Clear();
            adapter.Fill(tblChatlieu);
            dgvChatlieu.DataSource = tblChatlieu;

            //string sql;
            //sql = "SELECT Machatlieu, Tenchatlieu FROM tblChatlieu";
            //dgvChatlieu.DataSource = tblChatlieu;
            dgvChatlieu.Columns[0].HeaderText = "Mã chất liệu";
            dgvChatlieu.Columns[1].HeaderText = "Tên chất liệu";
            //dgvChatlieu.Columns[0].Width = 100;
            //dgvChatlieu.Columns[1].Width = 300;
            //// Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            //dgvChatlieu.AllowUserToAddRows = false;
            //// Không cho phép sửa dữ liệu trực tiếp trên lưới
            //dgvChatlieu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvChatlieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMachatlieu.ReadOnly = true;
            int i;
            i = dgvChatlieu.CurrentRow.Index;
            txtMachatlieu.Text = dgvChatlieu.Rows[i].Cells[0].Value.ToString();
            txtTenchatlieu.Text = dgvChatlieu.Rows [i].Cells[1].Value.ToString();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMachatlieu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu");
                return;
            }
            DAO.cmd = DAO.con.CreateCommand();
            DAO.cmd.CommandText = "INSERT into dbo.tblChatlieu values ('"+txtMachatlieu.Text+"',N'"+txtTenchatlieu.Text+"')";
            try
            {
                DAO.cmd.ExecuteNonQuery();
                MessageBox.Show("Đã lưu thành công");
                Load_DataGridView();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Dữ liệu không hợp lệ!" +ex.Message);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMachatlieu.Text == "")
            {
                MessageBox.Show("Chưa có bản ghi nào được chọn!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắn chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        DAO.cmd = DAO.con.CreateCommand();
                        DAO.cmd.CommandText = "DELETE from dbo.tblChatlieu where Machatlieu = N'" + txtMachatlieu.Text + "'";
                        DAO.cmd.ExecuteNonQuery();
                        Load_DataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi rồi bạn ơi!!!" + ex.Message);
                    }

                }
            }
    
    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtMachatlieu.Text == "")
            {
                MessageBox.Show("Chưa có bản ghi nào được chọn");
                return;
            }
            else
            {
                try
                {
                    DAO.cmd = DAO.con.CreateCommand();
                    DAO.cmd.CommandText = "UPDATE dbo.tblChatlieu set Tenchatlieu = N'" + txtTenchatlieu.Text + "' where Machatlieu = '" + txtMachatlieu.Text + "'";
                    DAO.cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã sửa dữ liệu thành công");
                    Load_DataGridView();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: "+ex.Message);
                }
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMachatlieu.ReadOnly = false;
            txtMachatlieu.Text = "";
            txtTenchatlieu.Text = "";
            txtMachatlieu.Focus();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            txtMachatlieu.Text = "";
            txtTenchatlieu.Text = "";

        }
    }
}
