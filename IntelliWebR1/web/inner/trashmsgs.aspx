<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trashmsgs.aspx.cs" Inherits="IntelliWebR1.web.inner.trashmsgs" %>

<%@ Register Src="~/web/ko/template_trashmessage.ascx" TagPrefix="uc1" TagName="template_trashmessage" %>



<asp:literal id="ltScripts" runat="server"></asp:literal>

<div id="divTrashMsgs" data-bind="template: { name: 'template_trashmessage'}" > </div>
<uc1:template_trashmessage runat="server" ID="template_trashmessage" />




<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>