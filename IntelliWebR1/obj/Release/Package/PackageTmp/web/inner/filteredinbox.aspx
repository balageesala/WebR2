<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="filteredinbox.aspx.cs" Inherits="IntelliWebR1.web.inner.filteredinbox" %>

<%@ Register Src="~/web/ko/template_filteredmessage.ascx" TagPrefix="uc1" TagName="template_filteredmessage" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>

<div id="divFilteredInbox" data-bind="template: { name: 'template_filteredmsgs' }"></div>

<uc1:template_filteredmessage runat="server" ID="template_filteredmessage" />


<script type="text/javascript">

    $(document).ready(function () {

        //  $(".article17").removeClass("article17").addClass(".article18");

    });


</script>
