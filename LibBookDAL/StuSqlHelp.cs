using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LibBookDAL
{
    public class StuSqlHelp
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["StuContext"].ConnectionString;
        public static DataTable GetTable(string sql,CommandType type,SqlParameter[] pars)
        { 
        using(SqlConnection conn=new SqlConnection(connString))
        {
         using(SqlDataAdapter apter=new SqlDataAdapter(sql,conn))
         {
             apter.SelectCommand.CommandType = type;
             if(pars!=null)
             {
                 apter.SelectCommand.Parameters.AddRange(pars);
             }
             DataTable da = new DataTable();
             apter.Fill(da);
             return da;
         }
        }
        }

        public static int ExecteNonquery(string sql,CommandType type,SqlParameter[] pars)
        {
            using(SqlConnection conn=new SqlConnection(connString))
            {
                using(SqlCommand cmd=new SqlCommand(sql,conn))
                {
                    cmd.CommandType = type;
                    if(pars!=null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
