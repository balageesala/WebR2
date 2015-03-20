var _timeStart = new Date().getTime();
var _timeEnd;
var _Analytics = new Object();


$(window).load(function () {
    _timeEnd = new Date().getTime();
    var _timeTookToLoad = _timeEnd - _timeStart;
    _Analytics.LoadTime = _timeTookToLoad; // Load time
    
    if (navigator.geolocation) {
         navigator.geolocation.getCurrentPosition(getGeo);
       }
    else {
          noGeo();
        }

});

function noGeo() {
    _Analytics.UserAgent = navigator.userAgent; // UaProfile
    _Analytics.ScreenHeight = screen.height; // Screen height
    _Analytics.ScreenWidth = screen.width; // Screen height
}

function getGeo(position) {
    _Analytics.Latitude = position.coords.latitude; // Latitude
    _Analytics.Longitude = position.coords.longitude; // Longitude

    _Analytics.UserAgent = navigator.userAgent; // UaProfile
    _Analytics.ScreenHeight = screen.height; // Screen height
    _Analytics.ScreenWidth = screen.width; // Screen height
}

$(document).ready(function () {
   
    $(window).bind("beforeunload", function () {
        var _pageUnload = new Date().getTime();
        _Analytics.SpentTime = Math.round(_pageUnload - _timeEnd);
        _Analytics.Referer = document.referrer;
        _Analytics.PageName = window.location.pathname.split("/")[window.location.pathname.split("/").length-1];

        var _APIAnalytics = _SitePath + "api/grab";

        $.ajax({
            url: _APIAnalytics,
            async: false,
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            type: "POST",
            dataType: "json",
            data: _Analytics,
            timeout:100,
            success: function () {
                return true;
            },
            error: function () {
                return true;
            }
        });
    });
});
