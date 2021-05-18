"use strict";

//import { Album } from "./album";
//import { Albums} from "./albums";
var __awaiter = void 0 && (void 0).__awaiter || function (thisArg, _arguments, P, generator) {
  function adopt(value) {
    return value instanceof P ? value : new P(function (resolve) {
      resolve(value);
    });
  }

  return new (P || (P = Promise))(function (resolve, reject) {
    function fulfilled(value) {
      try {
        step(generator.next(value));
      } catch (e) {
        reject(e);
      }
    }

    function rejected(value) {
      try {
        step(generator["throw"](value));
      } catch (e) {
        reject(e);
      }
    }

    function step(result) {
      result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected);
    }

    step((generator = generator.apply(thisArg, _arguments || [])).next());
  });
};

var slideIndex = 1;
var albumIndex = 1;
var titles = ["Brothers in Arms.jpg", "The Very Best of Fleetwood Mac", "Dark Side of the Moon"];
var bands = ["Dire Straits", "Fleetwood Mac", "Pink Floyd"];
var myUrl = ["https://upload.wikimedia.org/wikipedia/en/6/67/origin=*/DS_Brothers_in_Arms.jpg", "https://upload.wikimedia.org/wikipedia/en/2/25/TheVeryBestofFleetwoodMac.jpg", "https://upload.wikimedia.org/wikipedia/en/3/3b/Dark_Side_of_the_Moon.png"];
/*const slides : any [] =
["assets/images/thumb1.jpg",
 "assets/images/thumb2.jpg",
 "assets/images/thumb3.jpg"]
*/

displayAlbum(0);
showSlides(slideIndex);
/*
interface Albums {
  title: string;
  band: string;
  url: string;
}*/

function plusSlides(n) {
  showSlides(slideIndex += n);
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("dot");

  if (n > slides.length) {
    slideIndex = 1;
  }

  ;

  for (var _i = 0; _i < slides.length; _i++) {
    slides[_i].style.display = "none";
  }

  for (var _i2 = 0; _i2 < dots.length; _i2++) {
    dots[_i2].className = dots[_i2].className.replace(" active", "");
  } //  first time thru we will puke on this line


  slides[slideIndex - 1].style.display = "block";
  dots[slideIndex - 1].className += " active";
}

function displayAlbum(n) {
  return __awaiter(this, void 0, void 0,
  /*#__PURE__*/
  regeneratorRuntime.mark(function _callee() {
    var apiString, response, myPic, x, jsonData;
    return regeneratorRuntime.wrap(function _callee$(_context) {
      while (1) {
        switch (_context.prev = _context.next) {
          case 0:
            console.log(myUrl[n]);
            apiString = myUrl[n]; //"https://upload.wikimedia.org/wikipedia/en/2/2f" + "\"" + myJpg + "\"";
            //"https://upload.wikimedia.org/wikipedia/en/b/b6/" + myJpg;

            /* "https://en.wikipedia.org/w/api.php?format=xml&action=query&prop=imageinfo&iiprop=url|size&titles=File:" + myJpg +  "&origin=*" ;*/

            console.log(apiString);
            /*    "https://en.wikipedia.org/w/api.php?format=xml&action=query&prop=imageinfo&iiprop=url|size&titles=File:the-maccabees-given-to-the-wild.jpg&origin=*"; */

            _context.next = 5;
            return fetch(apiString);

          case 5:
            response = _context.sent;
            console.log(response);

            if (!(response.status >= 200 && response.status <= 299)) {
              _context.next = 13;
              break;
            }

            // success
            myPic = myUrl[n];
            x = "<img style=\"-webkit-user-select: none;" + "margin: auto;background-color: " + "hsl(0, 0%, 90%);" + "transition: background-color 300ms;\" " + "src=\"" + myUrl[n] + "\">";
            console.log(titles[n] + " " + bands[n] + " " + myPic, x);
            _context.next = 17;
            break;

          case 13:
            _context.next = 15;
            return response.json();

          case 15:
            jsonData = _context.sent;
            console.log(jsonData);

          case 17:
          case "end":
            return _context.stop();
        }
      }
    }, _callee);
  }));
}