$(document).ready(function () {
    $('.podrobnosti').click(function () {

        var a = $(this).closest('tr').next();
        a.toggleClass('zobrazeneDetaily');

        if ($(this).closest('.podrobnosti').hasClass('podrobnostiRovne')) {
            $(this).closest('.podrobnosti').removeClass('podrobnostiRovne');
            $(this).closest('.podrobnosti').toggleClass('podrobnostiDolu');
        }
        else {
            $(this).closest('.podrobnosti').removeClass('podrobnostiDolu');
            $(this).closest('.podrobnosti').toggleClass('podrobnostiRovne');
        }
    });

    $("#adminIkona").hover(function () {
        $(".adminIkonaNapoveda").css('display', 'block');
    });

    $("#adminIkona").mouseleave(function () {
        $(".adminIkonaNapoveda").css('display', 'none');
    });
});

var slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
    showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}

