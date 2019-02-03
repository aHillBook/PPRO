$(document).ready(function () {
    /*******************   Admin sekce  *****************************/
    $("#adminIkona").hover(function () {
        $(".adminIkonaNapoveda").css('display', 'block');
    });

    $("#adminIkona").mouseleave(function () {
        $(".adminIkonaNapoveda").css('display', 'none');
    });
    $("#zpetIkona").hover(function () {
        $(".zpetIkonaNapoveda").css('display', 'block');
    });

    $("#zpetIkona").mouseleave(function () {
        $(".zpetIkonaNapoveda").css('display', 'none');
    });


    $('#adminIkona').click(function () {
        window.location.href = '../Jazyky/Index';
    });

    $('#zpetIkona').click(function () {
        window.location.href = 'Prehled';
    });
});