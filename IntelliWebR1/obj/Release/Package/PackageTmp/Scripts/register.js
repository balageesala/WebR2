var _loginNameValid = false;
var _emailValid = false;
var _retypeemailValid = false;
var _passwordValid = false;
var _rpasswordValid = false;

function ValidateLoginName(_value) {
    if (_value.trim() == "") {
        ShowError("#divLoginNameError", REG_NOLOGIN);
        _loginNameValid = false;
        return;
    }

    var LoginNamePattern = new RegExp(/^[a-zA-Z0-9](_(?!(\.|_))|\.(?!(_|\.))|[a-zA-Z0-9]){6,18}[a-zA-Z0-9]$/);
    if (!LoginNamePattern.test(_value)) {
        _loginNameValid = false;
        ShowError("#divLoginNameError", REG_INVLOGIN);
        return;
    }

    var _apiPath = _SitePath + "API/CheckExistingLoginName";
    var _apiObject = new Object();
    _apiObject.LoginName = _value;

    $.postDATA(_apiPath, _apiObject, function (_return) {
        if (_return) {
            _loginNameValid = false;
            ShowError("#divLoginNameError", REG_EXISTINGLOGIN);
            return;
        }
        else {
            _loginNameValid = true;
            return;
        }
    });
}

function ValidateEmailAddress(_value) {
    if (_value.trim() == "") {
        ShowError("#divEmailAddressError", REG_NOEMAIL);
        _emailValid = false;
        return;
    }

    var _EmailAddressPattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    if (!_EmailAddressPattern.test(_value)) {
        _emailValid = false;
        ShowError("#divEmailAddressError", REG_INVEMAIL);
        return;
    }

    var _apiPath = _SitePath + "API/CheckExistingEmailAddress";
    var _apiObject = new Object();
    _apiObject.EmailAddress = _value;

    $.postDATA(_apiPath, _apiObject, function (_return) {
        if (_return) {
            _emailValid = false;
            ShowError("#divEmailAddressError", REG_EXISTINGEMAIL);
            return;
        }
        else {
            _emailValid = true;
            return;
        }
    });
}

function ValidateREmailAddress(_value) {
    if (_value.trim() == "") {
        ShowError("#divREmailAddressError", REG_NOREMAIL);
        _retypeemailValid = false;
        return;
    }


    if (_value.trim() != $("#txtEmailAddress").val()) {
        ShowError("#divREmailAddressError", REG_REMAILNOTMATCHING);
        _retypeemailValid = false;
        return;
    }

    _retypeemailValid = true;
}

function ValidatePassword(_value) {
    if (_value.trim() == "") {
        ShowError("#divPasswordError", REG_NOPASSWORD);
        _passwordValid = false;
        return;
    }

    if (_value.length < 8) {
        ShowError("#divPasswordError", REG_SMALLPASSWORD);
        _passwordValid = false;
        return;
    }

    _passwordValid = true;
}

function ValidateRPassword(_value) {
    if (_value.trim() != $("#txtPassword").val()) {
        ShowError("#divRPasswordError", REG_PASSWORDNOMATCH);
        _rpasswordValid = false;
        return;
    }

    _rpasswordValid = true;
}

