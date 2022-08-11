using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class AlbumWithDetailViewModel : AlbumBaseViewModel
    {
        public AlbumWithDetailViewModel()
        {
            Tracks = new List<TrackBaseViewModel>();
            Artists = new List<ArtistBaseViewModel>();
        }

        public IEnumerable<TrackBaseViewModel> Tracks { get; set; }

        public IEnumerable<ArtistBaseViewModel> Artists { get; set; }

    }
}