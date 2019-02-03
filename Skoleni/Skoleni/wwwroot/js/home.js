$(document).ready(function () {
    /*******************   Admin sekce  *****************************/
    $("#adminIkona").hover(function () {
        $(".adminIkonaNapoveda").css('display', 'block');
    });

    $("#adminIkona").mouseleave(function () {
        $(".adminIkonaNapoveda").css('display', 'none');
    });



    $('#adminIkona').click(function () {
        window.location.href = '../Jazyky/Index';
    });
});