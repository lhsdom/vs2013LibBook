using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using LibBookBLL;

namespace LibBooking.Controllers
{
    public class AddBookMsgController : Controller
    {
        //
        // GET: /AddBookMsg/
        BookMsgBll bookMsgBll = new BookMsgBll();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 预定座位
        /// </summary>
        /// <param name="roomNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="bookTime"></param>
        /// <returns></returns>
        public ActionResult AddBookMsg(int roomNum,int tableNum,DateTime bookTime,DateTime startTime,DateTime endTime)
        {
            var student = Session["stuInof"] as StuInof;
            string data = "";
            if(bookMsgBll.AddMsg(student.stuNum,roomNum,tableNum,bookTime,startTime,endTime)>0)
            {
                data = "ok";
                return Json(data);
            }
            else
            {
                return Json(data);
            }

        }

    }
}
