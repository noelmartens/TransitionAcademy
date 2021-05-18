var slideIndex = 1;
var albumIndex = 1;
showSlides(slideIndex);
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
    for (var i_1 = 0; i_1 < slides.length; i_1++) {
        slides[i_1].style.display = "none";
    }
    for (var i_2 = 0; i_2 < dots.length; i_2++) {
        dots[i_2].className = dots[i_2].className.replace(" active", "");
    }
    //  first time thru we will puke on this line
    if (slides.length == 0) {
    }
    else {
        slides[slideIndex - 1].style.display = "block";
    }
    dots[slideIndex - 1].className += " active";
}
