using F2021A6LF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2021A6LF.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        private Manager m = new Manager();

        // GET: Albums
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            var album = m.AlbumGetByIdWithDetail(id.GetValueOrDefault());

            if (album == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(album);
            }
        }

        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var a = m.AlbumGetByIdWithDetail(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new TrackAddFormViewModel();
                form.AlbumName = a.Name;
                form.AlbumId = a.Id;
                //form.Clerk = User.Identity.Name;
                form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                return View(form);
            }
        }

        [Route("album/{id}/addtrack")]
        [HttpPost]
        public ActionResult AddTrack(TrackAddViewModel newTrack)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrack);
            }

            var addedTrack = m.TrackAdd(newTrack);

            if (addedTrack == null)
            {
                return View(newTrack);
            }
            else
            {
                return RedirectToAction("details", "tracks", new { id = addedTrack.Id });
            }
        }
    }
}
