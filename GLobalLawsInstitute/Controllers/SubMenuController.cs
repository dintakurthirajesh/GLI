using GLI.GlobalEntity;
<<<<<<< HEAD
=======
using Global.Utility;
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975
using GlobalDal.DataLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace GLobalLawsInstitute.Controllers
{
    public class SubMenuController : Controller
    {
        // GET: SubMenu
        ErrorException Error = new ErrorException();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Arbitration()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<ArbitrationDTO> gliList = new List<ArbitrationDTO>();
                gliList = _da.GetArbitration();
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

        public ActionResult Mediation()
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

        public ActionResult Concillation()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<ArbitrationDTO> gliList = new List<ArbitrationDTO>();
                gliList = _da.GetConcillation();
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

        public ActionResult Negotiation()
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

        public ActionResult CopyRights()
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<ArbitrationDTO> gliList = new List<ArbitrationDTO>();
                gliList = _da.GetCopyRights();
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


        [HttpPost]
        public ActionResult InsertContactUs(ContactUs C)
        {
            CommonDal cdal = null;
            try
            {
                cdal = new CommonDal();
                bool value = cdal.InsertContactUs(C);
                if (value)
                {
                    ViewData["ContactUs"] = "We will Contact you Soon";
                    return RedirectToAction("Rajesh", "Home");
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

        public ActionResult Gallery(char R)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<Gallery> gliList = new List<Gallery>();
                gliList = _da.GetGallery(R);
                return View(gliList);
            }
            catch (Exception ex)
            {
                _da = null;
                _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                _da = null;
            }
        }

        [ActionName("MemberShip")]
        public ActionResult MemberShip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberShip(MemberShip m)
        {
            CommonDal _da = null;
            try
            {
                IFormatProvider culture = new CultureInfo("en-US", true);
                string DateString = m.DOB.ToString("dd-MM-yyyy");
                m.DOB = DateTime.ParseExact(DateString, "dd-MM-yyyy", culture);
                if (m.PhotoContent != null)
                {
                    var files = m.PhotoContent;
                    Stream fss = files.InputStream;
                    BinaryReader br = new BinaryReader(fss);
                    Byte[] bytes = br.ReadBytes((Int32) fss.Length);
                    string mimes = MimeType.GetMimeType(bytes, files.FileName);
                    if (mimes == "image/jpeg" || mimes == "image/png")
                    {
                        int len = files.ContentLength;
                        if ((len / 1024) > 2048)
                        {

                            //objCommon.ShowAlertMessage("File size is exceeded");
                            //FileUpdphoto.Focus();
                            //return;
                        }
                        else
                        {
                            string fileext = Path.GetExtension(files.FileName);
                            string filname = Path.GetFileName(files.FileName);

                            var fileName = Path.GetFileName(m.PhotoContent.FileName); //getting only file name(ex-ganesh.jpg)  
                            var ext = Path.GetExtension(m.PhotoContent.FileName); //getting the extension(ex-.jpg)  
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext; //appending the name with id                              
                            var path = Path.Combine(Server.MapPath("~/Gallery"), myfile);
                            m.PhotoContent.SaveAs(path);
                            m.PhotoName = filname;
                            m.PhotoType = fileext;
                        }
                    }
                }

                //if (m.Password != null)
                //{
                //    m.Password = Hashing.SHA256Generator(m.Password).ToUpper();
                _da = new CommonDal();
                bool value = _da.MemberShip(m);
                if (value)
                {
                    ViewBag.Message = "Membership Successfully Registered";
                }
                //}
                return View();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("ix_user_email"))
                {
                    ViewBag.Membership = "Email already Exists";
                    return View();
                }
                else
                {
                    _da = new CommonDal();
                    _da.ExceptionDtls(ex.Message, ex.GetType().ToString(), ex.StackTrace);
                    return RedirectToAction("Error", "Home");
                }
            }
            finally
            {
                _da = null;
            }
        }

        //public ActionResult GetMemberShip()
        //{
        //    CommonDal _da = null;
        //    try
        //    {
        //        _da = new CommonDal();
        //        List<MemberShip> gliList = new List<MemberShip>();
        //        gliList = _da.GetMemberShip();
        //        if (gliList != null)
        //            ViewData["memberShip"] = "No Data Found";
        //        return View(gliList);
        //    }
        //    catch (Exception ex)
        //    {
        //        _da.ExceptionDtls(ex.Message, ex.GetType().ToString(),ex.StackTrace);
        //        return RedirectToAction("Error", "Home");
        //    }
        //    finally
        //    {
        //        _da = null;
        //    }
        //}

        public ActionResult EditMemberShip(MemberShip m)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                MemberShip mst = _da.EditMemberShip(m);
                return View(mst);
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

        [HttpPost]
        public ActionResult UpdateMemberShip(MemberShip m)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                ViewData["MemberShip"] = _da.UpdateMemberShip(m);
                if (ViewData["MemberShip"] == null)
                {
                    ViewData["MemberShip"] = "Data Not Updated";
                }
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

        public ActionResult DeleteMemberShip(MemberShip m)
        {
            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                ViewBag.Message = _da.DeleteMemberShip(m);
                return RedirectToAction("GetMemberShip", "SubMenu", true);
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

        public JsonResult GetCountriesList(string Areas, string term = "")
        {

            CommonDal _da = null;
            try
            {
                _da = new CommonDal();
                List<MastersDTO> GetCountries = new List<MastersDTO>();
                GetCountries = _da.GetCountries();


                var objCountrielist = GetCountries.Where(c => c.CountryName.ToUpper()
                        .Contains(term.ToUpper()))
                        .Select(c => new { Name = c.CountryName, ID = c.Id })
                        .Distinct().ToList();



                return Json(objCountrielist, JsonRequestBehavior.AllowGet);
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
    }
}