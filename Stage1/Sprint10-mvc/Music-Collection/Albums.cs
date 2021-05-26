

namespace Music-mvc
{
    class Albums : Music
    {

        public string Genre { get; set; }

         public Albums() : base ()
        {
            Genre = "";
        }

        public Albums(string pbandName, string palbum, string pgenre)
        {
            Genre = pgenre;
        }

        public override string ToString()
        {
            return "Band/album/genre......:" + 
                BandName + "        " + Album + "        " + Genre;
        }
    }
}
