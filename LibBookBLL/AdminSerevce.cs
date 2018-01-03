using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibBookDAL;
using Model;

namespace LibBookBLL
{
    public class AdminSerevce
    {
        AdminDal AdminDal = new AdminDal();
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="adminName"></param>
        /// <param name="adminPwd"></param>
        /// <returns></returns>
        public Admin GetAdminInof(string adminName,string adminPwd)
        {
            return AdminDal.GetAdminInof(adminName, adminPwd);
        }
    }
}
