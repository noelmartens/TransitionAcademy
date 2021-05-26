
namespace Music_mvc
{
    class Music
    {
        public string BandName { get; set; }
 

        public Music()
        {
            BandName = "";

        }

        public Music(string pBandName)
        {
            BandName = pBandName;
        }


        public override string ToString()
        {
            return "Music..........." + BandName;
        }
    }
}
