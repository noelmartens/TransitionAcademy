//import { Album } from "./album";
//import { Albums} from "./albums";

let slideIndex: number = 1;
let albumIndex: number = 1;


const titles: string[] =
  ["Brothers in Arms.jpg",
    "The Very Best of Fleetwood Mac",
    "Dark Side of the Moon"];

const bands: string[] =
  ["Dire Straits",
    "Fleetwood Mac",
    "Pink Floyd"];

const myUrl: string[] =
  ["https://upload.wikimedia.org/wikipedia/en/6/67/DS_Brothers_in_Arms.jpg",
    "https://upload.wikimedia.org/wikipedia/en/2/25/TheVeryBestofFleetwoodMac.jpg",
    "https://upload.wikimedia.org/wikipedia/en/3/3b/Dark_Side_of_the_Moon.png"];

/*const slides : any [] =
["assets/images/thumb1.jpg",
 "assets/images/thumb2.jpg",
 "assets/images/thumb3.jpg"]
*/

displayAlbum(0);
//showSlides(slideIndex);
/*
interface Albums {
  title: string;
  band: string;
  url: string;
}*/

function plusSlides(n: number) {
  showSlides(slideIndex += n);
}

function currentSlide(n: number) {
  showSlides(slideIndex = n);
}

function showSlides(n: number) {
  let i: number;
  let slides: any =
    document.getElementsByClassName("mySlides");
  let dots = document.getElementsByClassName("dot");
  if (n > slides.length) { slideIndex = 1 };
  for (let i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (let i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  //  first time thru we will puke on this line
  slides[slideIndex - 1].style.display = "block";
  dots[slideIndex - 1].className += " active";
}


function displayAlbum(n: number) {
  console.log(myUrl[n]);
  let apiString: string = myUrl[n];

  //"https://upload.wikimedia.org/wikipedia/en/2/2f" + "\"" + myJpg + "\"";
  //"https://upload.wikimedia.org/wikipedia/en/b/b6/" + myJpg;


  /* "https://en.wikipedia.org/w/api.php?format=xml&action=query&prop=imageinfo&iiprop=url|size&titles=File:" + myJpg +  "&origin=*" ;*/
  console.log(apiString);

  /*    "https://en.wikipedia.org/w/api.php?format=xml&action=query&prop=imageinfo&iiprop=url|size&titles=File:the-maccabees-given-to-the-wild.jpg&origin=*"; */

  //let response: any = await fetch(apiString);
  //console.log(response);

  //if (response.status >= 200 && response.status <= 299) {          // success
  let myPic: any = myUrl[n];
  console.log(myPic);

  document.getElementById("imagetest").src =
  "https://upload.wikimedia.org/wikipedia/en/3/3b/Dark_Side_of_the_Moon.png";
  //myPic;

  /*   let x: any =
       "<img style=\"-webkit-user-select: none;" +
       "margin: auto;background-color: " +
       "hsl(0, 0%, 90%);" +
       "transition: background-color 300ms;\" " +
       "src=\"" + myUrl[n] + "\">";
  /*   console.log(
       titles[n] + " " +
       bands[n] + " " +
       myPic,
       x
 
     );
   } else {
     var jsonData = await response.json();
     console.log(jsonData);
   }
   /*
     for (let i = 0; i < titles.length; i++) {
       console.log(
         titles[i] + " " +
         bands[i] + " " +
         response.url[i]
       );
     }*/
}

function btnClick () {
  alert("got to here");
  document.getElementById("imagetest").src =

   myUrl[1];
 // "https://upload.wikimedia.org/wikipedia/en/2/25/TheVeryBestofFleetwoodMac.jpg";

  //myUrl[1];
//"https://upload.wikimedia.org/wikipedia/en/3/3b/Dark_Side_of_the_Moon.png";
}