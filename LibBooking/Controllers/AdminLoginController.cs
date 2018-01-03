using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibBookBLL;
using Model;
using Common;

namespace LibBooking.Controllers
{
    public class AdminLoginController : Controller
    {
        //
        // GET: /AdminLogin/

        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 获取4位验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult Code()
        {
            string strCode = new ValidateCode().CreateValidateCode(4);
            Session["code"] = strCode;
            return File(new ValidateCode().CreateValidateGraphic(strCode), "image/jpeg");
        }
       
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminLogin()
        {
            string adminName = Request["adminName"];
            string adminPwd = Request["adminPwd"];
            string textCode = Request["code"];
            string code = string.Empty;
            AdminSerevce adminSerevce = new AdminSerevce();
            Admin da = adminSerevce.GetAdminInof(adminName, adminPwd);

            if (adminName != "" && adminPwd != "")
            {
                if (da != null)
                {
                    return Redirect(Url.Action("Index", "GetBookMsg"));
                }
                else
                {
                    Response.Write("<script>alert('登录失败')</script>");
                    return View("Login");
                }
            }
            else
            {
                Response.Write("<script>alert('用户名或密码不能为空')</script>");
                return View("Login");
            }

        }
    }
}
