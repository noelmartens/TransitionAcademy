using System;
using System.Collections.Generic;
using System.Text;

namespace Music-mvc
{
    class Music 
    {
        public string BandName { get; set; }
        public string Album { get; set; }

        public Music() 
        {
            BandName = "";
            Album = "";
        }

        public Music(string pbandName, string palbum, string pgenre) 
        {
            BandName = pbandName;
            Album = palbum;
        }
    }
}
