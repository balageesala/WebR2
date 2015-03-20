<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compose.aspx.cs" Inherits="IntelliWebR1.web.inner.compose" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>


<div style="width: 600px; min-height: 310px; border: 0px solid #ccc; margin: 0 auto; border-radius: 2px 4px;" id="divCanSend" runat="server" visible="true">
    <div style="float: right;">
        <img src="../images/close.png" class="imgClose" style="cursor: pointer;" />
    </div>

    <div style="float: left; width: 100%;">
        <div style="padding-left: 18px; padding-bottom: 4px;" runat="server" id="divUserName"></div>
        <div style="width: 96%; border: 1px solid #ccc; margin: 0 auto; border-radius: 8px 8px;">
            <textarea id="txtMessage" placeholder="Enter Message" class="composeBox"></textarea>
        </div>
    </div>
    <div style="margin-bottom: 16px; margin-right: 8px; float: right; margin-top: 10px;">
        <input type="button" id="btnSend" class="composeSend" value="Send" />
    </div>
    <div id="lblMessageResponse" style="min-height: 20px; float: left; font-family: Arial; font-size: 14px; color: #000; font-weight: bold; margin-left: 20px; padding-top: 10px;">
    </div>
</div>
<div style="width: 618px; min-height: 310px; border: 0px solid #ccc; border-radius: 2px 4px;" id="divCantSend" runat="server" visible="false">
    <div style="float: right; margin-top: -10px;">
        <img src="../images/close.png" class="imgClose" style="cursor: pointer;" />
    </div>
    <div style="font-family: 'Open Sans', 'sans-serif', Arial; font-size: 16px; font-weight: bold; margin: 10px; padding-top: 40px; text-align: center;">You are restricted to send message until you receive a response.</div>
</div>


<script type="text/javascript">

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

    });


</script>
