
$(document).ready(function() {
  
    CheckIsUserOnline();
    LoadDefaultTab();
 

    $("#liReceived").click(function () {
        ClearActive();
        CheckIsUserOnline();
        LoadRecivedMessages();
        window.location.hash = "recived";
    });

    $("#liFiltered").click(function () {
        ClearActive();
        CheckIsUserOnline();
        LoadFilteredInbox();
        window.location.hash = "filtered";
    });

    $("#liSentBox").click(function () {
        ClearActive();
        CheckIsUserOnline();
        LoadSentMessages();
        window.location.hash = "sent";
    });

    $("#liInstantMessage").click(function () {
        ClearActive();
        CheckIsUserOnline();
        LoadChats();
        window.location.hash = "chat";
    });

    $("#liTrash").click(function () {
        ClearActive();
        CheckIsUserOnline();
        LoadTrash();
        window.location.hash = "trash";
    });


});

function ClearActive() {
    $("#liReceived").removeClass("active");
    $("#liFiltered").removeClass("active");
    $("#liSentBox").removeClass("active");
    $("#liInstantMessage").removeClass("active");
    $("#liTrash").removeClass("active");
}

function LoadDefaultTab() {

    CheckIsUserOnline();
    ClearActive();
    var _pathurl = window.location.href;

    if (_pathurl.indexOf('#') != "-1") {
        var _tabSection = _pathurl.split('#')[1];
        if (_tabSection == "recived") {
            LoadRecivedMessages();
        }
        if (_tabSection == "filtered") {
            LoadFilteredInbox();
           
        }
        if (_tabSection == "sent") {
            LoadSentMessages();        
        }
        if (_tabSection == "chat") {
            LoadChats();
          
        }
        if (_tabSection == "trash") {
            LoadTrash();
          
        
            
        }
    } else {
        LoadRecivedMessages();
    }
}


    function LoadRecivedMessages() {
        var _UrlPath = _SitePath + "web/inner/receivedmsgs";
        $("#divMessagesList").empty();
        $("#divMessagesList").load(_UrlPath, function () {
            $("#liReceived").addClass("active");
        });
    }

    function LoadFilteredInbox() {

        var _UrlPath = _SitePath + "web/inner/filteredinbox";
        $("#divMessagesList").empty();
        $("#divMessagesList").load(_UrlPath, function () {
            $("#liFiltered").addClass("active");

        });
    }

    function LoadSentMessages() {

        var _UrlPath = _SitePath + "web/inner/sentmsgs";
        $("#divMessagesList").empty();
        $("#divMessagesList").load(_UrlPath, function () {
            $("#liSentBox").addClass("active");
        });
    }

    function LoadChats() {

        var _UrlPath = _SitePath + "web/inner/chatmsgs";
        $("#divMessagesList").empty();
        $("#divMessagesList").load(_UrlPath, function () {
            $("#liInstantMessage").addClass("active");
        });
    }

    function LoadTrash() {
        $("#divMessagesList").empty();
        var _UrlPath = _SitePath + "web/inner/trashmsgs";
        $("#divMessagesList").load(_UrlPath, function () {
            $("#liTrash").addClass("active");
        });
    }
