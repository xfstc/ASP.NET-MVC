using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class TrackBaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Track Name")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Composer names (comma-separated)")]
        [Required, StringLength(200)]
        public string Composers { get; set; }

        [Display(Name = "Sample clip")]
        public string AudioUrl
        {
            get
            {
                return $"clip/{Id}";
            }
        }
    }
}