using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class AlbumBaseViewModel
    {
        public AlbumBaseViewModel()
        {
            ReleaseDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Album name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [StringLength(500)]
        [Display(Name = "Album cover art")]
        public string UrlAlbum { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }

        [StringLength(100)]
        [Display(Name = "Coordinator who looks after the album")]
        public string Coordinator { get; set; }

        public int GenreId { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Album background")]
        public string Background { get; set; }

    }
}