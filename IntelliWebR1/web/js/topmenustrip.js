

$(document).ready(function () {

    $(".singleLogOutDiv, #lnkLogOut").click(function () {
        window.location.href = _SitePath + "web/LogOut";
    });

    $("#lnkMessages").click(function () {
        window.location.href = _SitePath + "web/Messages";
        $(".lblmesage").hide();
    });

    $("#lnkViewed").click(function () {
        window.location.href = _SitePath + "web/ProfileView";
    });

    $("#lnkSaved").click(function () {
        window.location.href = _SitePath + "web/ProfileSave";
    });

    $("#lnkNotifications").click(function () {
        window.location.href = _SitePath + "web/Notifications";
    });

    $("#lnkSettings").click(function () {
        window.location.href = _SitePath + "web/Settings";
    });

    $(".divprofilepic").click(function () {
        window.location.href = _SitePath + "web/MyProfile#aboutme";
    });


});



$(document).ready(function () {

    //heighleting current menu item

    $("#lblMsgsCount").hide();
    $("#lblNotificationsCount").hide();

    var _currentItem = window.location.pathname;
     
   
    if (_currentItem.indexOf("Messages") != -1) {
        $("#lnkMessages").addClass("activateLink");
    }
    if (_currentItem.indexOf("Notifications") != -1) {
        $("#lnkNotifications").addClass("activateLink");
    }
    if (_currentItem.indexOf("Settings") != -1) {
        $("#lnkSettings").addClass("activeSettings");
    }
    if (_currentItem.indexOf("MatchsHistory") != -1) {
        $("#lnkRematch").addClass("activateLink");
    }
    if (_currentItem.indexOf("ProfileView") != -1) {
        $("#lnkViewedMe").addClass("activateLink");
    }
    if (_currentItem.indexOf("aspx") != -1) {
        window.location.href = _SitePath + "web/PageNotFound";
    }

    setInterval(function () {
        var _pageName = window.location.pathname;
      
        if (_pageName.indexOf("ConversationView") == -1) {
            SetCountForMessagesAndNotis();
        }
    }, 5000);
   

    

});


function SetCountForMessagesAndNotis() {
    var UnreadMessages_API = _SitePath + "api/GetUnreadMessagesCount";
    $.getDATA(UnreadMessages_API, function (_return) {
        if (_return == 0) {
            $("#lblMsgsCount").hide();
        } else {
            $("#lblMsgsCount").show();
            var _pageName = window.location.pathname;
            if (_pageName.indexOf("ConversationView") != -1 && _pageName.indexOf("Messages") != -1) {
                $("#lblMsgsCount").hide();
            } else {
                $("#lblMsgsCount").text(_return);
            }
        }
    }, function () { });



    var UnViewedNotis_API = _SitePath + "api/GetUnreadNotificationCount";
    $.getDATA(UnViewedNotis_API, function (_return) {
        if (_return == 0) {
            $("#lblNotificationsCount").hide();
        } else {
            $("#lblNotificationsCount").show();
            $("#lblNotificationsCount").text(_return);
        }
    }, function () { });
}