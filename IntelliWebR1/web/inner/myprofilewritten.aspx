<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myprofilewritten.aspx.cs" Inherits="IntelliWebR1.web.inner.myprofilewritten" %>

<%@ Register Src="~/web/ko/template_myprofilewritten.ascx" TagPrefix="uc1" TagName="template_myprofilewritten" %>


<asp:literal id="ltScripts" runat="server"></asp:literal>

<div class="divmyprofilewritten" id="divmyprofilewritten" data-bind="template: { name: 'template_myprofilewritten', foreach: AllDescAnswers }" ></div>
<uc1:template_myprofilewritten runat="server" ID="template_myprofilewritten" />

<script type="text/javascript">

    $(document).ready(function () {
       
        CheckIsUserOnline();

    });


</script>