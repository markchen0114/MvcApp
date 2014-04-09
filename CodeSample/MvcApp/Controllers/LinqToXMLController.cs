using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class LinqToXMLController : Controller
    {
        public ActionResult Index(FormCollection fc)
        {
            HttpPostedFileBase hpf = null;
            string XML = ""; //User上傳的XML
            string ViewXML = ""; //XML的搜尋結果
            switch (fc["act"])
            {
                case "XMLMenu": //讀取 XML File of Menu
                    hpf = Request.Files["MenuXMLFile"];
                    if (hpf == null || hpf.ContentLength <= 0)
                        ModelState.AddModelError("MenuXMLFile", "pls choice a XML file of Menu");
                    else
                    {
                        byte[] buffer = new byte[hpf.ContentLength];
                        using (BinaryReader br = new BinaryReader(hpf.InputStream))
                            br.Read(buffer, 0, buffer.Length);
                        XML = System.Text.Encoding.Default.GetString(buffer);

                        string MenuCode = "";
                        if (fc["MenuCode"] != null)
                            MenuCode = fc["MenuCode"].ToString();
                        ViewXML = new ViewModels.LinqToXMLViewModel().ReadXML(XML, "Menu", "Code", MenuCode);
                    }
                    break;
                case "XMLUserAuthor": //讀取 XML File of UserAuthor
                    hpf = Request.Files["UserAuthorXMLFile"];
                    if (hpf == null || hpf.ContentLength <= 0)
                        ModelState.AddModelError("UserAuthorXMLFile", "pls choice a XML file of UserAuthor");
                    else
                    {
                        byte[] buffer = new byte[hpf.ContentLength];
                        using (BinaryReader br = new BinaryReader(hpf.InputStream))
                            br.Read(buffer, 0, buffer.Length);
                        XML = System.Text.Encoding.Default.GetString(buffer);

                        string SystemUserId = "";
                        if (fc["SystemUserId"] != null)
                            SystemUserId = fc["SystemUserId"].ToString();
                        ViewXML = new ViewModels.LinqToXMLViewModel().ReadXML(XML, "UserAuthor", "SystemUserId", SystemUserId);
                    }
                    break;
            }
            ViewBag.XML = ViewXML;
            return View();
        }

        /// <summary>下載XML File of Menu範例檔</summary>
        /// <returns>XML File</returns>
        public FileResult GetSampleXMLOfMenu()
        {
            ViewModels.LinqToXMLViewModel linqToXMLModel = new ViewModels.LinqToXMLViewModel();
            string content = linqToXMLModel.GetSampleXMLOfMenu();
            var bytes = Encoding.Default.GetBytes(content);
            return File(bytes, "text/xml", "SampleXMLOfMenu.xml");
        }

        /// <summary>下載XML File of UserAuthor範例檔</summary>
        /// <returns>XML File</returns>
        public FileResult GetSampleXMLOfUserAuthor()
        {
            ViewModels.LinqToXMLViewModel linqToXMLModel = new ViewModels.LinqToXMLViewModel();
            string content = linqToXMLModel.GetSampleXMLOfUserAuthor();
            var bytes = Encoding.Default.GetBytes(content);
            return File(bytes, "text/xml", "SampleXMLOfUserAuthor.xml");
        }
    }
}
