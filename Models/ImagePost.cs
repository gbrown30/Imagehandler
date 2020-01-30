using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebImage.Models
{
    public class ImagePost
    {
        public string Upload_file { get; set; }
        public string Upload_name { get; set; }
        public string Upload_type { get; set; }
        public string Upload_operation { get; set; }

        public string Upload_text { get; set; }
        public string Media_format { get; set; }

        public ImageResolution Res { get; set; }
        
        public string Userid { get; set; }
    }
}