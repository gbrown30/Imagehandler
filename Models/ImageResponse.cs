using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebImage.Models
{
    public class ImageResponse
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Error { get; set; }

        public ImageResponse(string n, string p, long s, string e)
        {
            Name = n;
            Path = p;
            Size = s;
            Error = e;
        }
    }
}