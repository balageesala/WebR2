
(function ($) {
    $.getDATA = function (serviceurl, successcallback, errorcallback) {
        $.ajax({
            url: serviceurl,
            type: "GET",
            dataType: "JSON",
            success: successcallback,
            error: errorcallback
        });
    };
}(jQuery));

(function ($) {
    $.postDATA = function (serviceurl, formData, successcallback, errorcallback) {
        $.ajax({
            url: serviceurl,
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            type: "POST",
            dataType: "JSON",
            data: formData,
            success: successcallback,
            error: errorcallback
        });
    };
}(jQuery));


    $(document).ready(function () {

        var SESSION_API = _SitePath + "api/SessionCheck";
        $.getDATA(SESSION_API, function (_IsOnline) {
            if (!_IsOnline) {
                window.location.href = _SitePath + "web/LogOut";
                window.parent.CloseIntelliWindow();
            } else {
                return true;
            }
        }, function () { });
        

        var OtherUserID = getParameterByName("recid");
        var Question_id = getParameterByName("pid");
        var _urlToLoad = _SitePath + "web/inner/questionssinglematch.aspx?uid=" + OtherUserID + "&pid=" + Question_id;
        $("#divLoadQuestion").load(_urlToLoad, function () {
        });


        $(".imgClose").click(function () {
            window.parent.CloseIntelliWindow();
        });


        $("#btnSend").click(function () {

            if ($("#txtMessage").val() == "") {
                window.parent.CloseIntelliWindow();
                return;
            }

            $("#btnSend").attr("disabled", "disabled");
            var _ComposeAPI = _SitePath + "api/Compose";
            var _ComposeObj = new Object();
            _ComposeObj.RecipientID = OtherUserID;
            _ComposeObj.MessageText = $("#txtMessage").val();
            _ComposeObj.IsDraft = false;
            _ComposeObj.Question_id = Question_id;
            //send via ajax request
            $.ajax({
                url: _ComposeAPI,
                contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                type: "POST",
                dataType: "JSON",
                data: _ComposeObj,
                success: function (_return) {
                    if (_return != null) {
                        $("#txtMessage").val("");
                        $("#lblMessageResponse").html("Message has been sent");
                        setTimeout(function () {
                            try {
                                window.parent.CloseIntelliWindow();
                            } catch (e) {
                                window.parent.CloseIntelliWindow();
                            }
                        }, 2000);

                    } else {
                        $("#lblMessageResponse").html("You are restricted to send message until you receive a response.");
                    }
                },
                error: function () { }
            });

        });




    });

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

