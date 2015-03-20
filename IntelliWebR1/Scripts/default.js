$(document).ready(function () {
    $("#divRegister").load("inner/register", function () {

    });

    var isSafari = !!navigator.userAgent.match(/Version\/[\d\.]+.*Safari/)
    if (isSafari) {
        fixSafary();
        $(document).on('webkitfullscreenchange mozfullscreenchange fullscreenchange MSFullscreenChange', fixSafary);
    }



});

function fixSafary() {
    fixMobileSafariViewport(".container");
    fixMobileSafariViewport(".containerBox");
    fixMobileSafariViewport(".blackBox");
}

function fixMobileSafariViewport(_className) {
    $element = $(_className);
    $element.css('height', window.innerHeight * 1);
}