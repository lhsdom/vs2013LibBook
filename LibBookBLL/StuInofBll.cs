using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using LibBookDAL;

namespace LibBookBLL
{
    public class StuInofBll
    {
        StuInofDal stuInofDal = new StuInofDal();
        public StuInof GetStuInof(string stuNum,string stuPwd)
        {
            return stuInofDal.GetStuInof(stuNum, stuPwd);
        }
    }
}
