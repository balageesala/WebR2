<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutmediscuss.aspx.cs" Inherits="IntelliWebR1.web.inner.aboutmediscuss" %>

<!DOCTYPE html>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<div class="chatwithme pop_descript_hy">
    <a class="close">x</a>
    <span class="clear"></span>
    <div class="chatme_cont pop_descript">
        <h3 id="hQuestionText" runat="server"></h3>
        <p class="text" id="pAnswer" runat="server"></p>
        <textarea class="" rows="3" cols="1" name="message"></textarea>
    </div>
    <input type="button" class="send" value="Send" />
    <span class="clear"></span>
</div>
