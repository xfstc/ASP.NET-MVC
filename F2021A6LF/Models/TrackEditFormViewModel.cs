using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class TrackEditFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Clip")]
        public string AudioUpload { get; set; }
    }
}