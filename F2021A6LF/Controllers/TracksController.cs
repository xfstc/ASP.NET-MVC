using F2021A6LF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2021A6LF.Controllers
{
    [Authorize]

    public class TracksController : Controller
    {
        private Manager m = new Manager();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(m.TrackGetAllWithDetail());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            var track = m.TrackGetById(id.GetValueOrDefault());

            if (track == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(track);
            }
        }

        [Route("clip/{id}")]
        public ActionResult Audio(int? id)
        {
            var o = m.TrackAudioGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Audio, o.AudioContentType);
            }
        }

        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var track = m.TrackGetById(id.GetValueOrDefault());

            if (track == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = m.mapper.Map<TrackEditFormViewModel>(track);

                return View(form);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id, TrackEditViewModel newTrack)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = newTrack.Id });
            }

            if (id.GetValueOrDefault() != newTrack.Id)
            {
                return RedirectToAction("Index");
            }

            var editedTrack = m.TrackEdit(newTrack);

            if (editedTrack == null)
            {
                return RedirectToAction("Edit", new { id = newTrack.Id });
            }
            else
            {
                return RedirectToAction("Details", new { id = newTrack.Id });
            }
        }

        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.TrackGetById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(itemToDelete);
            }
        }

        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.TrackDelete(id.GetValueOrDefault());

            return RedirectToAction("index");
        }
    }
}
