<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="chatwindows.ascx.cs" Inherits="IntelliWebR1.web.uc.chatwindows" %>

<asp:Literal ID="ltScripts" runat="server"></asp:Literal>
<div id="divChatWindows" data-bind="template: { name: 'template-chatwindow', foreach: AllWindows }"></div>
<script type="text/html" id="template-chatwindow">
    <!--ko if:ShowThis-->
    <div class="chatBox" data-bind="attr: { style: StyleRight }">
        <div class="chatheader">
            <div class="divchatuname" data-bind="text: UserName"></div>
            <div class="divclose" data-bind="event: { click: CloseWindow }">
                <img data-bind="attr: { src: CloseImage }" style="width: 30px; height: 30px;" />
            </div>
        </div>
        <div class="divchatbox chatArea">
            <!--ko if:ConversationsAvailable-->
            <!--ko foreach:Conversation-->
            <div class="divleftradius" data-bind="html: MessageTextWithPic">
            </div>
            <!--/ko-->
            <!--/ko-->
        </div>
        <div style="width: 300px; height: 2px; border-bottom: 1px solid #ccc;"></div>
        <div style="width: 300px; height: 20px; background-color: #fff;">
            <textarea class="chatText" style="margin-left: 2px; width: 292px; min-height: 20px; max-height: 40px; word-break: break-all; border: 0px; resize: none; font-family: Arial; font-size: 12px; outline: none;" data-bind="attr: { 'data-userid': UserID }"></textarea>
        </div>
    </div>
    <!--/ko-->

</script>
