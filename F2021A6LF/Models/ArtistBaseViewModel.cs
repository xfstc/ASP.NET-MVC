using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class ArtistBaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Artist photo")]
        [StringLength(500)]
        public string UrlArtist { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        [Display(Name = "Birth date, or start date")]
        [DataType(DataType.Date)]
        public DateTime BirthOrStartDate { get; set; }

        [Display(Name = "Artist's primary genre")]
        [Required, StringLength(100)]
        public string Genre { get; set; }

        [StringLength(100)]
        [Display(Name = "Executive who looks after this artist")]
        public string Executive { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Artist career")]
        public string Career { get; set; }
    }
}