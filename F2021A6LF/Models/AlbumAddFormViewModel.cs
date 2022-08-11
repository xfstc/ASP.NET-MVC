﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2021A6LF.Models
{
    public class AlbumAddFormViewModel : AlbumAddViewModel
    {

        public string ArtistName { get; set; }

        [Display(Name="Album's primary genre")]
        public SelectList GenreList { get; set; }
        
    }
}