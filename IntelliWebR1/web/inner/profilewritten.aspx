<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profilewritten.aspx.cs" Inherits="IntelliWebR1.web.inner.profilewritten" %>

<%@ Register Src="~/web/ko/template_profilewritten.ascx" TagPrefix="uc1" TagName="template_profilewritten" %>


<asp:literal id="ltScripts" runat="server"></asp:literal>

<div class="divmyprofilewritten thirteen_cont" id="divprofilewritten" data-bind="template: { name: 'template_profilewritten', foreach: AllDescAnswers }" ></div>
<uc1:template_profilewritten runat="server" id="template_profilewritten" />


<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>