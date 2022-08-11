using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F2021A6LF.Models
{
    public class TrackAudioViewModel
    {
        public int Id { get; set; }

        public byte[] Audio { get; set; }

        public string AudioContentType { get; set; }
    }
}