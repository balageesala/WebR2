<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trashconversationview.aspx.cs" Inherits="IntelliWebR1.web.inner.trashconversationview" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>
 
<div>
    <div style="margin-top: 4px; margin-left: 10px; width: 100%; float: left;">

        <div class="BackButton">
            <div id="btnBack">back</div>
        </div>

    </div>
    <div style="margin-left: 12px;">
        <div style="float: left; width: 900px; margin-left: 74px; margin-top: 4px;">
            <div id="divConversation" data-bind="template: { name: 'template-userconversation', foreach: AllConversations }" style="width: 950px; min-height: 320px; max-height: 420px; overflow-x: hidden; overflow-y: auto; border: 1px solid #ccc; border-radius: 4px 6px; background-color: #fff;">
            </div>
            <div style="width: 950px; margin-top: 6px; min-height: 60px; border: 0px solid #ccc; border-radius: 4px 6px; margin-bottom: 40px; background-color: #fff;">
                <div style="float: left; width: 800px; height: 60px;">
                    <textarea id="txtReply" style="border-radius: 4px 6px; width: 788px; height: 55px; outline: none; resize: none; font-family: Arial; font-size: 12px;" placeholder="Reply."></textarea>
                </div>
                <div style="float: left; width: 135px; height: 60px; margin-left: 10px;">
                    <input type="button" id="btnSend" value="Send" class="DbuttonChange" style="height: 55px; width: 136px; margin-top: 2px;" />
                </div>
            </div>
        </div>
    </div>
</div>

<script type="text/html" id="template-userconversation">
    <!--ko ifnot:IsUserTheSender-->
    <div style="width: 700px; min-height: 80px; border: 1px solid #ccc; border-radius: 10px 10px; margin: 10px; display: inline-block;">
        
        <div style="float: right;padding-top:6px;padding-right:6px;">
            <div style="float: left;" class="timeago" data-bind="attr: { title: SentTimeUTC }"></div>
            <div style="float: left;color:#000;font-size:12px;" data-bind="text: SentTimeStringRel"></div>
        </div>
        
        
        <!--ko if:ShowQuestion-->
        <div style="border: 0px solid #ccc;" data-bind="attr: { 'data-loadurl': LoadUrl }" class="loadQuestion"></div>
        <!--/ko-->
        <div style="margin: 10px; font-family: Arial; font-size: 12px; width: 97%; float: left; max-height: 80px; overflow-y: auto; word-break: break-all;" data-bind="html: MessageTextWithSenderName"></div>
          <div style="width: 20px; float: right;">
            <img src="images/del-icon.png" style="height: 20px; width: 20px; cursor: pointer;" data-bind="click: DeleteThisConversation" />
        </div>
    </div>

    <!--/ko-->
    <!--ko if:IsUserTheSender-->
    <div style="width: 700px; min-height: 80px; border: 1px solid #ccc; border-radius: 10px 10px; margin: 10px; margin-left: 230px; display: inline-block;">
        <div style="float: right;padding-top:6px;padding-right:6px;">
            <div style="float: left;" class="timeago" data-bind="attr: { title: SentTimeUTC }"></div>
            <div style="float: left;color:#000;font-size:12px;" data-bind="text: SentTimeStringRel"></div>
        </div>
         <!--ko if:ShowQuestion-->
        <div style="border: 0px solid #ccc; min-height: 40px;" data-bind="attr: { 'data-loadurl': LoadUrl }" class="loadQuestion">
        </div>
        <!--/ko-->
        <div style="margin: 10px; font-family: Arial; font-size: 12px; width: 97%; float: left; max-height: 80px; overflow-y: auto; word-break: break-all;" data-bind="html: MessageTextWithSenderName"></div>
        <div style="width: 20px; float: right;">
            <img src="images/del-icon.png" style="height: 20px; width: 20px; cursor: pointer;" data-bind="click: DeleteThisConversation" />
        </div>
       
    </div>
    <!--/ko-->
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#btnBack").click(function () {
            window.history.back();
            // alert(document.referrer);
            // window.location.href = document.referrer;
        });
    });
