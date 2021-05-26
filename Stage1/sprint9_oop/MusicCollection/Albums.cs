

namespace MusicCollection
{
    class Albums : MyMusic
    {

        public new string BandName { get; set; }
        public new string Album { get; set; }
        public new string Genre { get; set; }

         public Albums() : base ()
        {
        }

        public Albums(string pbandName, string palbum, string pgenre)
        {
            BandName = pbandName;
            Album = palbum;
            Genre = pgenre;
        }

        public override string ToString()
        {
            return "Band/album/genre......:" + 
                BandName + "        " + Album + "        " + Genre;
        }
    }
}
