﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_profilewritten.ascx.cs" Inherits="IntelliWebR1.web.ko.template_profilewritten" %>

<script type="text/html" id="template_profilewritten">
    <div class="thirteen_text">
        <h3 class="wrritten-title" data-bind="text: GetQuestion"></h3>
        <p style="word-break:break-all;"  data-bind="html: AnswerHtml"></p>
        <!-- ko if:IsDiscuss -->
        <img src="images/Discuss94.png" id="btnChatAboutIt" class="ChatAboutIt discuss" style="cursor:pointer;background:#ffffff;"  data-bind=" attr: { 'data-id': AnswerID }" />
        <!--/ko-->
        <span class="clear"></span>
    </div>
</script>
