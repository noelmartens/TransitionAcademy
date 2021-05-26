using System;
using System.Collections.Generic;
using System.Text;

namespace Music_mvc
{
    class Music_model
    {

        List<Music> myCollection = new List<Music>();


        public void AddAlbums(string pBandName, string pAlbumName)
        {
            Albums albums = new Albums();
            albums.BandName  = pBandName;
            albums.AlbumName = pAlbumName;
            myCollection.Add(albums);
        }


        public void AddSongs(string pBandName, string pSongTitle)
        {
            Songs songs = new Songs();
            songs.BandName = pBandName;
            songs.SongTitle = pSongTitle;
            myCollection.Add(songs);
        }

 
        public List<Music> GetCollectionList()
        {
            return myCollection;
        }

    }
}
