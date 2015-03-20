<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="ConversationView.aspx.cs" Inherits="IntelliWebR1.web.ConversationView" %>

<%@ Register Src="~/web/ko/tempalte_conversationview.ascx" TagPrefix="uc1" TagName="tempalte_conversationview" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="received_msg" style="min-height:560px;">
                <div class="twenty">
                    <div class="received_convers">
                        <img src="images/back_btn.png" alt="" class="back" id="btnBack"/>
                        <uc1:tempalte_conversationview runat="server" ID="tempalte_conversationview" />
                        <div class="chat_one" id="divConvView" data-bind="template: { name: 'template_conversationview', foreach: AllMessages }"></div>
                        <div class="chat_one">
                            <div class="chat_photo" style="visibility:hidden;"><img src="images/26A-2_dummy_pic.png" width="78" height="77" alt=""></div>                           
                                <textarea rows="2" cols="1" id="txtReply" placeholder="Enter your message.."></textarea>
                            <span class="clear"></span>
                        </div>
                        <input type="button" class="send" id="btnSend" value="Send" />
                        <span class="clear"></span>
                    </div>
                </div>
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>



    <script type="text/javascript">

        var _GetConversationAPI = _SitePath + "api/GetConversation";
        $(document).ready(function () {
            var _ConversationPost = new Object();
            _ConversationPost.OtherUserID = getParameterByName("id");
            $.postDATA(_GetConversationAPI, _ConversationPost, function (_data) {
                //alert(JSON.stringify(_data));
                ko.applyBindings(new VMMsgConversationList(_data), document.getElementById("divConvView"));
                setTimeout(function () {
                    $(".loadPhoto").each(function (_pos, _obj) {
                        var _loadUrl = $(_obj).data("loadurl");
                        $(_obj).load(_loadUrl, function () {
                        });
                    });

                    $(".loadDiscuss").each(function (_pos, _obj) {
                        var _loadUrl = $(_obj).data("loadurl");
                        $(_obj).load(_loadUrl, function () {
                        });
                    });
                }, 500);
                $("#divConvView").animate({ scrollTop: $('#divConvView')[0].scrollHeight }, 500);
            });

            var ISUSERBLOCKED;
            var _APIISBLOCKED = _SitePath + "api/HasUserBlocked";
            var _BlockedObj = new Object();
            _BlockedObj.BlockedUserID = getParameterByName("id");
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
                $("#btnSend").val("Please wait..");
                $("#btnSend").attr("disabled", "disabled");
                var _ComposeObj = new Object();
                _ComposeObj.RecipientID = getParameterByName("id");
                _ComposeObj.MessageText = $("#txtReply").val();
                _ComposeObj.DiscussType = 1;
                _ComposeObj.DiscussType_id = "0";
                _ComposeObj.DiscussTypeID = 1;
                _ComposeObj.IsDraft = false;
                var _ComposeAPI = _SitePath + "api/Compose";
                $.postDATA(_ComposeAPI, _ComposeObj, function (_return) {
                    $("#btnSend").removeAttr("disabled");
                    $("#btnSend").val("Send");
                    if (_return != null) {
                        $("#txtReply").val("");
                        AddNewMessage(_return);
                    } else {
                        alert("You are restricted to send message until you receive a response.");
                    }
                    // Close box
                });

            });


            $("#btnBack").click(function () {
                window.history.back();
            });

        });


        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }


        function VMMsgConversation(_conv) {
            var self = this;
            self.ConversationID = ko.observable(_conv.ConversationID);
            self.SenderID = ko.observable(_conv.SenderID);
            self.Sender = ko.observable(_conv.Sender);
            self.RecipientID = ko.observable(_conv.RecipientID);
            self.Recipient = ko.observable(_conv.Recipient);
            self.MessageText = ko.observable(_conv.MessageText);
            self.HasDelivered = ko.observable(_conv.HasDelivered);
            self.SentTime = ko.observable(_conv.SentTime);
            self.HasRecipientSeen = ko.observable(_conv.HasRecipientSeen);
            self.RecipientSeenTime = ko.observable(_conv.RecipientSeenTime);
            self.IsUserTheSender = ko.observable(_conv.IsUserTheSender);

            self.IsProfanity = ko.observable(_conv.IsProfanity);
            self.SmallMessage = ko.observable(_conv.SmallMessage);
            self.Discuss = ko.observable(new DiscussView(_conv.Discuss));

            self.SentTimeFormate = ko.computed(function () {
                return formatTheTime(self.SentTime());
            });

            self.SentDateFormate = ko.computed(function () {
                return formatTheDate(self.SentTime());
            });

            self.LoadUserPic = ko.computed(function () {
                var _loadUrl = _SitePath + "web/service/LoadUserPhoto?c=USERPIC&ouid=" + self.SenderID();
                return _loadUrl;
            }, this);


            self.LoadDiscuss = ko.computed(function () {

                var DiscussType = self.Discuss().DiscussType();
                var SenderID = self.SenderID();
                var DiscussTypeID = self.Discuss().DiscussTypeID();
                var DiscussType_id = self.Discuss().DiscussType_id();
                var _loadDiscussUrl = "";
                if (DiscussType == 2) {
                    var _OtherUserID = getParameterByName("id");
                    _loadDiscussUrl = _SitePath + "web/inner/loadquestion?qid=" + DiscussType_id + "&uid=" + _OtherUserID;
                }
                if (DiscussType == 4) {
                    _loadDiscussUrl = _SitePath + "web/inner/loadphoto?pid=" + DiscussTypeID;
                }
                if (DiscussType == 5) {
                    _loadDiscussUrl = _SitePath + "web/inner/loadwritten?wid=" + DiscussTypeID;
                }              
                return _loadDiscussUrl;
            }, this);


        }


        function VMMsgConversationList(_list) {
            var self = this;
            self.AllMessages = ko.observableArray();

            for (var i = 0; i < _list.length; i++) {
                self.AllMessages.push(new VMMsgConversation(_list[i]));
            }

            AddNewMessage = function (_obj) {
                self.AllMessages.push(new VMMsgConversation(_obj));
                $(".loadPhoto").each(function (_pos, _obj) {
                    var _loadUrl = $(_obj).data("loadurl");
                    $(_obj).load(_loadUrl, function () {
                    });
                });
                $("#divConvView").animate({ scrollTop: $('#divConvView')[0].scrollHeight }, 500);

            };

            DeleteThisConversation = function (_data) {
                //  alert(_data.ConversationID());
                var _GetConversationAPI = _SitePath + "api/GetConversation/" + _data.ConversationID();
                $.getDATA(_GetConversationAPI, function (_ret) {
                    if (_ret) {
                        self.AllMessages.remove(_data);
                    }
                });
            }



        }


        function DiscussView(_discuss) {
            var self = this;
            self._id = ko.observable(_discuss._id);
            self.DiscussID = ko.observable(_discuss.DiscussID);
            self.ConversationID = ko.observable(_discuss.ConversationID);
            //0 = Only Compose
            //1 = Replay to message
            //2 = Question
            //3 = criteria
            //4 = photos
            //5 = written (about me)
            self.DiscussType = ko.observable(_discuss.DiscussType);
            self.DiscussTypeID = ko.observable(_discuss.DiscussTypeID);
            self.DiscussType_id = ko.observable(_discuss.DiscussType_id);
            self.Status = ko.observable(_discuss.Status);
        }


        function formatTheDate(thedate) {

            thedate = new Date(thedate);
            var month = thedate.getMonth();
            var day = thedate.getDate();
            var year = thedate.getFullYear();
            year = year.toString().substr(2, 2);

            month = month + 1;

            month = month + "";

            if (month.length == 1) {
                month = "0" + month;
            }

            day = day + "";

            if (day.length == 1) {
                day = "0" + day;
            }
            return month + "/" + day + "/" + year;
        }


        function formatTheTime(frmdate) {
            frmdate = new Date(frmdate);
            var hours = frmdate.getHours();
            var minutes = frmdate.getMinutes();
            var ampm = hours >= 12 ? 'pm' : 'am';
            hours = hours % 12;
            hours = hours ? hours : 12;
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var _hoursString;
            if (hours < 10) {
                _hoursString = "0" + hours;
            } else {
                _hoursString = hours;
            }
            var strTime = _hoursString + ':' + minutes + '' + ampm;

            return strTime;
        }




    </script>


</asp:Content>
