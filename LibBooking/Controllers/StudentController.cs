using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using LibBookBLL;
using Common;

namespace LibBooking.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Code()
        {
            string strCode = new ValidateCode().CreateValidateCode(4);
            Session["code"] = strCode;
            return File(new ValidateCode().CreateValidateGraphic(strCode), "image/jpeg");
        }


        public ActionResult StuLogin(string stuNum,string stuPwd,string code)
        {
            string code1 = string.Empty;
            string data="";
            StuInofBll stuInofBll = new StuInofBll();
            if (Session["code"] != null)
            {
                code1 = Session["code"].ToString();
            }
            else
            {
                data = "past";
                return Json(data);
            }
            if (code == code1)
            {
                if (stuNum != null && stuPwd != null)
                {
                    StuInof stuInof = stuInofBll.GetStuInof(stuNum, stuPwd);
                    Session["stuInof"] = stuInof;
                    if (stuInof != null)
                    {
                        data = "true";
                        return Json(data);
                    }
                    else
                    {
                        data = "ok";
                        return Json(data);
                    }
                }
                else
                {
                    data = "no";
                    return Json(data);
                }
            }
            else
            {
                data = "out";
                return Json(data);
            }
        }

    }
}
