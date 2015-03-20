


$(document).ready(function () {
    ClearActive();
    $("#liWhoViewedMe").addClass("liactive");

    $("#liWhoViewedMe").click(function () {
        // linarmal liactive
        ClearActive();
        $("#liWhoViewedMe").addClass("liactive");

    });

    $("#liWhoIViewed").click(function () {
        // linarmal liactive
        ClearActive();
        $("#liWhoIViewed").addClass("liactive");
    });

});


function ClearActive() {
    $("#liWhoViewedMe").removeClass("liactive");
    $("#liWhoIViewed").removeClass("liactive");
}