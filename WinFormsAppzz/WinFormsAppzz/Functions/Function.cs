using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsAppzz.Functions
{
    internal class Function
    {
        public static SqlConnection Con;       

        public static void Connect()
        {
            Con = new SqlConnection(@"Data Source=BABYBOY2007\SQLEXPRESS;Initial Catalog = e_commerce; User ID =sa; Password = Thanh0706;Integrated Security=True"); 
            Con.Open();       
            if (!(Con.State == ConnectionState.Open)) MessageBox.Show("Không thể kết nối với dữ liệu");

        }
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
                Con.Dispose(); 	
                Con = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Function.Con;
            dap.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static object GetSingleValue(string query)
        {
            {
                using (SqlCommand command = new SqlCommand(query, Con))
                {
                    return command.ExecuteScalar();
                }
            }
        }
    }
}
