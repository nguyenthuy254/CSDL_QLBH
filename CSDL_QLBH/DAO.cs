using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CSDL_QLBH
{
    internal class DAO 
    {
        public static SqlConnection con;
        // Kết nối với Data
        public static string ConnectionString = "Data Source=LAPTOP-VFDBDQ66;Initial Catalog=QuanLyBanHang;Integrated Security=True;Encrypt=False";
        // Khai báo để có thể thực thi câu lệnh sql
        public static SqlCommand cmd = new SqlCommand();
        
        public static void Connect() // 
        {
            con = new SqlConnection(ConnectionString); 
            try
            {
                if (con.State == ConnectionState.Closed) 
                {
                    con.Open();
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public static void Close()
        {
            try
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        //public static string getSQLdateFromText(string dateMMDDYYYY)
        //{
        //    string[] elemets = dateMMDDYYYY.Split('/');
        //    return elemets[2] + '/' + elemets[1] + '/' + elemets[0];

        //}
        public static string GetSQLDateFromText(string dateMMDDYYYY)
        {
            try
            {
                // Chuyển chuỗi đầu vào thành kiểu DateTime với định dạng cụ thể
                DateTime date = DateTime.ParseExact(dateMMDDYYYY, "MM/dd/yyyy", null);

                // Trả về chuỗi định dạng SQL: yyyy-MM-dd
                return date.ToString("yyyy-MM-dd");
            }
            catch (FormatException)
            {
                throw new FormatException("Ngày không đúng định dạng MM/DD/YYYY.");
            }
        }
        public static void FillDataToCombo(ComboBox cb, string sql, string value, string display)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adtater = new SqlDataAdapter(sql, con);
            adtater.Fill(dt);
            cb.DataSource = dt;
            cb.ValueMember = value;
            cb.DisplayMember = display;

        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter();	// Khai báo
            // Tạo đối tượng Command thực hiện câu lệnh SELECT        
            Mydata.SelectCommand = new SqlCommand();
            Mydata.SelectCommand.Connection = DAO.con; 	// Kết nối CSDL
            Mydata.SelectCommand.CommandText = sql;	// Gán câu lệnh SELECT
            DataTable table = new DataTable();    // Khai báo DataTable nhận dữ liệu trả về
            Mydata.Fill(table); 	//Thực hiện câu lệnh SELECT và đổ dữ liệu vào bảng table
            return table;
        }

    }
}
