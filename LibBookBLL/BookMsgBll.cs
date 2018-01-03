using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using LibBookDAL;

namespace LibBookBLL
{
    public class BookMsgBll
    {
        BookMsgDal bookMsgDal = new BookMsgDal();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的数据</param>
        /// <returns></returns>
        public List<BookMsg> GetPageList(int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageSize * pageIndex;
            List<BookMsg> list = bookMsgDal.GetPageList(start, end);
            return list;
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = bookMsgDal.GetRecordCount();
            int pageCount=Convert.ToInt32( Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteMsg(int id)
        {
            return bookMsgDal.DeleteMsg(id);
        }
    }
}
