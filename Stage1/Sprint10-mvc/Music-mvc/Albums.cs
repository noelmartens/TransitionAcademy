
namespace Music_mvc
{
    class Albums : Music
    {
        public string AlbumName { get; set; }

        public Albums() : base()
        {
            AlbumName = "";
        }

        public Albums(string pAlbumName)
        {
            AlbumName = pAlbumName;
        }


        public override string ToString()
        {
            return "Albums........." + BandName + " " + AlbumName;
        }
    }
}
