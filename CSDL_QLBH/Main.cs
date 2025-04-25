using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDL_QLBH
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void DMChatlieu_Click(object sender, EventArgs e)
        {
            frmDMChatlieu CL = new frmDMChatlieu();
            CL.StartPosition = FormStartPosition.CenterScreen;
            CL.Show();
        }

        private void DMNhanvien_Click(object sender, EventArgs e)
        {
            frmDMNhanvien NV = new frmDMNhanvien();
            NV.StartPosition = FormStartPosition.CenterScreen;
            NV.Show();
        }

        private void DMHanghoa_Click(object sender, EventArgs e)
        {
            frmDMHanghoa HH = new frmDMHanghoa();
            HH.StartPosition = FormStartPosition.CenterScreen;
            HH.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                DAO.Connect();
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }


        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắn chắn muốn thoát không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
