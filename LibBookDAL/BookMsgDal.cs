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
    public class BookMsgDal
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public  List<BookMsg> GetPageList(int start,int end)
        {
            string sql = "select * from (select row_number() over (order by id)as num,* from BookMsg)as t where t.num<=@end and t.num>=@start";
            SqlParameter[] pars = { 
                                  new SqlParameter("@start",start),
                                  new SqlParameter("@end",end),
                                  };
            DataTable da= SqlHelp.GetTable(sql, CommandType.Text, pars);
            List<BookMsg> list = null;
            if(da.Rows.Count>0)
            {
                list=new List<BookMsg>();
                BookMsg bookMsg = null;
                foreach(DataRow row in da.Rows)
                {
                    bookMsg=new BookMsg();
                    LoadEntity(row, bookMsg);
                    list.Add(bookMsg);
                }
            }
            return list;
        }
        /// <summary>
        /// 将每行的数据给model对象
        /// </summary>
        /// <param name="row"></param>
        /// <param name="bookMsg"></param>
        private void LoadEntity(DataRow row,BookMsg bookMsg)
        {
            bookMsg.Id = Convert.ToInt32(row["Id"]);
            bookMsg.RoomNum = Convert.ToInt32(row["RoomNum"]);
            bookMsg.TableNum = Convert.ToInt32(row["TableNum"]);
            bookMsg.UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            bookMsg.BookTime = Convert.ToDateTime(row["BookTime"]);
            bookMsg.StartTime = Convert.ToDateTime(row["StartTime"]);
            bookMsg.EndTime = Convert.ToDateTime(row["EndTime"]);
        }

        /// <summary>
        /// 获取总页数数据
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from BookMsg";
            return Convert.ToInt32(SqlHelp.ExecuteScalare(sql,CommandType.Text));
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteMsg(int id)
        {
            string sql = "delete from BookMsg where id=@id";
            SqlParameter[] pars={
                                    new SqlParameter("@id",id),
                                };
            return SqlHelp.ExecuteNonquery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 通过时间段来查询数据总数
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public int selectMsg(DateTime startTime,DateTime endTime)
        {
            string sql = "select count(*) from BookMsg where BookTime between @startTime and @endTime";
            SqlParameter[] pars ={
                                    new SqlParameter("@startTime",startTime),
                                    new SqlParameter("@endTime",endTime),
                                };
            return Convert.ToInt32(SqlHelp.ExecuteScalare(sql,CommandType.Text,pars));
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
            string sql = "insert int BookMsg values(@userName,@roomNum,@tableNum,@bookTime,@starTime,@endTime)";
            SqlParameter[] pars ={
                                     new SqlParameter("@userName",userName),
                                     new SqlParameter("@roomNum",roomNum),
                                     new SqlParameter("@tableNum",tableNum),
                                     new SqlParameter("@bookTime",bookTime),
                                     new SqlParameter("@starTime",startTime),
                                     new SqlParameter("@endTime",endTime),
                                };
            return SqlHelp.ExecuteNonquery(sql,CommandType.Text,pars);
        }
    }
}
