
var _setDeleteData;
function VMTrashConversationSnapShot(_snap) {
    var self = this;
    self.UserID = ko.observable(_snap.UserID);
    self.FilterName = ko.observable(_snap.FilterName);
    self.ConversationType = ko.observable(_snap.ConversationType);
    self.IsConversation = ko.observable(_snap.IsConversation);
    self.LastConversation = ko.observable(_snap.LastConversation);
    self.DeletedTime = ko.observable(_snap.DeletedTime);
    self.DeletedTimeString = ko.observable(_snap.DeletedTimeString);
    self.OrderByDeletedTime = ko.observable(_snap.OrderByDeletedTime);


    self.Selected = ko.observable(false);

    self.PassportID = ko.computed(function () {
        return "passport_" + self.UserID();
    }, this);

    self.LoadPassportHtml = ko.computed(function () {
        var _loadUrl = _SitePath + "web/service/LoadControl?c=PASSPORT&ouid=" + self.UserID();
        return _loadUrl;
    }, this);

    self.MessageTypeImg = ko.computed(function () {
        if (self.ConversationType() == 1) {
            return "images/inbox-black.png";
        } else if (self.ConversationType() == 2) {
            return "images/sent-black.png";
        } else {
            return "images/chat-icon.png";
        }
    }, this);

    self.MessageFilter = ko.computed(function () {
        if (self.FilterName() != "") {
            return self.FilterName();
        } else {
            return "?";
        }
    }, this);


}

function VMTrashConversationSnapShotList(_snaplist) {
    var self = this;
    self.AllSnapshots = ko.observableArray();
    for (var i = 0; i < _snaplist.length; i++) {
        self.AllSnapshots.push(new VMTrashConversationSnapShot(_snaplist[i]));
    }

    IsDeleteAll = ko.computed({
        read: function () {
            var item = ko.utils.arrayFirst(self.AllSnapshots(), function (item) {
                return item.Selected();
            });
            return item == null;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.AllSnapshots(), function (person) {
                person.Selected(value);
            });
        }
    });



    SelectAll = ko.computed({
        read: function () {
            var item = ko.utils.arrayFirst(self.AllSnapshots(), function (item) {
                return !item.Selected();
            });
            return item == null;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.AllSnapshots(), function (person) {
                person.Selected(value);
            });
        }
    });

    RebindDATA = function () {
        $("#divTrashMsgs").hide();
        $(".divloadingimg").show();
        var _GetTrashAPI = _SitePath + "api/Trash";
        $.getDATA(_GetTrashAPI, function (_data) {
            if (_data.length != 0) {
                RemoveAndReBindTrash(_data);
                $("#divTrashMsgs").show();
                $(".divloadingimg").hide();
                setTimeout(function () {
                    $(".loadUrl").each(function (_pos, _obj) {
                        var _loadUrl = $(_obj).data("loadurl");
                        $(_obj).load(_loadUrl, function () {
                        });
                    });
                }, 500);
                $(".ViewTrashConversation").click(function () {

                    var convType=$(this).data("ctype");

                    if (convType == 3) {
                        window.location.href = "ConversationView?id=" + $(this).data("conv") + "&page=trashchat";
                    } else {
                        window.location.href = "ConversationView?id=" + $(this).data("conv") + "&page=trash";
                    }

                   
                });
                
            } else {
                $("#divTrashMsgs").show();
                $(".divloadingimg").hide();
                $("#divTrashMsgs").html("No messages found.");
                $("#divTrashMsgs").addClass("nomessagesdiv");
            }
        }, function () { });
    }


    RemoveAndReBindTrash = function (_data) {
        self.AllSnapshots.removeAll();
        for (var i = 0; i < _data.length; i++) {
            self.AllSnapshots.push(new VMTrashConversationSnapShot(_data[i]));
        }
    }


    DeleteConversation = function (_data) {
        CheckIsUserOnline();
        _setDeleteData = new Array();

       

        if (_data.ConversationType() == 3) {

            _setDeleteData.push(_data.LastConversation()._id);
            IntelliConfirmWindow("Are you sure you want to delete?", 300, 0);
        } else {
            _setDeleteData.push(_data.LastConversation().ConversationID);
            IntelliConfirmWindow("Are you sure you want to delete?", 300, 0);
        }

      

    }


    DeleteSelected = function () {
        CheckIsUserOnline();
        _setDeleteData = new Array();
        for (var i = 0; i < self.AllSnapshots().length; i++) {
            if (self.AllSnapshots()[i].Selected()) {
                if (self.AllSnapshots()[i].ConversationType() == 3) {                   
                    _setDeleteData.push(self.AllSnapshots()[i].LastConversation()._id);
                } else {
                    _setDeleteData.push(self.AllSnapshots()[i].LastConversation().ConversationID);
                }
            }
        }
        IntelliConfirmWindow("Are you sure you want to delete?", 300, 0)
    }



}


var _GetTrashAPI = _SitePath + "api/Trash";
$(document).ready(function () {
    $.getDATA(_GetTrashAPI, function (_data) {
        if (_data == null || _data.length == 0) {
            $("#divTrashMsgs").html("No messages found.");
            $("#divTrashMsgs").addClass("nomessagesdiv");
            $(".divloadingimg").hide();
        } else {
            ko.applyBindings(new VMTrashConversationSnapShotList(_data), document.getElementById("divTrashMsgs"));
            setTimeout(function () {
                $(".loadUrl").each(function (_pos, _obj) {
                    var _loadUrl = $(_obj).data("loadurl");
                    $(_obj).load(_loadUrl, function () {
                    });
                });
            }, 500);
            $(".divloadingimg").hide();
            $(".ViewTrashConversation").click(function () {
                var convType = $(this).data("ctype");
                
                if (convType == 3) {
                    window.location.href = "ConversationView?id=" + $(this).data("conv") + "&page=trashchat";
                } else {
                    //alert(convType);
                    window.location.href = "ConversationView?id=" + $(this).data("conv") + "&page=trash";
                }

            });


        }
    }, function () { });
});

function YesClicked() {

    if (_setDeleteData != null) {
        API_TRASHDATA = _SitePath + "api/trash";
        var _ConObj = new Object();
        _ConObj.ConIDs = _setDeleteData;
        $.postDATA(API_TRASHDATA, _ConObj, function (_ret) {
            RebindDATA(); 
        });
    }
}

function NoClicked() {
    return;
}


