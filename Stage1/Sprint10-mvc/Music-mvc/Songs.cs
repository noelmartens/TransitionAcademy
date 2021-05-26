
namespace Music_mvc
{
    class Songs : Music
    {
        public string SongTitle { get; set; }

        public Songs() : base()
        {
            SongTitle = "";
        }

        public Songs(string pSongTitle)
        {
            SongTitle = pSongTitle;
        }


        public override string ToString()
        {
            return "Song..........." + BandName + " " + SongTitle;
        }
    }
}
