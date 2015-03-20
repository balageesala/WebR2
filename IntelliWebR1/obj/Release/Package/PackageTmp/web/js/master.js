
var m_intelliHub;
$(document).ready(function () {


    m_intelliHub = $.connection.intelliHub;

    $.connection.hub.start().done(function () {
        // do nothing
        m_intelliHub.server.userOnline(_ThisUserID);
    });



    m_intelliHub.client.useronline = function (_userID) {
        makeUseronline(_userID);
    };
    m_intelliHub.client.useroffline = function (_userID) {
        makeUseroffline(_userID);
    };

    m_intelliHub.client.sendmessage = function (_recipientID, conversationObj) {
        AddConversation(conversationObj, _recipientID);
    };

});


function makeUseronline(_UserID) {
    $("#hdnOnlineTrigger").val(_UserID);
    $("#hdnOnlineTrigger").trigger("change");
}
function makeUseroffline(_UserID) {
    $("#hdnOfflineTrigger").val(_UserID);
    $("#hdnOfflineTrigger").trigger("change");
}


$(document).ready(function () {
    $("#hdnOnlineTrigger").change(function () {

        $(".imgOtherUser_Online").each(function (_pos, _elem) {
            if ($("#hdnOnlineTrigger").val() == $(_elem).data("UserID")) {
                $(_elem).attr("src", _SitePath + "web/images/online.gif");
            }
        });

    });

    $("#hdnOfflineTrigger").change(function () {
        $(".imgOtherUser_Online").each(function (_pos, _elem) {
            if ($("#hdnOfflineTrigger").val() == $(_elem).data("UserID")) {
                $(_elem).attr("src", _SitePath + "web/images/offline.gif");
            }
        });
    });

    $(".imgOtherUser_Online").click(function () {
        AddNewChatWindow($(this).data("UserID"));
    });

    $(".logo-text").click(function () {
        window.location.href = _SitePath + "web/Home";
    });

});

function CheckIsUserOnline() {

    var SESSION_API = _SitePath + "api/SessionCheck";
    $.getDATA(SESSION_API, function (_IsOnline) {
        if (!_IsOnline) {
            window.location.href = _SitePath + "web/LogOut";
        } else {
            return true;
        }
    }, function () { });


}



$(document).ready(function () {

    var _pageName = window.location.pathname;
    setInterval(function () {
        if (_pageName.indexOf("ConversationView") == -1) {
            CheckIsUserOnline();
        }  
    }, 8000);


    $("#lnkHelp").click(function () {
        //alert(_pageName);
        if (_pageName.indexOf("Home") != -1) {
            var _helpHome = _SitePath + "web/help/help_home.html";
            SetScrollIntelliWindow(_helpHome, "1000", "600");
        }
    });

});



$(document).ready(function () {

    var _NewUser = $("#hdnNewUser").val();
    var now = new Date();
    var millisTill12 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 11, 59, 59, 0) - now;
    if (millisTill12 < 0) {
        millisTill12 += 86400000; // it's after 12pm
    }

    //update criteria user answers asynic
    var _ApiAsyncCriteria = _SitePath + "api/AsyncCriteriaAnswers";
    $.postDATA(_ApiAsyncCriteria, null, function (_return) {
    });



    //set time for today 12 pm
    //this will fires while user registered day before 12 pm and he stays in site after 12 pm 
    //setTimeout(function () {
    //    if (_NewUser == "1") {
    //        var API_GETMATCH = _SitePath + "API/GetNewUserTodayMatch";
    //        $.getDATA(API_GETMATCH, function (data) {
    //            if (data) {
    //                if (confirm("Your new match is genarated do you want to check?")) {
    //                    window.location.href = _SitePath + "web/Home";
    //                }
    //            }
    //        }, function (err) {
    //            // alert(JSON.stringify(err));
    //        });
    //    }
    //}, millisTill12);

});