$(document).ready(function () {
  
    
    $("#lnkLogin").click(function (e) {

        SetIntelliWindow("#lnkLogin", e);
    });

    $("#lnkforgotpwd").click(function (e) {
        SetIntelliWindow("#lnkforgotpwd", e);
    });
    

    $("#txtLoginName").blur(function () {
        var _value = $(this).val();
        ValidateLoginName(_value);
    });

    $("#txtLoginName").keydown(function () {
        HideError("#divLoginNameError");
    });

    $("#txtEmailAddress").blur(function () {

        if (_loginNameValid == false) {
            return;
        }
        var _value = $(this).val();

        ValidateEmailAddress(_value);

    });

    $("#txtEmailAddress").keydown(function () {
        HideError("#divEmailAddressError");
    });

    $("#txtREmailAddress").blur(function () {
        var _value = $(this).val();

        if (_loginNameValid == false || _emailValid == false) {
            return;
        }

        ValidateREmailAddress(_value);

    });

    $("#txtREmailAddress").keydown(function () {
        HideError("#divREmailAddressError");
    });

    $("#txtPassword").blur(function () {
        var _value = $(this).val();

        if (_loginNameValid == false || _emailValid == false || _retypeemailValid == false) {
            return;
        }
        ValidatePassword(_value);
    });

    $("#txtPassword").keydown(function () {
        HideError("#divPasswordError");
    });

    $("#txtRPassword").blur(function () {
        var _value = $(this).val();

        if (_loginNameValid == false || _emailValid == false || _retypeemailValid == false || _passwordValid == false) {
            return;
        }
        ValidateRPassword(_value);
    });

    $("#txtRPassword").keydown(function () {
        HideError("#divRPasswordError");
    });

    $(".registerButton").click(function () {

        if (_loginNameValid == false) {
          //  ValidateLoginName($("#txtLoginName").val());
            ShowError("#divRegisterError", REG_ERROR);
            return;
        }

        if (_emailValid == false) {
          //  ValidateEmailAddress($("#txtEmailAddress").val());
            ShowError("#divRegisterError", REG_ERROR);
            return;
        }

        if (_retypeemailValid == false) {
          //  ValidateREmailAddress($("#txtREmailAddress").val());
            ShowError("#divRegisterError", REG_ERROR);
            return;
        }

        if (_passwordValid == false) {
           // ValidatePassword($("#txtPassword").val());
            ShowError("#divRegisterError", REG_ERROR);
            return;
        }

        if (_rpasswordValid == false) {
            //ValidateRPassword($("#txtRPassword").val());
            ShowError("#divRegisterError", REG_ERROR);
            return;
        }

        var _userName = $("#txtLoginName").val();
        var _Pwd = $("#txtRPassword").val();

        if (_userName.trim() == _Pwd.trim()) {
            ShowError("#divRegisterError", "Login name and password should not be same.");
            return;
        }

        // Check date of birth
        var _month = $("#cboMonth").val();
        var _day = $("#cboDate").val();
        var _year = $("#cboYear").val();

        if (_month == "00" || _day == "00" || _year == "00") {
            ShowError("#divDateOfBirthError", REG_NODOB);
            return;
        }

        // Check the accept checkbox
        if ($("#chkAcceptTerms").is(":checked") == false) {
            ShowError("#divAcceptError", REG_ACCEPTTERMS);
            return;
        }

        $(".registerButton").html("Please wait...");

        var _regData = new Object();
        _regData.gr = 1;
        if ($("#rdoGender_Female").is(":checked")) {
            _regData.gr = 2;
        }

        _regData.ln = $("#txtLoginName").val();
        _regData.em = $("#txtEmailAddress").val();
        _regData.pwd = $("#txtPassword").val();
        _regData.dm = _month;
        _regData.dd = _day;
        _regData.dy = _year;

        //console.log(_regData);

        $.postDATA(_SitePath + "/post/register", _regData, function (_return) {
            if (_return.Result == true) {
                window.location.href = _SitePath + _return.RedirectPath;
            }
            else {
                if (_return.RedirectPath == "DOB") {
                    ShowError("#divDateOfBirthError", REG_INVALIDDOB);
                }
                if (_return.RedirectPath == "AGE") {
                    ShowError("#divDateOfBirthError", REG_AGE);
                }
                if (_return.RedirectPath == "AGE") {
                    ShowError("#divRegisterError", REG_EXISTINGLOGIN);
                }
                $(".registerButton").html("Register");
            }

        });

    });

});

function ShowError(fieldID, errorMessage) {
    $(fieldID).html(errorMessage);

}

function HideError(fieldID) {
    $(fieldID).html("");
}


//fb register

// This is called with the results from from FB.getLoginStatus().
function statusChangeCallback(response) {

    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
    } else if (response.status === 'not_authorized') {
        // The person is logged into Facebook, but not your app.

    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not
    }
}

function checkLoginState() {
    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });
}

window.fbAsyncInit = function () {
    FB.init({
        appId: '364688787022470',
        cookie: true,  // enable cookies to allow the server to access 
        // the session
        xfbml: true,  // parse social plugins on this page
        version: 'v2.1' // use version 2.1
    });

    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });

};

// Load the SDK asynchronously
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

// Here we run a very simple test of the Graph API after login is
// successful.  See statusChangeCallback() for when this call is made.
var _FbLoginDetails;
$(document).ready(function () {



    $(document).keydown(function (e) {
        if (e.keyCode == 13) {
            //check foucs button
            var _registerFacus = $(".registerButton").is(":focus");
            if (_registerFacus) {
                $(".registerButton").trigger("click");
            }
        }
    });

    _FbLoginDetails = new Object();
    $("#divfblogin").click(function () {
        FB.login(function (response) {
            if (response.authResponse) {
                FB.api('/me', function (response) {
                    _FbLoginDetails.email = response.email;
                    _FbLoginDetails.gender = response.gender;
                    _FbLoginDetails.birthday = response.birthday;
                    //   alert(JSON.stringify(response));

                    API_FBLOGIN = _SitePath + "Post/login";
                    //here check email address and allow to login
                    var _apiCheckEmailPath = _SitePath + "API/CheckExistingEmailAddress";
                    var _apiCEmailObject = new Object();
                    _apiCEmailObject.EmailAddress = response.email;
                    $.postDATA(_apiCheckEmailPath, _apiCEmailObject, function (_return) {
                        if (_return) {
                            var _FbAuthObject = new Object();
                            _FbAuthObject.EmailAddress = response.email
                            _FbAuthObject.IsFB = true;  
                            $.postDATA(API_FBLOGIN, _FbAuthObject, function (_AuthResponse) {
                                if (_AuthResponse.Result) {
                                    window.location.href = _SitePath + _AuthResponse.RedirectPath;
                                } else {
                                    SetIntelliWindow("#lnkFbRegister", response);
                                }

                            }, function (ex) {
                                window.location.reload();
                            });
                           // window.location.reload();
                        } else {
                            SetIntelliWindow("#lnkFbRegister", response);
                        }

                    });
                });
            } else {
                //$("#login-status").html("Not logged in");
                //login error

            }
        }, { scope: 'public_profile,email,user_birthday' });

    });

});


function ChackFBEmailAddressAndDoRedirect(_email) {

   
}
