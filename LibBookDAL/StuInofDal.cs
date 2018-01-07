using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace LibBookDAL
{
    public class StuInofDal
    {
        public StuInof GetStuInof(string stuNum,string stuPwd)
        {
            string sql = "select * from StuInof where stuNum=@stuNum and stuPwd=@stuPwd";
            SqlParameter[] pars ={
                                    new SqlParameter("@stuNum",SqlDbType.NVarChar,20),
                                    new SqlParameter("@stuPwd",SqlDbType.NVarChar,20),
                                };
            pars[0].Value = stuNum;
            pars[1].Value = stuPwd;
            DataTable da = StuSqlHelp.GetTable(sql, CommandType.Text, pars);
            StuInof stuInof = null;
            if(da.Rows.Count>0)
            {
                stuInof = new StuInof();
                LoadEntity(stuInof, da.Rows[0]);
            }
            return stuInof;
        }

        public void LoadEntity(StuInof stuInof,DataRow row)
        {
            stuInof.id = Convert.ToInt32(row["id"]);
            stuInof.stuNum = row["stuNum"] != DBNull.Value ? row["stuNum"].ToString() : string.Empty;
            stuInof.stuPwd = row["stuPwd"] != DBNull.Value ? row["stuPwd"].ToString() : string.Empty;
            stuInof.name = row["name"] != DBNull.Value ? row["name"].ToString() : string.Empty;
        }
    }
}
