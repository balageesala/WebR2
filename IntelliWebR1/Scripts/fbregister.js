
var _FBloginNameValid = false;
var _FBpasswordValid = false;
$(document).ready(function () {

    ValidateFBEmailAddress(window.parent._FbLoginDetails.email);

});


$(document).ready(function () {

  

    $("#lblEmail").text(window.parent._FbLoginDetails.email);
    $("#lblGender").text(window.parent._FbLoginDetails.gender);
    $("#lblDob").text(window.parent._FbLoginDetails.birthday);
   
   


    $("#txtFbLoginName").blur(function () {
        var _value = $(this).val();
        ValidateFBLoginName(_value);
    });

    $("#txtFbLoginName").keydown(function () {
        HideError("#divFbLoginNameError");
    });

    $("#txtFbPassword").blur(function () {
        var _value = $(this).val();

        if (_FBloginNameValid == false) {
            return;
        }
        ValidateFBPassword(_value);
    });

    $("#txtFbPassword").keydown(function () {
        HideError("#divFbPasswordError");
    });

    $(".imgclose").click(function () {
        window.parent.CloseIntelliWindow();
    });


    $("#btnFbLogin").click(function () {

        if (_FBloginNameValid == false) {
            //  ValidateLoginName($("#txtLoginName").val());
            ShowError("#divFbLoginError", REG_ERROR);
            return;
        }

        if (_FBpasswordValid == false) {
            // ValidatePassword($("#txtPassword").val());
            ShowError("#divFbLoginError", REG_ERROR);
            return;
        }

        var _gender = window.parent._FbLoginDetails.gender;

        var _regData = new Object();

        if (_gender == "male") {
            _regData.gr = 1;
        }
        else {
            _regData.gr = 2;
        }
        
        var _month = 10;
        var _day = 10;
        var _year = 1988;
        _regData.ln = $("#txtFbLoginName").val();
        _regData.em = window.parent._FbLoginDetails.email;
        _regData.pwd = $("#txtFbPassword").val();
        _regData.dm = _month;
        _regData.dd = _day;
        _regData.dy = _year;

        $.postDATA(_SitePath + "/post/register", _regData, function (_return) {
          //  alert(JSON.stringify(_return));
            if (_return.Result == true) {
                window.parent.location.href = _SitePath + _return.RedirectPath;
            }
            else {
                $(".registerButton").html("Register");
            }

        });

    });




});

function ValidateFBLoginName(_value) {
    if (_value.trim() == "") {
        ShowError("#divLoginNameError", REG_NOLOGIN);
        _FBloginNameValid = false;
        return;
    }

    var LoginNamePattern = new RegExp(/^[a-z][a-z0-9_.-]{4,19}$/);
    if (!LoginNamePattern.test(_value)) {
        _FBloginNameValid = false;
        ShowError("#divFbLoginNameError", REG_INVLOGIN);
        return;
    }

    var _apiPath = _SitePath + "API/CheckExistingLoginName";
    var _apiObject = new Object();
    _apiObject.LoginName = _value;

    $.postDATA(_apiPath, _apiObject, function (_return) {
        if (_return) {
            _FBloginNameValid = false;
             ShowError("#divFbLoginNameError", REG_EXISTINGLOGIN);
            return;
        }
        else {
            _FBloginNameValid = true;
            return;
        }
    });
}

function ValidateFBPassword(_value) {
    if (_value.trim() == "") {
        ShowError("#divFbPasswordError", REG_NOPASSWORD);
        _FBpasswordValid = false;
        return;
    }

    if (_value.length < 8) {
        ShowError("#divFbPasswordError", REG_SMALLPASSWORD);
        _FBpasswordValid = false;
        return;
    }

    _FBpasswordValid = true;
}


function ValidateFBEmailAddress(_value) {
      
    var _apiPath = _SitePath + "API/CheckExistingEmailAddress";
    var _apiObject = new Object();
    _apiObject.EmailAddress = _value;

    $.postDATA(_apiPath, _apiObject, function (_return) {
       // alert(JSON.stringify(_return));
        if (_return) {
            $("#divEmail").show();
            $(".divfbBox").hide();
        }
        else {
            $("#divEmail").hide();
            $(".divfbBox").show();
        }
    });
}




function ShowError(fieldID, errorMessage) {
    $(fieldID).html(errorMessage);

}

function HideError(fieldID) {
    $(fieldID).html("");
}
