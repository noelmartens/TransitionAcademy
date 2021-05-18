let slideIndex: number = 1;
let albumIndex: number = 1;
showSlides(slideIndex);

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
    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    for (let i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }

    //  first time thru we will puke on this line
    if (slides.length == 0) {
       
    } else {
        slides[slideIndex - 1].style.display = "block";
    }
    dots[slideIndex - 1].className += " active";
}


