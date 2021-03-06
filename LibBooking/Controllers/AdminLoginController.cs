﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibBookBLL;
using Model;
using Common;
using System.Text;

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
        [HttpPost]
        public ActionResult AdminLogin(string adminName,string adminPwd,string code)
        {
            
            string code1 = string.Empty;
            AdminSerevce adminSerevce = new AdminSerevce();
            Admin da = adminSerevce.GetAdminInof(adminName, adminPwd);
            string data = "";
            if(Session["code"]!=null)
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
                if (adminName != "" && adminPwd != "")
                {

                    if (da != null)
                    {
                        data = "ture";
                        return Json(data);
                    }
                    else
                    {
                        data = "false";
                        return Json(data);
                    }
                }
                else
                {
                    data = "null";
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
