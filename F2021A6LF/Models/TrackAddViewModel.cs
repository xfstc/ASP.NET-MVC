using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class TrackAddViewModel
    {
        
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(200)]
        public string Composers { get; set; }

        [Required, StringLength(100)]
        public string Genre { get; set; }

        public int AlbumId { get; set; }

        [Required]
        public HttpPostedFileBase AudioUpload { get; set; }

    }
}