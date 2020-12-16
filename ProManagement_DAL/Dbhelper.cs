using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace ProManagement_DAL
{
    public class Dbhelper
    {
        private static string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public List<T> GetData <T>(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql,conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                var json = JsonConvert.SerializeObject(dt);

                List<T> list = JsonConvert.DeserializeObject<List<T>>(json);

                return list;
            }
        }

        public int ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                return cmd.ExecuteNonQuery();
            }
        }

        public int ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
