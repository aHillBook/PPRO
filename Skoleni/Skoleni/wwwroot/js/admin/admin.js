$(document).ready(function () {
    /*******************   Admin sekce  *****************************/

    $("#novyIkona").hover(function () {
        $(".novyIkonaNapoveda").css('display', 'block');
    });

    $("#novyIkona").mouseleave(function () {
        $(".novyIkonaNapoveda").css('display', 'none');
    });



    $("#kmuIkona").hover(function () {
        $(".kmuIkonaNapoveda").css('display', 'block');
    });

    $("#kmuIkona").mouseleave(function () {
        $(".kmuIkonaNapoveda").css('display', 'none');
    });

    $("#nahratIkona").hover(function () {
        $(".nahratIkonaNapoveda").css('display', 'block');
    });

    $("#nahratIkona").mouseleave(function () {
        $(".nahratIkonaNapoveda").css('display', 'none');
    });

    $("#stahnoutIkona").hover(function () {
        $(".stahnoutIkonaNapoveda").css('display', 'block');
    });

    $("#stahnoutIkona").mouseleave(function () {
        $(".stahnoutIkonaNapoveda").css('display', 'none');
    });

    //*********************************************
    $('#novyIkona').click(function () {
        window.location.href = '../Kmu/Index';
    });



    $('#kmuIkona').click(function () {
        window.location.href = '../Kmu/Index';
    });

    $('#nahratIkona').click(function () {
        window.location.href = 'q2KstUpload';
    });

    $('#stahnoutIkona').click(function () {
        window.location.href = 'q2KstDownload';
    });



});