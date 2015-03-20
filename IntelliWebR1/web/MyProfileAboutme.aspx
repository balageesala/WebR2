<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="MyProfileAboutme.aspx.cs" Inherits="IntelliWebR1.web.MyProfileAboutme" %>

<%@ Register Src="~/web/uc/myprofilemenu.ascx" TagPrefix="uc1" TagName="myprofilemenu" %>
<%@ Register Src="~/web/ko/template_myprofilewritten.ascx" TagPrefix="uc1" TagName="template_myprofilewritten" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <asp:literal id="ltScripts" runat="server"></asp:literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="seven">
                <div class="person" style="display: none;">
                    <img src="images/person.jpg" width="110" height="108" alt="person" /></div>
                <div class="tab_nav">
                    <uc1:myprofilemenu runat="server" ID="myprofilemenu" />
                    <span class="clear"></span>
                </div>
                <uc1:template_myprofilewritten runat="server" ID="template_myprofilewritten" />
                <div class="seven_cont" style="padding-bottom:50px;" id="divmyprofilewritten" data-bind="template: { name: 'template_myprofilewritten', foreach: AllDescAnswers }"></div>
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {

        });

    </script>


</asp:Content>
