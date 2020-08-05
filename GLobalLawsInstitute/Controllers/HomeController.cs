using GlobalDal.DataLayer;
using GLI.GlobalEntity;
using System.Web.Mvc;
using Global.Utility;
using System;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Web.Security;
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975

namespace GLobalLawsInstitute.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CommonDal cdal = null;
            CommonDal cdall = null;
            try
            {
                cdal = new CommonDal();
                cdall = new CommonDal();
                List<Notifications> lst = cdal.GetNotification();
<<<<<<< HEAD
=======

                //Notifications not = cdall.GetHitCount();
                //if (not.HitCount != null)
                //{
                //    ViewData["HitCount"] = not.HitCount;
                //}
                //else
                //{
                //    ViewData["HitCount"] = null;
                //}

>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975
                return View(lst);
            }
            catch (Exception ex)
            {
                cdal = new CommonDal();
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO lg)
        {
            CommonDal Cdal = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (lg.UserName != null && lg.Password != null)
                    {
                        Cdal = new CommonDal();
                        lg.Password = Hashing.SHA256Generator(lg.Password).ToUpper();
                        LoginDTO login = Cdal.GetLoginDetails(lg);
                        if (login.Status == true)
                        {
                            Session["Id"] = login.Id;
                            Session["RoleId"] = login.RoleId;
                            Session["UserName"] = login.UserName;
                            Session["MemberShipId"] = login.MemberShipId;
                            string name = login.DisplayName;

<<<<<<< HEAD
                            /*Bind Menus to Admin DashBoard*/
                            CommonDal _da = null;
                            _da = new CommonDal();
                            List<AdminMenu_DTO> GetMenus = new List<AdminMenu_DTO>();
                            GetMenus = _da.GetMenus();
                            Session["GetMenus"] = GetMenus;


=======
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975
                            if (login.RoleId == 1)
                            {
                                return RedirectToAction("Arbitration", "Admin");
                            }
                            if (login.RoleId == 2)
                            {
                                return RedirectToAction("GetMemberShip", "User");
                            }
                        }
                        else
                        {
                            ViewData["Message"] = "Invalid UserName or Password";
                        }
                    }
                    else
                    {
                        ViewData["Message"] = "Pleae Enter UserName or Password";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                Cdal = new CommonDal();
                Cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
        }
<<<<<<< HEAD

=======
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975
        public ActionResult Error()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Session["UserName"] = null;
            Session["RoleId"] = null;
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(LoginDTO lg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress(lg.UserName.Trim().ToLower()));  // replace with valid value 
                    message.From = new MailAddress("gorasanagarjuna@gmail.com");  // replace with valid value
                    message.Subject = "Your email subject";
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "gorasanagarjuna@gmail.com",  // replace with valid value
                            Password = "nag199562",  // replace with valid value
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Send(message);
                        ViewData["Message"] = "Mail sent successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "Mail sending failed.";
            }
            return View();

        }
<<<<<<< HEAD

=======
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Session["UserName"] = null;
            Session["RoleId"] = null;
            return View();
        }

<<<<<<< HEAD
        public JsonResult GetCountries()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<MastersDTO> GetCountries = new List<MastersDTO>();
                GetCountries = _da.GetCountries();
                return Json(GetCountries, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return Json("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }

=======
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975

    }
}