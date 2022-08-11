using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class ArtistWithDetailViewModel : ArtistBaseViewModel
    {
        public ArtistWithDetailViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
        }
        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }

        public int GenreId { get; set; }

        [Display(Name="Number of albums")]
        public int AlbumsCount { get; set; }
    }
}