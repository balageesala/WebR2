﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_chatmessage.ascx.cs" Inherits="IntelliWebR1.web.ko.template_chatmessage" %>

<script type="text/html" id="template_chatmessage">
    <div class="tabs_info">
    <!-- ko ifnot: IsDeleteAll -->
    <div class="delete">
        <input type="button" class="magnal deletebtnenable" value="Delete" data-bind="click: DeleteSelected" />
    </div>
    <!-- /ko -->
    <div class="head_bar">
        <ul>
            <li class="check"><input type="checkbox" data-bind="checked: SelectAll"></li>
            <li class="info">&nbsp;</li>
            <li class="perit">Message</li>
            <li class="time">Time</li>
            <li class="bin">&nbsp;</li>
        </ul>
        <span class="clear"></span>
    </div>
    <!-- ko foreach: AllSnapshots -->
    <div class="cont_bar">
        <ul>
            <li class="check">
                <input type="checkbox" data-bind="checked: Selected"></li>
            <li class="info">
                <div class="loadUrl" style="width: 280px; height: 103px;" data-bind="attr: { id: PassportID, 'data-loadurl': LoadPassportHtml }">&nbsp;</div>
            </li>
            <li class="perit ViewChatConversation" data-bind="html: LastConversation().SmallMessage, attr: { 'data-conv': UserID }"></li>
            <li class="time_rs" data-bind="text: SentTimeFormat"></li>
            <li class="bin">
                <img src="images/bin-pic.jpg" width="20" height="22" alt="bin" data-bind="click: DeleteConversation" /></li>
        </ul>
        <span class="clear"></span>
    </div>
    <!-- /ko -->
</div>
</script>
