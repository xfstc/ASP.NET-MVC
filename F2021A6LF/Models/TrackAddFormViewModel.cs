using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2021A6LF.Models
{
    public class TrackAddFormViewModel
    {
        [Display(Name = "Track Name")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Composer names (comma-separated)")]
        [Required, StringLength(200)]
        public string Composers { get; set; }

        public string AlbumName { get; set; }

        public int AlbumId { get; set; }

        [Display(Name = "Track genre")]
        public SelectList GenreList { get; set; }

        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; } 
    }
}