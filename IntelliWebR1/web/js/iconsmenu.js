

var ISUSERBLOCKED = false;

$(document).ready(function () {

   
    IsUserBlocked();
   

    var _GetUSERAPI = _SitePath + "api/GetUserDetails";
    $.getDATA(_GetUSERAPI, function (_data) {
        if (_data.Gender == 2) {
            $("#imgInterested").show();
        } else {
            $("#imgInterested").hide();
        }
    }, function () { });



    $("#imgCompose").click(function () {
       
        if (ISUSERBLOCKED) {
            var _composeurl = _SitePath + "web/inner/compose.aspx?recid=" + _OtherUserID;
            SetUrlIntelliWindow(_composeurl, "620", "410");
        }
        else {
            IntelliAlertWindow("You have blocked this user.", 300, 0);
        }
    });

    $("#imgEmail").click(function () {
       
        if (ISUSERBLOCKED) {
        var _emailurl = _SitePath + "web/inner/emailprofile";
        SetUrlIntelliWindow(_emailurl, "300", "300");
        }
        else {
            IntelliAlertWindow("You have blocked this user.", 300, 0);
        }
    });

    $("#imgBlock").click(function () {
        if (ISUSERBLOCKED) {
            IntelliConfirmWindow("Are you want to block this user?", 300, 0);
        } else {
            IntelliAlertWindow("You have already blocked this user.", 320, 0);
        }
    });


    $("#imgReport").click(function () {
       
        var _Reporturl = _SitePath + "web/inner/reportprofile?uid=" + _OtherUserID;
        SetUrlIntelliWindow(_Reporturl, "650", "350");
       
    });


    $("#imgChat").click(function () {
       
        if (ISUSERBLOCKED) {
             //  alert("clicked");
            //   do chat here
           //    alert(_OtherUserID);
            AddNewChatWindow(_OtherUserID);
            
        } else {
            IntelliAlertWindow("You have blocked this user.", 300, 0);
        }
    });


    $("#imgCompatibilityReport").click(function () {

        var _Reporturl = _SitePath + "web/inner/compatibilityreportcart?RematchID=" + _OtherUserID;
        SetUrlIntelliWindow(_Reporturl, "620", "410")

    });




})

function IsUserBlocked() {
    var _APIISBLOCKED = _SitePath + "api/HasUserBlocked";
    var _BlockedObj = new Object();
    _BlockedObj.BlockedUserID = _OtherUserID;
    $.postDATA(_APIISBLOCKED, _BlockedObj, function (_BlakObject) {
        ISUSERBLOCKED = _BlakObject;
    });

}

function YesClicked() {
    var _BlockAPI = _SitePath + "api/BlockUserProfile";
    var _BlockObj = new Object();
    _BlockObj.BlockedUserID = _OtherUserID;
    $.postDATA(_BlockAPI, _BlockObj, function (_retObject) {
        ISUSERBLOCKED = false;
        IntelliAlertWindow("This user blocked sucessfully.", 300, 0);
    });
}

function NoClicked() {
    return false;
}


$(document).ready(function () {

    //chat icon should be display while user comes into online
    //$("#imgChat").hide();
    //setInterval(function () {
    //    var API_ISONLINE = _SitePath + "api/IsOtherUserOnline";
    //    var OnlineObject = new Object();
    //    OnlineObject.OtherUserID = _OtherUserID;
    //    $.postDATA(API_ISONLINE, OnlineObject, function (_return) {
    //        if (_return) {
    //            $("#imgChat").show();
    //        } else {
    //            $("#imgChat").hide();
    //        }
    //    });
    //}, 5000);

});