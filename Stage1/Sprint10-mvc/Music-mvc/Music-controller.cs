using System;
using System.Collections.Generic;
using System.Text;

namespace Music_mvc
{
    class Music_controller
    {
        string bandName;
        string albumName;
        string songTitle;

        string op;

        Boolean enterMore = true;

        public Music_view v = new Music_view();
        public Music_model m = new Music_model();


        public Music_controller()
        {
            op = v.SendWelcome().ToUpper();
            if (op == "N")   //  quit
            {
                enterMore = false;
            }

            while (enterMore)
            {
                op = v.SendMenu();
                switch (op)
                {
                    case "1":    //  add an album
                        bandName = v.GetBandName();
                        if (String.IsNullOrEmpty(bandName))
                        {
                            v.ShowError("Band name is required............try again");
                            break;
                        }
                        albumName = v.GetAlbumName();
                        if (String.IsNullOrEmpty(albumName))
                        {
                            v.ShowError("Album name is required...........try again");
                            break;
                        }

                        // data is clean, create the instructor
                        m.AddAlbums(bandName, albumName);
                        break;

                    case "2":  //  add a song
                        bandName = v.GetBandName();
                        if (String.IsNullOrEmpty(bandName))
                        {
                            v.ShowError("Band name is required............try again");
                            break;
                        }

                        songTitle = v.GetSongTitle();
                        if (String.IsNullOrEmpty(songTitle))
                        {
                            v.ShowError("Song Title is required..........try again");
                            break;
                        }

                        // data is clean, create the student, add person to person class list
                        m.AddSongs(bandName, songTitle);
                        break;

                    case "3":    //  display roster
                        v.PrintCollection(m.GetCollectionList());
                        break;


                    case "4":    //  quit
                    case "q":    //  quit
                        enterMore = false;
                        break;

                }
            }
        }
    }
}
