<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compose.aspx.cs" Inherits="IntelliWebR1.web.inner.compose" %>

<!DOCTYPE html>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<div class="compose" id="divCanSend" runat="server" visible="true">
    <a class="close imgClose" style="cursor:pointer;">x</a>
    <span class="clear"></span>
    <div id="divUserName" runat="server" style="margin-left: 30px;"></div>
    <div class="compose_cont">
        <textarea class="" rows="3" id="txtMessage" cols="1" name="message"></textarea>
    </div>
    <input type="button" class="send" id="btnSend" value="Send">
    <div id="lblMessageResponse" style="margin-left:28px;"></div>
    <span class="clear"></span>
</div>

  <div class="compose" id="divCantSend" runat="server">
      <a class="close imgClose" style="cursor:pointer;" >x</a>
        <span class="clear"></span>
       <div style="text-align:center;padding-bottom:20px;">You are restricted to send message until you receive a response.</div>
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
