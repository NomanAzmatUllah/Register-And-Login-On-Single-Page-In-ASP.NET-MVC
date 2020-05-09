using login_signup_onepage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace login_signup_onepage.Controllers
{
    public class Regster_LoginController : Controller
    {
        loginregisterEntities db = new loginregisterEntities();

        // GET: Regster_Login
    
        [HttpGet]
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(loginregisterviewmodel obj)
        {

            tbl_login t = new tbl_login();
            t.R_name = obj.R_name;
            t.R_email = obj.R_email;
            t.R_password = obj.R_password;
            db.tbl_login.Add(t);
            db.SaveChanges();
            return RedirectToAction("register");


            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(loginregisterviewmodel obj)
        {

            tbl_login t = db.tbl_login.Where(x=>x.R_email == obj.R_email  && x.R_password == obj.R_password).Single();
            if (t!=null)
            {

                Session["id"] = t.R_name;
            }
            else
            {

                return HttpNotFound();
            }
            return RedirectToAction("Index","Home");

            return View();
        }





    }
}