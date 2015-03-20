
$(document).ready(function () {
    
   

    $(".imgclose").click(function () {
        window.parent.CloseIntelliWindow();
    });

    $("#btnRetreivePassword").click(function () {
        if (validateEmailaddress()) {
            var _data = new Object();
            _data.EmailAddress = $("#txtFpEmailAddress").val();
            $.postDATA(_SitePath+"API/ForgotPassword/", _data, function (_return) {
                if (_return) {
                    $("#lblForgotPasswordResult").html(FORGOTPWD_SUCESS);
                    window.parent.CloseIntelliWindow();
                }
                else {
                    $("#lblForgotPasswordResult").html(FORGOTPWD_FAIL);
                }
            });
        }
    });
});


function validateEmailaddress() {
    var _emailAddress = $("#txtFpEmailAddress").val();
    var atpos = _emailAddress.indexOf("@");
    var dotpos = _emailAddress.lastIndexOf(".");
    if (_emailAddress.trim() == "") {
        $("#lblForgotPasswordResult").html(FORGOTPWD_EMAILEMPTY);
        return false;
    } else if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= _emailAddress.length) {
        $("#lblForgotPasswordResult").html(FORGOTPWD_INVALIDEMAIL);
        return false;
    } else {
        return true;
    }
}