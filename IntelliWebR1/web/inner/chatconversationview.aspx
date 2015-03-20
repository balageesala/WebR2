<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chatconversationview.aspx.cs" Inherits="IntelliWebR1.web.inner.chatconversationview" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<div>
    <div style="margin-top: 4px; margin-left: 10px;width: 880px; float: left;">
        <div class="BackButton">
            <div id="btnBack">back</div>
        </div>
    </div>

    <div style="float: left; margin-top: -40px;width: 760px;margin-left: 130px;">
        <input type="button" value="DELETE" id="btnDeleteAll" class="deletebtnenable" />
    </div>

    <div id="divConversation"  style="margin-left: 20px;height:478px;overflow-y:auto;float: left;"  data-bind="template: { name: 'template-userconversation', foreach: AllConversations }" style="width: 1000px; min-height: 320px; max-height: 450px; overflow-x: hidden; overflow-y: auto; border: 1px solid #ccc; border-radius: 4px 6px; background-color: #fff;">
    </div>

</div>
<script type="text/html" id="template-userconversation">
    <div style="width: 880px; display: inline-block;float: left;">
        <div style="font-family: Arial; font-size: 12px; width: 700px; float: left; word-break: break-all;" data-bind="html: MessageTextWithSenderName"></div>
        <div style="float: right; width: 134px;">
            <div style="float: left; font-size: 12px;" data-bind="text: SentTimeStringRel"></div>
        </div>
    </div>
</script>