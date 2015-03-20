<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutmediscuss.aspx.cs" Inherits="IntelliWebR1.web.inner.aboutmediscuss" %>

<!DOCTYPE html>
<html>
<div>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <asp:literal id="ltScripts" runat="server"></asp:literal>
</div>

<div class="chatwithme pop_descript_hy">
    <a class="close imageclose">x</a>
    <span class="clear"></span>
    <div class="chatme_cont pop_descript">
        <h3 id="hQuestionText" runat="server"></h3>
        <p class="text" id="pAnswer" runat="server" style="max-height:170px;overflow-y:auto;"></p>
        <textarea rows="3" cols="1" id="txtArea" name="message"></textarea>
       </div>
      <div id="lblMessageResponse" style="color:red;font-size: 13px;width: 570px;margin:0 auto;"></div>
   
    <input type="button" class="send" id="btnSubmit" value="Send" runat="server" />
    <span class="clear"></span>
</div>
</html>
<script type="text/javascript">

    $(document).ready(function () {

        $(".imageclose").click(function () {
            window.parent.CloseIntelliWindow();
        });


        $("#lblMessageResponse").html("");

        $("#btnSubmit").click(function () {
            var _messageText = $("#txtArea").val().trim();
            if (_messageText == "") {
                $("#lblMessageResponse").html("Please enter message.");
              //  window.parent.CloseIntelliWindow();
                return;
            }
            var _ComposeAPI = _SitePath + "api/Compose";
            $("#btnSubmit").attr("disabled", "disabled");
            $("#btnSubmit").val("Please wait..");
            var _ComposeObj = new Object();
            var _mAnswer_id = $(this).data("mid");
            var _sAnswerID = $(this).data("sid");
            _ComposeObj.RecipientID = window.parent._OtherUserID;
            _ComposeObj.MessageText = _messageText;
            _ComposeObj.DiscussType = 5;
            _ComposeObj.DiscussType_id = _mAnswer_id;
            _ComposeObj.DiscussTypeID = parseInt(_sAnswerID);
            // alert(JSON.stringify(_ComposeObj));
            $.postDATA(_ComposeAPI, _ComposeObj, function (_ConversationObject) {
                if (_ConversationObject != null) {
                    $("#txtArea").val("");
                    $("#btnSubmit").val("Send");
                    $("#lblMessageResponse").html("Message has been sent.");
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
                    $("#lblMessageResponse").html("You are restricted to send message until you receive a response.");
                }
            });

        });
    });

    


</script>