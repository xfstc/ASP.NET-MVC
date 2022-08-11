using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2021A6LF.Controllers
{
    public class ArtistMediaItemsController : Controller
    {
        Manager m = new Manager();

        // GET: ArtistMediaItems
        public ActionResult Index()
        {
            return View("index", "home");
        }

        // GET: ArtistMediaItems/Details/5
        [Route("artistmediaitems/{stringId}")]
        public ActionResult Details(string stringId = "")
        {
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Content, o.ContentType);
            }
        }

        [Route("artistmediaitems/{stringId}/download")]
        public ActionResult DetailsDownload(string stringId = "")
        {
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                string extension;
                RegistryKey key;
                object value;

                key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + o.ContentType, false);

                value = (key == null) ? null : key.GetValue("Extension", null);

                extension = (value == null) ? string.Empty : value.ToString();

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = $"document-{stringId}{extension}",
                    Inline = false
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(o.Content, o.ContentType);
            }
        }
    }
}
