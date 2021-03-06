﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_trashmessage.ascx.cs" Inherits="IntelliWebR1.web.ko.template_trashmessage" %>



<script type="text/html" id="template_trashmessage">

    <div class="tabs_info">
        <!-- ko ifnot: IsDeleteAll -->
        <div class="delete">
            <input type="button" class="magnal" value="Delete" /></div>
        <!-- /ko -->
        <div class="head_bar">
            <ul>
                <li class="check">
                    <input type="checkbox" data-bind="checked: SelectAll"></li>
                <li class="info">&nbsp;</li>
                <li class="perit" style="margin: 0px 10px 0 0;width: 325px;">Message</li>
                 <li class="time">Read</li>
                <li class="time">Deleted</li>
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
                    <div class="divsentcol2 loadUrl" style="width: 280px; height: 103px;" data-bind="attr: { id: PassportID, 'data-loadurl': LoadPassportHtml }">&nbsp;</div>
                </li>
                <li class="perit ViewSentConversation" data-bind="html: LastConversation().SmallMessage, attr: { 'data-conv': UserID }"></li>
                <li class="time" data-bind="text: LastConversation().SeenTimeString"></li>
                <li class="time" data-bind="text: DeletedTimeString"></li>
                <li class="time" data-bind="text: LastConversation().SentTimeString">&nbsp;</li>
                <li class="bin">
                    <img src="images/bin-pic.jpg" width="20" height="22" alt="bin" data-bind="click: DeleteConversation" /></li>
            </ul>
            <span class="clear"></span>
        </div>

        <!-- /ko -->

    </div>
</script>
