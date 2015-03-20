

$(document).ready(function () {

   
    $("#btninstagram").click(function () {
        OAuth.initialize('qb24rqcWu7g5eAUJ2IU6px8WkYE');
        OAuth.popup('instagram', function (error, success) {
            var _instaImagesUrl = _SitePath + "web/inner/instagrampop?userID=" + success.user.id + "&acckey=" + success.access_token;
             SetUrlIntelliWindow(_instaImagesUrl, "800", "630");
            });
     });


});


function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}


