<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="conversationview.aspx.cs" Inherits="IntelliWebR1.web.inner.conversationview" %>


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
                    <input type="button" id="btnSend" value="Send" class="DbuttonChange" style="height: 55px; width: 136px; margin-top: 2px;" onclick="javascript: void (0)" />
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/html" id="template-userconversation">
    <!--ko ifnot:IsUserTheSender-->
    <div style="width: 700px; min-height: 80px; border: 1px solid #ccc; border-radius: 10px 10px; margin: 10px; display: inline-block;">

        <div style="float: right; padding-top: 6px; padding-right: 6px;">
            <div style="float: left;" class="timeago" data-bind="attr: { title: SentTimeUTC }"></div>
            <div style="float: left; color: #000; font-size: 12px;" data-bind="text: SentTimeStringRel"></div>
        </div>

        <!--ko if:ShowQuestion-->
        <div style="border: 0px solid #ccc;" data-bind="attr: { 'data-loadurl': LoadUrl }" class="loadQuestion"></div>
        <!--/ko-->
        <div style="margin: 10px; font-family: Arial; font-size: 12px; width: 97%; float: left; max-height: 80px; word-break: break-all; overflow-y: auto;" data-bind="html: MessageTextWithSenderName"></div>
        <div style="width: 20px; float: right;">
            <img src="images/del-icon.png" style="height: 20px; width: 20px; cursor: pointer;" data-bind="click: DeleteThisConversation" />
        </div>
    </div>

    <!--/ko-->
    <!--ko if:IsUserTheSender-->
    <div style="width: 700px; min-height: 80px; border: 1px solid #ccc; border-radius: 10px 10px; margin: 10px; margin-left: 230px; display: inline-block;">
        <div style="float: right; padding-top: 6px; padding-right: 6px;">
            <div style="float: left;" class="timeago" data-bind="attr: { title: SentTimeUTC }"></div>
            <div style="float: left; color: #000; font-size: 12px;" data-bind="text: SentTimeStringRel"></div>
        </div>
        <!--ko if:ShowQuestion-->
        <div style="border: 0px solid #ccc; min-height: 40px;" data-bind="attr: { 'data-loadurl': LoadUrl }" class="loadQuestion">
        </div>
        <!--/ko-->
        <div style="margin: 10px; font-family: Arial; font-size: 12px; width: 97%; float: left; max-height: 80px; word-break: break-all; overflow-y: auto;" data-bind="html: MessageTextWithSenderName"></div>
        <div style="width: 20px; float: right;">
            <img src="images/del-icon.png" style="height: 20px; width: 20px; cursor: pointer;" data-bind="click: DeleteThisConversation" />
        </div>

    </div>
    <!--/ko-->
</script>

