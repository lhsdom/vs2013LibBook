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
    public class AdminDal
    {
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="adminName"></param>
        /// <param name="adminPwd"></param>
        /// <returns></returns>
        public Admin GetAdminInof(string adminName,string adminPwd)
        {
            string sql = "select * from Admin where AdminName=@AdminName and AdminPwd=@AdminPwd";
            SqlParameter[] pars ={
                                 new SqlParameter("@AdminName",SqlDbType.NVarChar,20),
                                 new SqlParameter("@AdminPwd",SqlDbType.NVarChar,20),
                                };
            pars[0].Value = adminName;
            pars[1].Value = adminPwd;
            DataTable da = SqlHelp.GetTable(sql, CommandType.Text, pars);
            Admin admin = null;
            if(da.Rows.Count>0)
            {
                admin=new Admin();
                LoadEntity(admin, da.Rows[0]);
            }
            return admin;
        }

        public void LoadEntity(Admin admin,DataRow row)
        {
            admin.Id = Convert.ToInt32(row["Id"]);
            admin.AdminName = row["AdminName"] != DBNull.Value ? row["AdminName"].ToString() : string.Empty;
            admin.AdminPwd = row["AdminPwd"] != DBNull.Value ? row["AdminPwd"].ToString() : string.Empty;
        }
    }
}
