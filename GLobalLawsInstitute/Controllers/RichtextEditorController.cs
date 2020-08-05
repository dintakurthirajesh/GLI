using RTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace GLobalLawsInstitute.Controllers
{
    public class RichtextEditorController : Controller
    {
        // GET: RichtextEditor


        public ActionResult RichTextEditor()
        {
            Editor Editor1 = new Editor(System.Web.HttpContext.Current, "Editor1");
            Editor1.LoadFormData("Type here...");
            Editor1.Toolbar = "minimal";
            Editor1.ClientFolder = "/richtexteditor/";
            Editor1.ContentCss = "/richtexteditor/styles/richtexteditor.css";
            Editor1.LoadHtml("~/templates/template1.html");
            Editor1.AjaxPostbackUrl = Url.Action("EditorAjaxHandler");

            Editor1.ID = Editor1.Name = "Editor1";
            Editor1.Width = Unit.Pixel(750);
            Editor1.Height = Unit.Pixel(300);
            Editor1.Skin = "smartblue";
            Editor1.Toolbar = "forum";
            Editor1.Text = "<div style='color:red;'><strong>1. Easy for developers</strong></div>";



            Editor1.AllowScriptCode = true;
            Editor1.EditCompleteDocument = true;
            Editor1.TagBlackList = "";
            Editor1.Text = "<html><head></head><body><div>Editor full html page</div><br/><br/>" +
                    "<div style='font-weight:bold;'>editor.AllowScriptCode = true;<br/>editor.EditCompleteDocument = true;<br/>editor.TagBlackList = \"\";</div></body></html>";

            //Paste Options
            string m = "";
            m = Request.Form["SelectType"];
            if (!string.IsNullOrEmpty(m))
            {
                if (m == "Disabled")
                {
                    Editor1.PasteMode = RTEPasteMode.Disabled;
                }
                if (m == "Paste")
                {
                    Editor1.PasteMode = RTEPasteMode.Paste;
                }
                if (m == "PasteText")
                {
                    Editor1.PasteMode = RTEPasteMode.PasteText;
                }
                if (m == "PasteWord")
                {
                    Editor1.PasteMode = RTEPasteMode.PasteWord;
                }
                if (m == "ConfirmWord")
                {
                    Editor1.PasteMode = RTEPasteMode.ConfirmWord;
                }
                ViewBag._mode = m;
            }
            else
                Editor1.PasteMode = RTEPasteMode.Default;


            Editor1.SetSecurity("Gallery", "default", "StoragePath", "~/uploads");
            Editor1.SetSecurity("Gallery", "default", "StorageName", "Uploads");

            Editor1.UploadImage += new UploadImageEventHandler(Editor1_UploadImage);

            Editor1.MvcInit();
            Session["Editor"] = Editor1.MvcGetString();
            // return View();
            //return RedirectToAction("Admin/Arbitration");
            return RedirectToAction("Arbitration", "Admin");
        }


        void Editor1_UploadImage(object sender, UploadImageEventArgs args)
        {
            string text = Request["txt_watermark"];
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(400, 200, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
            {
                System.Drawing.FontStyle style = System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline;
                System.Drawing.Font font = new System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 26, style);
                System.Drawing.SizeF size = g.MeasureString(text, font);
                g.DrawString(text, font, System.Drawing.Brushes.DarkGreen, bitmap.Width - size.Width, bitmap.Height - size.Height);
            }

            RTE.ConfigWatermark watermark = new ConfigWatermark();
            watermark.XAlign = "right";
            watermark.YAlign = "bottom";
            watermark.XOffset = -10;
            watermark.YOffset = -10;
            watermark.MinWidth = 450;
            watermark.MinHeight = 300;
            watermark.Image = bitmap;

            args.Watermarks.Clear();
            args.Watermarks.Add(watermark);
            args.DrawWatermarks = true;
        }




    }
}