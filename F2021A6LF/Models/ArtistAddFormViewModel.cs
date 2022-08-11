﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F2021A6LF.Models
{
    public class ArtistAddFormViewModel : ArtistAddViewModel
    {
        [Display(Name="Artist's primary genre")]
        public SelectList GenreList { get; set; }

    }
}