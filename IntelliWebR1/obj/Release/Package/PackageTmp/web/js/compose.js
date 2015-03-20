
$(document).ready(function () {
    
    $(".imgClose").click(function () {
        window.parent.CloseIntelliWindow();
    });


});

var _ComposeAPI = _SitePath + "api/Compose";
$(document).ready(function () {
  
    $("#lblMessageResponse").html("");

    $("#btnSend").click(function () {

        if ($("#txtMessage").val() == "") {
            window.parent.CloseIntelliWindow();
            return;
        }

        $("#btnSend").attr("disabled", "disabled");
        var _ComposeObj = new Object();
        _ComposeObj.RecipientID = getParameterByName("recid");
        _ComposeObj.MessageText = $("#txtMessage").val();
        _ComposeObj.IsDraft = false;
        _ComposeObj.Question_id = "0";

        $.postDATA(_ComposeAPI, _ComposeObj, function (_ConversationObject) {
            if (_ConversationObject != null) {
                $("#txtMessage").val("");
                $("#lblMessageResponse").html("Message has been sent");
                setTimeout(function () {
                    setTimeout(function () {
                        try {
                            window.parent.CloseIntelliWindow();
                        } catch (e) {
                            window.parent.CloseIntelliWindow();
                        }
                    }, 2000);
                }, 2000);
            } else {
                alert("You are restricted to send message until you receive a response.");
            }

        });

    });
});


function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}