using System;
using System.Collections.Generic;
using System.Text;

namespace Music-mvc
{
    class Music_controller
{
    string bandName;
    string album;
    string genre;
    Boolean enterMore = true;
    string op;

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
                case "1":
                    break;


                case "2":
                    break;


                case "3":
                    break;


            }
        }
    }
}

