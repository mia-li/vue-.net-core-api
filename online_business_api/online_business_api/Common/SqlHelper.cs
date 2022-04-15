using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace online_business_api.Common
{
    public class SqlHelper
    {
        public static string ConStr { get; set; }
        public static DataTable ExecuteTable(string cmdText)
        {
            using(SqlConnection con=new SqlConnection(ConStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds.Tables[0];
            }
        }
        public static int ExecuteNonQuery(string cmdText)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                int rows=cmd.ExecuteNonQuery();//得到受影响的行数
                if(rows<0)
                {
                    throw new Exception("数据库执行错误");
                }
                return rows;
                
            }

        }
    }
}
