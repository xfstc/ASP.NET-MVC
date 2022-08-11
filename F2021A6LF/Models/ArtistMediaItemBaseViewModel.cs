using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class ArtistMediaItemBaseViewModel
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        [Required, StringLength(100)]
        public string StringId { get; set; }

        [StringLength(200)]
        public string ContentType { get; set; }

        [Required, StringLength(100)]
        public string Caption { get; set; }
    }
}