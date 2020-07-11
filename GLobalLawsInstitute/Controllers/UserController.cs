using GLI.GlobalEntity;
using Global.Utility;
using GlobalDal.DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace GLobalLawsInstitute.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ErrorException Error = new ErrorException();

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
                if (m.PhotoContent != null)
                {
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

                            //m.Name = filname;
                            //m.ext = fileext;
                            //m.FileContent = bytes;
                        }
                    }
                }
                if (m.Password != null)
                {
                    m.Password = Hashing.SHA256Generator(m.Password).ToUpper();
                    _da = new CommonDal();
                    bool value = _da.MemberShip(m);
                    if (value)
                    {
                        ViewBag.Message = "Membership Successfully Registered";
                    }
                }
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

        public ActionResult GetMemberShip()
        {
            CommonDal _da = null;
            string memberShipId = Session["MemberShipId"].ToString();
            try
            {
                _da = new CommonDal();
                List<MemberShip> gliList = new List<MemberShip>();
                gliList = _da.GetMemberShip(memberShipId);
                if (gliList.Count > 0)
                {

                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }

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
                return RedirectToAction("GetMemberShip", "User", true);
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
    }
}