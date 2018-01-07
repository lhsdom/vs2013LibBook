using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibBookBLL;
using Model;


namespace LibBooking.Controllers
{
    public class GetBookMsgController : Controller
    {
        //
        // GET: /GetBookMsg/
        BookMsgBll BookMsgBll = new BookMsgBll();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Msg()
        {
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 8;
            int pageCount = BookMsgBll.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<BookMsg> list = BookMsgBll.GetPageList(pageIndex, pageSize);
            ViewData["list"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public JsonResult DeleteBookMsg(int  id)
        {
            
            string data = "";
            if (BookMsgBll.DeleteMsg(id )> 0)
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
