using System;
using System.Collections.Generic;
using System.Text;

namespace MusicCollection
{
    class MyMusic 
    {
        public string BandName { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }

 
        public MyMusic() 
        {
            BandName = "";
            Album = "";
            Genre = "";
        }

        public MyMusic(string pbandName, string palbum, string pgenre) 
        {
            BandName = pbandName;
            Album = palbum;
            Genre = pgenre;
        }
    }


}
