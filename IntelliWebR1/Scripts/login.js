
$(document).ready(function () {

    $('#txtLoginName').focus();

    $("#btnLogin").click(function () {
        var _LoginName = $("#txtLoginName").val();
        var _Password = $("#txtPassword").val();
        var _Result = true;
        if (_LoginName == "" || _Password == "") {
            ShowError("#divLoginError", LOGIN_UNAMEPWD);
            _Result = false;
        }
        if (_Result) {
            HideError("#divLoginError");
            var _LoginObj = new Object();
            _LoginObj.LoginName = _LoginName;
            _LoginObj.Password = _Password;
            _LoginObj.IsRemember = $("#chkRemember").is(":checked");
            APICALLLOGIN = _SitePath + "Post/login";
            $("#btnLogin").val("Please wait..");

            $.postDATA(APICALLLOGIN, _LoginObj, function (_data) {
                if (_data.Result) {
                    PostLoginDetails();
                    window.parent.location.href = _SitePath + _data.RedirectPath;
                }
                else {
                    ShowError("#divLoginError", LOGIN_FAIL);
                    $("#btnLogin").val("Login");
                }
            });
        }
        return _Result;
    });


    $("#txtPassword").keydown(function (e) {
        if (e.keyCode == 13) {
            $("#btnLogin").trigger("click");
        }
        if (e.keyCode == 27) {
            $(".imgclose").trigger("click");
        }
    });


    $("#txtLoginName").keydown(function (e) {
        if (e.keyCode == 13) {
            $("#btnLogin").trigger("click");
        }
        if (e.keyCode == 27) {
            $(".imgclose").trigger("click");
        }
    });

    function ShowError(fieldID, errorMessage) {
        $(fieldID).html(errorMessage);
        $(fieldID).hide().fadeIn(200);
    }
    function HideError(fieldID) {
        $(fieldID).fadeOut(200);
    }

    $(".imgclose").click(function () {
        window.parent.CloseIntelliWindow();
    });

    $(".lnkForgotPassword").click(function () {
        window.parent.SetIntelliWindow("#lnkforgotpwd");

    });

});

var _UserLogin = new Object();
window.onload = function () {

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(getGeo);
    }
    else {
        noGeo();
    }


}

function PostLoginDetails() {
    var API_SETLOGINDETAILS = _SitePath + "API/LoginDetails";
    $.postDATA(API_SETLOGINDETAILS, _UserLogin, function (_data) {
        //  alert(_data);
    });
}

function noGeo() {
    _UserLogin.UaProfile = navigator.userAgent; // UaProfile
    _UserLogin.Referrer = document.referrer;
    _UserLogin.OS = getOsName();
}

function getGeo(position) {
    _UserLogin.Latitude = position.coords.latitude; // Latitude
    _UserLogin.Longitude = position.coords.longitude; // Longitude
    _UserLogin.UaProfile = navigator.userAgent; // UaProfile
    _UserLogin.Referrer = document.referrer;
    _UserLogin.OS = getOsName();
}

function getOsName() {
    var OSName = "Unknown";
    if (window.navigator.userAgent.indexOf("Windows NT 6.3") != -1) OSName = "Windows 8";
    if (window.navigator.userAgent.indexOf("Windows NT 6.2") != -1) OSName = "Windows 8";
    if (window.navigator.userAgent.indexOf("Windows NT 6.1") != -1) OSName = "Windows 7";
    if (window.navigator.userAgent.indexOf("Windows NT 6.0") != -1) OSName = "Windows Vista";
    if (window.navigator.userAgent.indexOf("Windows NT 5.1") != -1) OSName = "Windows XP";
    if (window.navigator.userAgent.indexOf("Windows NT 5.0") != -1) OSName = "Windows 2000";
    if (window.navigator.userAgent.indexOf("Mac") != -1) OSName = "Mac/iOS";
    if (window.navigator.userAgent.indexOf("X11") != -1) OSName = "UNIX";
    if (window.navigator.userAgent.indexOf("Linux") != -1) OSName = "Linux";
    return OSName;
}

