

$(document).ready(function () {
    ClearActive();
    $("#liWhoSavedMe").addClass("liactive");

    $("#liWhoSavedMe").click(function () {
        // linarmal liactive
        ClearActive();
        $("#liWhoSavedMe").addClass("liactive");

    });

    $("#liWhoISaved").click(function () {
        // linarmal liactive
        ClearActive();
        $("#liWhoISaved").addClass("liactive");
    });

});


function ClearActive() {
    $("#liWhoSavedMe").removeClass("liactive");
    $("#liWhoISaved").removeClass("liactive");
}