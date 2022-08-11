using F2021A6LF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2021A6LF.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        private Manager m = new Manager();

        // GET: Artists
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            var artist = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(artist);
            }
        }

        public ActionResult DetailsWithMediaInfo(int? id)
        {
            var o = m.ArtistGetByIdWithMediaInfo(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }



        // GET: Artists/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddFormViewModel();

            form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

            return View(form);
        }

        // POST: Artists/Create
        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAddViewModel newArtist)
        {
            //newArtist.Executive = User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return View(newArtist);
            }


            var addedArtist = m.ArtistAdd(newArtist);

            if (addedArtist == null)
            {
                return View(newArtist);
            }
            else
            {
                return RedirectToAction("details", new { id = addedArtist.Id });
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var a = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new AlbumAddFormViewModel();
                form.ArtistName = a.Name;
                form.ArtistId = a.Id;
                form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                return View(form);
            }
        }

        [Route("artist/{id}/addalbum")]
        [Authorize(Roles = "Coordinator")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddViewModel newAlbum)
        {
            if (!ModelState.IsValid)
            {
                return View(newAlbum);
            }

            var addedAlbum = m.AlbumAdd(newAlbum);

            if (addedAlbum == null)
            {
                return View(newAlbum);
            }
            else
            {
                return RedirectToAction("details", "albums", new { id = addedAlbum.Id });
            }


        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            var a = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new ArtistMediaItemAddFormViewModel();
                form.ArtistId = a.Id;
                form.ArtistName = a.Name;

                return View(form);
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addmediaitem")]
        [HttpPost]
        public ActionResult AddMediaItem(int? id, ArtistMediaItemAddViewModel newItem)
        {
            if (!ModelState.IsValid && id.GetValueOrDefault() == newItem.ArtistId)
            {
                return View(newItem);
            }

            var addedItem = m.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Detailswithmediainfo", new { id = addedItem.Id });
            }
        }
    }
}
