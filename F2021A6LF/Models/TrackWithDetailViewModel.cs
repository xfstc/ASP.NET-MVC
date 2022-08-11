using F2021A6LF.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        public TrackWithDetailViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
        }

        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }

    }
}