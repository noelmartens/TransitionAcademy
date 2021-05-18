//import { Album } from "./album";
//import { Albums} from "./albums";
var slideIndex = 1;
var albumIndex = 1;
var titles = ["Brothers in Arms.jpg",
    "The Very Best of Fleetwood Mac",
    "Dark Side of the Moon"];
var bands = ["Dire Straits",
    "Fleetwood Mac",
    "Pink Floyd"];
var myUrl = ["https://upload.wikimedia.org/wikipedia/en/6/67/DS_Brothers_in_Arms.jpg",
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
    for (var i_1 = 0; i_1 < slides.length; i_1++) {
        slides[i_1].style.display = "none";
    }
    for (var i_2 = 0; i_2 < dots.length; i_2++) {
        dots[i_2].className = dots[i_2].className.replace(" active", "");
    }
    //  first time thru we will puke on this line
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}
function displayAlbum(n) {
    console.log(myUrl[n]);
    var apiString = myUrl[n];
    //"https://upload.wikimedia.org/wikipedia/en/2/2f" + "\"" + myJpg + "\"";
    //"https://upload.wikimedia.org/wikipedia/en/b/b6/" + myJpg;
    /* "https://en.wikipedia.org/w/api.php?format=xml&action=query&prop=imageinfo&iiprop=url|size&titles=File:" + myJpg +  "&origin=*" ;*/
    console.log(apiString);
    /*    "https://en.wikipedia.org/w/api.php?format=xml&action=query&prop=imageinfo&iiprop=url|size&titles=File:the-maccabees-given-to-the-wild.jpg&origin=*"; */
    //let response: any = await fetch(apiString);
    //console.log(response);
    //if (response.status >= 200 && response.status <= 299) {          // success
    var myPic = myUrl[n];
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
function btnClick() {
    alert("got to here");
    document.getElementById("imagetest").src =
        myUrl[1];
    // "https://upload.wikimedia.org/wikipedia/en/2/25/TheVeryBestofFleetwoodMac.jpg";
    //myUrl[1];
    //"https://upload.wikimedia.org/wikipedia/en/3/3b/Dark_Side_of_the_Moon.png";
}
