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

        /// <summary>
        /// 获取时间段里的人数
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public int selectMsg(DateTime startTime,DateTime endTime)
        {
            int msgCount = bookMsgDal.selectMsg(startTime, endTime);
            return msgCount;
        }

        /// <summary>
        /// 添加预定信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="bookTime"></param>
        /// <returns></returns>
        public int AddMsg(string userName,int roomNum,int tableNum,DateTime bookTime,DateTime startTime,DateTime endTime)
        {
            return bookMsgDal.AddMsg(userName, roomNum, tableNum, bookTime,startTime,endTime);
        }
    }
}
