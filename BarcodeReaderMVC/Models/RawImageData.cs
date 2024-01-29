using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarcodeReaderMVC.Models
{
    public class RawImageData
    {
        public string Value { get; set; } // To hold the raw image data
        public int Width { get; set; } // Width of the image
        public int Height { get; set; } // Height of the image
    }
}
