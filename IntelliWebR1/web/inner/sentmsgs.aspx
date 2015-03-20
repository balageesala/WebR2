<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sentmsgs.aspx.cs" Inherits="IntelliWebR1.web.inner.sentmsgs" %>

<%@ Register Src="~/web/ko/template_sentmessage.ascx" TagPrefix="uc1" TagName="template_sentmessage" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>
<div id="divSentMsgs" class="nineteen" data-bind="template: { name: 'template_sentmessage'}"></div>
<uc1:template_sentmessage runat="server" ID="template_sentmessage" />




<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>