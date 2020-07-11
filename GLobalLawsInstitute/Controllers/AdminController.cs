using GLI.GlobalEntity;
using GlobalDal.DataLayer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static GLobalLawsInstitute.FilterConfig;

namespace GLobalLawsInstitute.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin 27 mar 2010

        [NoDirectAccess]
        public ActionResult Index(AdminMenu_DTO M)
        {
            try
            {
                CommonDal cdal = new CommonDal();
                List<AdminMenu_DTO> lstMenus = cdal.GetArbitrations(M);
                if (lstMenus.Count > 0)
                {
                    ViewBag.Menus = lstMenus;
                }

                return View(lstMenus);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        #region Arbitration
        [NoDirectAccess]
        public ActionResult Arbitration()
        {
            return View();
        }

        #region InsertArbitration
        [HttpPost]
        public ActionResult Arbitration(ArbitrationDTO AR)
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                bool value = cdal.InsertArbitration(AR);
                if (value)
                {
                    Session["Arbitration"] = "Data Inserted";
                    return RedirectToAction("GetDepartment", "Admin");

                }
                return View();
            }
            catch (Exception ex)
            {
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                cdal = null;
            }
        }
        #endregion

        #region GetDepartment
        [HttpGet]
        public ActionResult GetDepartment()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<ArbitrationDTO> gliList = _da.GetArbitration();
                return View(gliList);
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region EditArbitration
        [HttpGet]
        public ActionResult EditArbitration(int id)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                return View(_da.GetArbitrationById(id, 'E'));
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region UpdateArbitration
        [HttpPost]
        public ActionResult UpdateArbitration(ArbitrationDTO ar)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                bool _val = _da.UpdateArbitration(ar);
                if (_val)
                    return RedirectToAction("GetDepartment", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region DeleteArbitration
        public ActionResult DeleteArbitration(int id, string delete)
        {
            CommonDal _da = null;
            try
            {
                delete = "D";
                _da = new CommonDal();
                bool _val = _da.DeleteArbitration(id, delete);
                if (_val)
                    return RedirectToAction("GetDepartment", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #endregion

        #region Mediation
        [NoDirectAccess]
        public ActionResult Mediation()
        {
            return View();
        }

        #region GetMediation
        [NoDirectAccess]
        [HttpGet]
        public ActionResult GetMediation()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<ArbitrationDTO> gliList = new List<ArbitrationDTO>();
                gliList = _da.GetMediation();
                return View(gliList);
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region EditMediation
        public ActionResult EditMediation(int id)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                return View(_da.GetMediationById(id, 'E'));
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region UpdateMediation
        [HttpPost]
        public ActionResult UpdateMediation(ArbitrationDTO ar)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                bool _val = _da.UpdateMediations(ar);
                if (_val)
                    return RedirectToAction("GetMediation", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region DeleteMediation
        public ActionResult DeleteMediation(int id, string delete)
        {
            CommonDal _da = null;
            try
            {
                delete = "D";
                _da = new CommonDal();
                bool _val = _da.DeleteMediations(id, delete);
                if (_val)
                    return RedirectToAction("GetMediation", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion
        #endregion

        #region Concillation
        [NoDirectAccess]
        public ActionResult Concillation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Concillation(ArbitrationDTO AR)
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                bool value = cdal.InsertConcillation(AR);
                if (value)
                    return RedirectToAction("GetConcillation", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                cdal = null;
            }

        }

        #region GetConcillation

        [HttpGet]
        [NoDirectAccess]
        public ActionResult GetConcillation()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<ArbitrationDTO> gliList = new List<ArbitrationDTO>();
                gliList = _da.GetConcillation();
                return View(gliList);
                //CommonDAL _da = new CommonDAL();
                //return View(_da.GetConcillation(id, R));
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region DeleteConcillation
        public ActionResult DeleteConcillation(int id, string delete)
        {
            CommonDal _da = null;
            try
            {
                delete = "D";
                _da = new CommonDal();
                bool _val = _da.DeleteConcillation(id, delete);
                if (_val)
                    return RedirectToAction("GetConcillation", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion
        #endregion

        #region CopyRights
        [NoDirectAccess]
        public ActionResult CopyRights()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CopyRights(ArbitrationDTO AR)
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                bool value = cdal.InsertCopyRights(AR);
                if (value)
                    return RedirectToAction("GetCopyRights", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                cdal = null;
            }

        }

        #region GetCopyRights
        [HttpGet]
        [NoDirectAccess]
        public ActionResult GetCopyRights()
        {
            CommonDal _da = null;
            try
            {

                _da = new CommonDal();
                return View(_da.GetCopyRights());
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region DeleteCopyRights
        public ActionResult DeleteCopyRights(int id, string delete)
        {
            CommonDal _da = null;
            try
            {
                delete = "D";
                _da = new CommonDal();
                bool _val = _da.DeleteCopyRights(id, delete);
                if (_val)
                    return RedirectToAction("GetCopyRights", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion
        #endregion

        #region TradeMarks
        [NoDirectAccess]
        public ActionResult TradeMarks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TradeMarks(ArbitrationDTO AR)
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                bool value = cdal.InsertTradeMarks(AR);
                if (value)
                    return RedirectToAction("GetMediation", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                cdal = null;
            }

        }

        #region GetTradeMarks
        public ActionResult GetTradeMarks()
        {
            CommonDal _da = null;
            try
            {

                _da = new CommonDal();
                return View(_da.GetTradeMarks());
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion
        #endregion

        //public IActionResult Gallery(ImageGallery gallery)
        //{
        //    try
        //    {
        //        if (gallery.UploadFile != null)
        //        {
        //            var files = gallery.UploadFile;
        //            var stream = Request.Body;
        //            Stream fss = stream;
        //            BinaryReader br = new BinaryReader(fss);
        //            Byte[] bytes = br.ReadBytes((Int32)fss.Length);
        //            string mimes = MimeType.GetMimeType(bytes, files.FileName);

        //            if (mimes == "image/jpeg" || mimes == "image/png")
        //            {
        //                int len = files.ContentType.Length;
        //                if ((len / 1024) > 2048)
        //                {
        //                    //objCommon.ShowAlertMessage("File size is exceeded");
        //                    //FileUpdphoto.Focus();
        //                    //return;
        //                }
        //                string fileext = Path.GetExtension(files.FileName);
        //                string filname = Path.GetFileName(files.FileName);
        //                gallery.FileName = filname;
        //                gallery.FileExt = fileext;
        //                gallery.FileContent = bytes;
        //            }
        //            bool value = cbal.InsertImageGallery(gallery);
        //            if (value)
        //                ViewBag.Message = "Data Inserted";
        //            else
        //                ViewBag.Message = "Not Inserted";
        //        }
        //        return View();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        #region Negotiation
        //Concillation
        [NoDirectAccess]
        public ActionResult Negotiation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Negotiation(ArbitrationDTO AR)
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                bool value = cdal.InsertNegotiation(AR);
                if (value)
                    return RedirectToAction("GetNegotiation", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                cdal = null;
            }
        }

        #region GetNegotiation
        [HttpGet]
        [NoDirectAccess]
        public ActionResult GetNegotiation()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<ArbitrationDTO> gliList = new List<ArbitrationDTO>();
                gliList = _da.GetNegotiation();
                return View(gliList);
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region DeleteNegotiation
        public ActionResult DeleteNegotiation(int id, string delete)
        {
            CommonDal _da = null;
            try
            {
                delete = "D";
                _da = new CommonDal();
                bool _val = _da.DeleteNegotiation(id, delete);
                if (_val)
                    return RedirectToAction("GetNegotiation", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion
        #endregion

        #region Notifications
        [NoDirectAccess]
        public ActionResult Notifications()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Notifications(Notifications AR)
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                bool value = cdal.InsertNotofications(AR);
                if (value)
                {
                    return RedirectToAction("GetNotifications", "Admin");
                }
                return View();
            }
            catch (Exception ex)
            {
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                cdal = null;
            }
        }

        #region GetNotifications
        [NoDirectAccess]
        public ActionResult GetNotifications()
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                List<Notifications> lst = cdal.GetNotification();
                return View(lst);
            }
            catch (Exception ex)
            {
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                cdal = null;
            }
        }
        #endregion

        #region DeleteNotifications
        public ActionResult DeleteNotifications(Notifications N)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                bool _val = _da.DeleteNotifications(N);
                if (_val)
                    return RedirectToAction("GetNotifications", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion
        #endregion

        #region Hacking
        [NoDirectAccess]
        public ActionResult Hacking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Hacking(ArbitrationDTO AR)
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                bool value = cdal.InsertHacking(AR);
                if (value)
                    return RedirectToAction("GetHacking", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                cdal.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                cdal = null;
            }

        }

        #region GetHacking
        [HttpGet]
        [NoDirectAccess]
        public ActionResult GetHacking()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<ArbitrationDTO> gliList = new List<ArbitrationDTO>();
                gliList = _da.GetHacking();
                return View(gliList);
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region EditHacking
        public ActionResult EditHacking(int id)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                return View(_da.GetHackingById(id, 'E'));
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion

        #region UpdateHacking
        [HttpPost]
        public ActionResult UpdateHacking(ArbitrationDTO ar)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                bool _val = _da.UpdateMediations(ar);
                if (_val)
                    return RedirectToAction("GetHacking", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion
        #region DeleteHacking
        public ActionResult DeleteHacking(int id, string delete)
        {
            CommonDal _da = null;
            try
            {
                delete = "D";
                _da = new CommonDal();
                bool _val = _da.DeleteHacking(id, delete);
                if (_val)
                    return RedirectToAction("GetHacking", "Admin");
                return View();
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }
        #endregion
       

        [NoDirectAccess]
        public ActionResult DisplayMembership()
        {
            CommonDal _da = null;
            try
            {
                string Get = "R";
                _da = new CommonDal();
                List<MemberShip> Mem = _da.GetMemberShip(Get);
                return View(Mem);
            }
            catch (Exception ex)
            {
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }

        #endregion
    }
}