</script>
<script type="text/javascript">
  
    var _setDeleteData;

    function VMMessageConversation(_conv) {
        var self = this;
        self.ConversationID = ko.observable(_conv.ConversationID);
        self.SenderID = ko.observable(_conv.SenderID);
        self.Sender = ko.observable(_conv.Sender);
        self.RecipientID = ko.observable(_conv.RecipientID);
        self.Recipient = ko.observable(_conv.Recipient);
        self.MessageText = ko.observable(_conv.MessageText);
        self.HasDelivered = ko.observable(_conv.HasDelivered);
        self.SentTime = ko.observable(_conv.SentTime);
        self.SentTimeUTC = ko.observable(_conv.SentTimeUTC);
        self.SentTimeString = ko.observable(_conv.SentTimeString);

        self.HasRecipientSeen = ko.observable(_conv.HasRecipientSeen);
        self.RecipientSeenTime = ko.observable(_conv.RecipientSeenTime);
        self.IsUserTheSender = ko.observable(_conv.IsUserTheSender);

        self.QuestionID = ko.observable(_conv.QuestionID);

        self.ShowQuestion = ko.computed(function () {
            if (self.QuestionID() == "0" || self.QuestionID() == "" || self.QuestionID() == null) {
                return false;
            }
            else {
                return true;
            }
        }, this);


        self.LoadUrl = ko.computed(function () {
            if (self.ShowQuestion()) {
                var _urlToLoad = _SitePath + "web/inner/questionssinglematch.aspx?uid=" + _OtherUserID + "&pid=" + self.QuestionID();
                return _urlToLoad;
            }
            else {
                return "";
            }
        }, this);

        self.SentTimeStringRel = ko.computed(function () {
            return "(" + self.SentTimeString() + ")";
        }, this);

        self.MessageTextWithSenderName = ko.computed(function () {
            var _Html = "";
            if (self.ShowQuestion()) {
                _Html = "<span style=\"font-weight:bold;font-style:italic;margin-left: 8px;\">" + self.Sender().LoginName + "'s response to the above question: </span>&nbsp;";
            } else {
                _Html = "<span style=\"font-weight:bold;font-style:italic;\">" + self.Sender().LoginName + ":</span>&nbsp;";
            }
            _Html = _Html + self.MessageText();
            return _Html;
        }, this);
    }
    function VMMessageConversationList(_list) {
        var self = this;
        self.AllConversations = ko.observableArray();

        for (var i = 0; i < _list.length; i++) {
            self.AllConversations.push(new VMMessageConversation(_list[i]));
        }

        AddNewMessage = function (_obj) {
            self.AllConversations.push(new VMMessageConversation(_obj));
            $(".timeago").timeago();
            $("#divConversation").animate({ scrollTop: $('#divConversation')[0].scrollHeight }, 500);
        };

        DeleteThisConversation = function (_data) {
            //  alert(_data.ConversationID());
            _setDeleteData = new Array();
            _setDeleteData[0]=_data.ConversationID();
            IntelliConfirmWindow("Are you sure you want to delete?", 300, 0)
        }

        RemoveAndReBindTrash= function (_data) {
            self.AllConversations.removeAll();
            for (var i = 0; i < _data.length; i++) {
                self.AllConversations.push(new VMMessageConversation(_data[i]));
            }
        }

        RebindDATA = function () {
            var _ConversationPost = new Object();
            _ConversationPost.OtherUserID = _OtherUserID;
            var _GetConversationAPI = _SitePath + "api/GetTrashConversation";
            $.postDATA(_GetConversationAPI, _ConversationPost, function (_data) {
                if (_data == null) {
                    window.history.back();
                } else {
                    RemoveAndReBindTrash(_data);
                    $("#divConversation").animate({ scrollTop: $('#divConversation')[0].scrollHeight }, 500);

                    $(".loadQuestion").each(function (pos, obj) {
                        var _url = $(obj).data("url");
                        $(obj).load(_url, function () {
                        });
                    });
                }

            });
        }

    }
</script>
<script type="text/javascript">
    var _GetConversationAPI = _SitePath + "api/GetTrashConversation";

    $(document).ready(function () {

        var _ConversationPost = new Object();
        _ConversationPost.OtherUserID = _OtherUserID;

        $.postDATA(_GetConversationAPI, _ConversationPost, function (_data) {
            ko.applyBindings(new VMMessageConversationList(_data), document.getElementById("divConversation"));

            setTimeout(function () {
                $(".loadQuestion").each(function (_pos, _obj) {
                    var _loadUrl = $(_obj).data("loadurl");
                    $(_obj).load(_loadUrl, function () {
                    });
                });
            }, 500);


            $("#divConversation").animate({ scrollTop: $('#divConversation')[0].scrollHeight }, 500);

       
        });

    });
</script>
<script type="text/javascript">
    var _ComposeAPI = _SitePath + "api/Compose";
    $(document).ready(function () {


        var ISUSERBLOCKED;

        var _APIISBLOCKED = _SitePath + "api/HasUserBlocked";
        var _BlockedObj = new Object();
        _BlockedObj.BlockedUserID = _OtherUserID;
        $.postDATA(_APIISBLOCKED, _BlockedObj, function (_BlakObject) {
            ISUSERBLOCKED = _BlakObject;
        });




        $("#btnSend").click(function () {
            if ($("#txtReply").val() == "") {
                return;
            }

            if (!ISUSERBLOCKED) {
                alert("this user is blocked");
                return;
            }
            $("#btnSend").attr("disabled", "disabled");
            var _ComposeObj = new Object();
            _ComposeObj.RecipientID = _OtherUserID;
            _ComposeObj.MessageText = $("#txtReply").val();
            _ComposeObj.IsDraft = false;

            $.postDATA(_ComposeAPI, _ComposeObj, function (_ConversationObject) {
                $("#btnSend").removeAttr("disabled");
                if (_ConversationObject != null) {
                    $("#txtReply").val("");
                   // AddNewMessage(_ConversationObject);
                } else {
                    alert("You are restricted to send message until you receive a response.");
                }
                // Close box
            });

        });
    });


    function YesClicked() {
        if (_setDeleteData != null) {
            API_TRASHDATA = _SitePath + "api/trash";
            var _ConObj = new Object();
            _ConObj.ConIDs = _setDeleteData;
            // alert(JSON.stringify(_ConObj));
            $.postDATA(API_TRASHDATA, _ConObj, function (_ret) {
                RebindDATA();
            });
        }
    }

    function NoClicked() {
        return;
    }



</script>


<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>