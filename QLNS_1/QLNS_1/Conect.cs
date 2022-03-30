using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QLNS_1
{
    class Conect
    {
        public static string con = "Data Source=IRIS;Initial Catalog=QLNS;Integrated Security=True";
        public static DataTable GetData(string lenh)
        {
            SqlConnection sqlCon = new SqlConnection(con);
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(lenh, sqlCon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void Execute(string lenh)
        {
            using (SqlConnection sqlCon = new SqlConnection(con))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(lenh, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}
